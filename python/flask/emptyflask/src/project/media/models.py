from uuid import uuid4
from datetime import datetime
from project import db
from .config import SIZE_UUID, SIZE_FILENAME, SIZE_TYPE


class MediaFolder(db.Model):
    __tablename__ = 'media_folder'
    id = db.Column('folder_id', db.Integer, primary_key=True)
    uuid = db.Column('uuid', db.String(SIZE_UUID), unique=True)
    foldername = db.Column('foldername', db.String(SIZE_FILENAME), default='')
    added = db.Column('added', db.DateTime)
    rename = db.Column('rename', db.Boolean, default=True)
    deleted = db.Column('deleted', db.Boolean, default=False)
    user_id = db.Column(db.Integer, db.ForeignKey('users.user_id'))
    files = db.relationship('MediaFile', backref='folder', lazy='dynamic')

    def __init__(self, foldername):
        self.uuid = str(uuid4())
        self.foldername = foldername
        self.added = datetime.utcnow()

    def __repr__(self):
        return '<Mediafolder %r>' % self.foldername


class MediaFile(db.Model):
    __tablename__ = 'media_file'
    id = db.Column('file_id', db.Integer, primary_key=True)
    uuid = db.Column('uuid', db.String(SIZE_UUID), unique=True)
    filename = db.Column('filename', db.String(SIZE_FILENAME), default='')
    filetype = db.Column('filetype', db.String(SIZE_TYPE), default='')
    added = db.Column('added', db.DateTime)
    deleted = db.Column('deleted', db.Boolean, default=False)
    user_id = db.Column(db.Integer, db.ForeignKey('users.user_id'))
    folder_id = db.Column(db.Integer, db.ForeignKey('media_folder.folder_id'))

    def __init__(self, uuid, folder, filename, filetype):
        self.uuid = uuid
        self.folder = folder
        self.filename = filename
        self.filetype = filetype
        self.added = datetime.utcnow()

    def __repr__(self):
        return '<Mediafile %r>' % self.filename
