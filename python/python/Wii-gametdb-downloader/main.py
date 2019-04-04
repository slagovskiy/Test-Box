import os
import urllib.request

WIIDB = {
    'EN': 'http://www.gametdb.com/wiitdb.txt?LANG=EN',
    #'RU': 'http://www.gametdb.com/wiitdb.txt?LANG=RU',
    #'JA': 'http://www.gametdb.com/wiitdb.txt?LANG=JA',
}

COVER = {
    'COVER': 'http://art.gametdb.com/wii/cover/',
    'COVER3D': 'http://art.gametdb.com/wii/cover3D/',
    'COVERFULL': 'http://art.gametdb.com/wii/coverfull/',
    'COVER2': 'http://art.gametdb.com/wii/cover/',
    'COVER3D2': 'http://art.gametdb.com/wii/cover3D/',
    'COVERFULL2': 'http://art.gametdb.com/wii/coverfull/',
    'COVERB': 'http://art.gametdb.com/wii/coverB/',
    'COVER3DB': 'http://art.gametdb.com/wii/cover3DB/',
    'DISC': 'http://art.gametdb.com/wii/disc/',
    'DISCCUSTOM': 'http://art.gametdb.com/wii/disccustom/',
    'DISC2': 'http://art.gametdb.com/wii/disc/',
    'DISCCUSTOM2': 'http://art.gametdb.com/wii/disccustom/',
}

directory = os.path.join(os.path.dirname(os.path.abspath(__file__)), 'DATA')
if not os.path.exists(directory):
    os.makedirs(directory)
for lang, urldb in WIIDB.items():
    print('DOWNLOAD DB: ' + urldb)
    db = ''
    try:
        response = urllib.request.urlopen(urldb)
        data = response.read()
        directory = os.path.join(os.path.join(os.path.dirname(os.path.abspath(__file__)), 'DATA'), lang)
        if not os.path.exists(directory):
            os.makedirs(directory)
        i = 1
        data = data.decode('utf-8').split('\r\n')[1:]
        for item in data:
            disc = item.split(' = ')[0]
            if disc:
                print('  DOWNLOAD COVERS FOR DISC ' + disc + ' [' + lang + '] ' + str(i) + ' from ' + str(len(data)))
                for cover, coverurl in COVER.items():
                    try:
                        directory = os.path.join(os.path.join(os.path.join(os.path.dirname(os.path.abspath(__file__)), 'DATA'), lang), cover)
                        if not os.path.exists(directory):
                            os.makedirs(directory)
                        url = coverurl + lang + '/' + disc + '.png'
                        file = os.path.join(directory, disc + '.png')
                        urllib.request.urlretrieve(url, file)
                        print('    ' + cover + ' - OK')
                    except:
                        print('    ' + cover + ' - none')
                i += 1
    except:
        print('ERROR DOWNLOAD DB ' + url)
