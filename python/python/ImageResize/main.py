import os
from PIL import Image

BASE_DIR = os.path.dirname(os.path.abspath(__file__))
OUTPUT_DIR = os.path.join(BASE_DIR, 'output')


def image_resize(imagefile, type, size):
    source = Image.open(imagefile)
    if type == 'w':
        wpercent = (size/float(source.size[0]))
        hsize = int((float(source.size[1])*float(wpercent)))
        source = source.resize((size, hsize), Image.ANTIALIAS)
    if type == 'h':
        wpercent = (size/float(source.size[1]))
        hsize = int((float(source.size[0])*float(wpercent)))
        source = source.resize((hsize, size), Image.ANTIALIAS)
    if type == 's':
        if source.size[0] < source.size[1]:
            wpercent = (size/float(source.size[0]))
            hsize = int((float(source.size[1])*float(wpercent)))
            source = source.resize((size, hsize), Image.ANTIALIAS)
            left = 0
            top = int((source.size[1]/2)-(size/2))
            right = size
            bottom = int((source.size[1]/2)+(size/2))
            source = source.crop((left, top, right, bottom))
        else:
            wpercent = (size/float(source.size[1]))
            hsize = int((float(source.size[0])*float(wpercent)))
            source = source.resize((hsize, size), Image.ANTIALIAS)
            left = int((source.size[0]/2)-(size/2))
            top = 0
            right = int((source.size[0]/2)+(size/2))
            bottom = size
            source = source.crop((left, top, right, bottom))

    source.save(os.path.join(OUTPUT_DIR, imagefile[0:imagefile.find('.')] + '_' + type + str(size) + '.jpg'))


if __name__ == '__main__':
    image_resize('img_horisontal.jpg', 'w', 600)
    image_resize('img_horisontal.jpg', 'h', 600)
    image_resize('img_horisontal.jpg', 's', 600)
    image_resize('img_vertical.jpg', 'w', 600)
    image_resize('img_vertical.jpg', 'h', 600)
    image_resize('img_vertical.jpg', 's', 600)

    image_resize('img_horisontal.jpg', 'w', 60)
    image_resize('img_horisontal.jpg', 'h', 60)
    image_resize('img_horisontal.jpg', 's', 60)
    image_resize('img_vertical.jpg', 'w', 60)
    image_resize('img_vertical.jpg', 'h', 60)
    image_resize('img_vertical.jpg', 's', 60)
