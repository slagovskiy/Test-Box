try:
    from BeautifulSoup import BeautifulSoup
except ImportError:
    from bs4 import BeautifulSoup
import urllib.request
import re
import sqlite3
import os
from os import listdir
from os.path import isfile, join


conn = sqlite3.connect('learning.db')
c = conn.cursor()
c.execute('DELETE FROM habr;')
conn.commit()

habrdir = os.path.join(os.path.dirname(os.path.abspath(__file__)), 'habr')
files = [f for f in listdir(habrdir) if isfile(join(habrdir, f))]

for f in files:
    with open(os.path.join(habrdir, f), 'r', encoding='utf-8') as file:
        html = file.read()
    soup = BeautifulSoup(html, 'html.parser')
    for m in soup.find_all('div', attrs={'class': 'comment__message'}):
        try:
            text = m.text
            if m.text != '':
                text = m.text.replace('"', '')
            c.execute('INSERT INTO habr VALUES ("' + text + '")')
        except:
            print('ERROR: ', f)
    print('OK: ', f)
    conn.commit()
