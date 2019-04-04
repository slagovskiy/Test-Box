import os


basedir = os.path.abspath(os.path.dirname(__file__))

CSRF_ENABLED = True
SECRET_KEY = 'nbjhs0d97f8ge6h9df5h7d6haj90'

SQLALCHEMY_DATABASE_URI = 'sqlite:///' + os.path.join(basedir, 'base.sqlite')
SQLALCHEMY_MIGRATE_REPO = os.path.join(basedir, 'db_repository')

WHOOSH_BASE = os.path.join(basedir, 'db_search')
MAX_SEARCH_RESULTS = 50

OPENID_PROVIDERS = [
    { 'name': 'Google', 'url': 'https://www.google.com/accounts/o8/id' },
    { 'name': 'Yahoo', 'url': 'https://me.yahoo.com' },
    { 'name': 'AOL', 'url': 'http://openid.aol.com/<username>' },
    { 'name': 'Flickr', 'url': 'http://www.flickr.com/<username>' },
    { 'name': 'MyOpenID', 'url': 'https://www.myopenid.com' }
]

MAIL_SERVER = 'localhost'
MAIL_PORT = 25
MAIL_USE_TLS = False
MAIL_USE_SSL = False
MAIL_USERNAME = 'admin'
MAIL_PASSWORD = 'admin'

ADMINS = ['admin@localhost.local']

POSTS_PER_PAGE = 3

LANGUAGES = {
    'en': 'English',
    'ru': 'Russian'
}
