from datetime import datetime
from flask import render_template, flash, redirect, session, g, request, url_for
from flask.ext.login import login_user, logout_user, current_user, login_required
from flask.ext.babel import gettext
from app import app, db, lm, openid, babel
from config import POSTS_PER_PAGE, MAX_SEARCH_RESULTS, LANGUAGES
from forms import LoginForm, EditForm, PostForm, SearchForm
from models import User, Post, ROLE_USER, ROLE_ADMIN
from emails import follower_notification


@app.before_request
def before_request():
    g.user = current_user
    if g.user.is_authenticated:
        g.user.last_seen = datetime.utcnow()
        db.session.add(g.user)
        db.session.commit()
        g.search_form = SearchForm()


@app.errorhandler(404)
def not_found_error(error):
    return render_template('404.html'), 404


@app.errorhandler(500)
def internal_error(error):
    db.session.rollback()
    return render_template('500.html'), 500


@babel.localeselector
def get_locale():
    return request.accept_languages.best_match(LANGUAGES.keys())


@app.route('/', methods=['POST', 'GET'])
@app.route('/index', methods=['POST', 'GET'])
@app.route('/index/<int:page>', methods=['POST', 'GET'])
def index(page = 1):
    form = PostForm()
    if form.validate_on_submit():
        post = Post(body=form.post.data, timestamp=datetime.utcnow(), author=g.user)
        db.session.add(post)
        db.session.commit()
        flash(gettext('Your post is now live!'))
        return redirect(url_for('index'))
    if g.user.is_authenticated:
        posts = g.user.followed_posts().paginate(page, POSTS_PER_PAGE, False)
    else:
        posts = []
    return render_template('index.html',
                           title=gettext('Home'),
                           form=form,
                           posts=posts)

@lm.user_loader
def load_user(id):
    return User.query.get(int(id))


@app.route('/login', methods=['POST', 'GET'])
@openid.loginhandler
def login():
    if g.user is not None and g.user.is_authenticated:
        return redirect('/index/')
    form = LoginForm()
    if form.validate_on_submit():
        session['remember_me'] = form.remember_me.data
        return openid.try_login(form.openid.data, ask_for=['nickname', 'email'])
    return render_template(
        'login.html',
        title=gettext('Sign in'),
        form=form,
        providers=app.config['OPENID_PROVIDERS']
    )


@openid.after_login
def after_login(resp):
    if resp.email is None or resp.email == '':
        flash(gettext('Invalid login. Please try again.'))
        return redirect('/login/')
    user = User.query.filter_by(email=resp.email).first()
    print user
    if user is None:
        nickname = resp.nickname
        if nickname is None or nickname == '':
            nickname = resp.email.split('@')[0]
        nickname = User.make_valid_nickname(nickname)
        nickname = User.make_unique_nickname(nickname)
        user = User(nickname=nickname, email=resp.email, role=ROLE_USER)
        db.session.add(user)
        db.session.commit()
        db.session.add(user.follow(user))
        db.session.commit()
    remember_me = False
    if remember_me in session:
        remember_me = session['remember_me']
        session.pop('remember_me', None)
    login_user(user, remember=remember_me)
    return redirect(request.args.get('next') or url_for('index'))


@app.route('/logout')
def logout():
    logout_user()
    return redirect(url_for('index'))


@app.route('/user/<nickname>')
@app.route('/user/<nickname>/<int:page>')
@login_required
def user(nickname, page = 1):
    user = User.query.filter_by(nickname=nickname).first()
    if user is None:
        flash(gettext('User %(name)s not found', name=nickname))
        return redirect(url_for('index'))
    posts = user.post.paginate(page, POSTS_PER_PAGE, False)
    return render_template(
            'user.html',
            user=user,
            posts=posts
    )


@app.route('/edit', methods=['GET', 'POST'])
@login_required
def edit():
    form = EditForm(g.user.nickname)
    if form.validate_on_submit():
        g.user.nickname = form.nickname.data
        g.user.about_me = form.about_me.data
        db.session.add(g.user)
        db.session.commit()
        flash(gettext('Your changes have been saved.'))
        return redirect(url_for('edit'))
    else:
        form.nickname.data = g.user.nickname
        form.about_me.data = g.user.about_me
    return render_template('edit.html', form=form)


@app.route('/follow/<nickname>')
@login_required
def follow(nickname):
    user = User.query.filter_by(nickname=nickname).first()
    if user is None:
        flash(gettext('User %(name)s not found.', name=nickname))
        return redirect(url_for('index'))
    if user == g.user:
        flash('You can\'t follow yourself!')
        return redirect(url_for('user', nickname=nickname))
    u = g.user.follow(user)
    if u is None:
        flash('Cannot follow ' + nickname + '.')
        return redirect(url_for('user', nickname=nickname))
    db.session.add(u)
    db.session.commit()
    flash(gettext('You are now following %(name)s!', name=nickname))
    follower_notification(user, g.user)
    return redirect(url_for('user', nickname=nickname))


@app.route('/unfollow/<nickname>')
@login_required
def unfollow(nickname):
    user = User.query.filter_by(nickname=nickname).first()
    if user is None:
        flash('User ' + nickname + ' not found.')
        return redirect(url_for('index'))
    if user == g.user:
        flash(gettext('You can\'t unfollow yourself!'))
        return redirect(url_for('user', nickname=nickname))
    u = g.user.unfollow(user)
    if u is None:
        flash(gettext('Cannot unfollow %(name)s.', name=nickname))
        return redirect(url_for('user', nickname=nickname))
    db.session.add(u)
    db.session.commit()
    flash(gettext('You have stopped following %(name)s.', name=nickname))
    return redirect(url_for('user', nickname=nickname))


@app.route('/search', methods=['POST'])
@login_required
def search():
    if not g.search_form.validate_on_submit():
        return redirect(url_for('index'))
    return redirect(url_for('search_results', query=g.search_form.search.data))


@app.route('/search_results/<query>')
@login_required
def search_results(query):
    results = Post.query.whoosh_search(query, MAX_SEARCH_RESULTS).all()
    return render_template(
            'search_results.html',
            query=query,
            results=results
    )
