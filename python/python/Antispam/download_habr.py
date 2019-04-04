#https://habr.com/post/100000/
import os
import urllib.request

import argparse
parser = argparse.ArgumentParser()
parser.add_argument('--start', help='start')
parser.add_argument('--stop', help='stop')
args = parser.parse_args()

start = 1
stop = 100000

try:
    start = int(args.start)
    stop = int(args.stop)
except:
    pass


for i in range(start, stop):
    html = ''
    path = os.path.join(os.path.join(os.path.dirname(os.path.abspath(__file__)), 'habr'), str(i) + '.txt')
    if not (os.path.exists(path)):
        print('Download ', str(i))
        try:
            with urllib.request.urlopen('https://habr.com/post/' + str(i) + '/') as response:
                html = response.read()
                print('Save ', str(i))
                with open(path, 'wb+') as file:
                    file.write(html)
        except:
            print('Error ', str(i))
            with open(path, 'wb+') as file:
                file.write(b'<html><body></body></html>')
    else:
        print('Skip ', str(i))
