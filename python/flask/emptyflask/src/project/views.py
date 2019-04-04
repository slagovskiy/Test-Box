import glob
import json
import os
from uuid import uuid4
from datetime import datetime
from flask import render_template, g, send_file, request, session, flash, redirect, url_for
from flask.ext.login import current_user
from project import app, db, logger
from project.auth.decorators import login_required, role_admin_required, role_staff_required
from .toolbox.capcha import captcha_image, captcha_code
from config import UPLOAD_DIR


@app.before_request
def before_request():
    g.user = current_user
    if g.user.is_authenticated:
        g.user.last_seen = datetime.utcnow()
        db.session.add(g.user)
        db.session.commit()


@app.errorhandler(404)
def not_found_error(error):
    return render_template('404.html'), 404


@app.errorhandler(500)
def internal_error(error):
    db.session.rollback()
    return render_template('500.html'), 500


@app.route('/', methods=['POST', 'GET'])
@app.route('/index', methods=['POST', 'GET'])
def index():
    if request.method=='POST':
        if 'captcha' in session:
            if str(session['captcha']).lower() == str(request.form['captcha']).lower():
                session.pop('captcha')
                flash('captcha ok!')
            else:
                session.pop('captcha')
                flash('captcha error!')
    return render_template('index.html')


@app.route('/captcha')
def captcha():
    session['captcha'] = captcha_code(4)
    return send_file(captcha_image(session['captcha']), mimetype='image/png')

@app.route('/lock')
@login_required
def lock():
    return "locked page"


@app.route('/lock_admin')
@role_admin_required
def lock_admin():
    return "admin page"


@app.route('/lock_staff')
@role_staff_required
def lock_staff():
    return "staff page"


@app.route("/files/<uuid>")
def upload_complete(uuid):
    # Get their files.
    root = UPLOAD_DIR + "/{}".format(uuid)
    if not os.path.isdir(root):
        return "Error: UUID not found!"

    files = []
    for file in glob.glob("{}/*.*".format(root)):
        fname = file.split(os.sep)[-1]
        files.append(fname)

    return render_template("files.html",
        uuid=uuid,
        files=files,
    )


def ajax_response(status, msg):
    status_code = "ok" if status else "error"
    return json.dumps(dict(
        status=status_code,
        msg=msg,
    ))
