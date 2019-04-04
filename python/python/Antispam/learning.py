import antispam
import sqlite3
from transliterate import translit


d = antispam.Detector('model.dat')

conn = sqlite3.connect('learning.db')
c = conn.cursor()

for row in c.execute('SELECT * FROM base'):
    text = translit(row[1], 'ru', reversed=True)
    print(text)
    spam = True
    if row[0] == 1:
        spam = False
    d.train(text, spam)

for row in c.execute('SELECT * FROM habr'):
    text = translit(row[0], 'ru', reversed=True)
    print(text)
    spam = False
    d.train(text, spam)

for row in c.execute('SELECT * FROM stop'):
    text = translit(row[0], 'ru', reversed=True)
    print(text)
    spam = True
    d.train(text, spam)

d.save()
