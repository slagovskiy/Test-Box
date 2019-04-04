from uuid import uuid4
import os
from PIL import Image
from PIL import ImageFont
from PIL import ImageDraw 

BASE_DIR = os.path.dirname(os.path.abspath(__file__))
OUTPUT_DIR = os.path.join(BASE_DIR, 'output')

FILE_ICON_FONT = os.path.join(BASE_DIR, "SaucerBB.ttf")
FILE_ICON_FONT_SIZE = 54
FILE_ICON_TEMPLATE = os.path.join(BASE_DIR, "template.jpg")
FILE_ICON_TEXT_WIDTH = 180
FILE_ICON_TEXT_ROW = 160
FILE_ICON_WIDTH = 300
FILE_ICON_TEXT_COLOR = (100, 100, 100)


def image_write(text):
    img = Image.open(FILE_ICON_TEMPLATE)
    draw = ImageDraw.Draw(img)
    font = ImageFont.truetype(FILE_ICON_FONT, FILE_ICON_FONT_SIZE)
    i = 1
    while font.getsize(text)[0] > FILE_ICON_TEXT_WIDTH:
    	font = ImageFont.truetype(FILE_ICON_FONT, FILE_ICON_FONT_SIZE - i)
    	i+=1
    draw.text(((FILE_ICON_WIDTH/2)-font.getsize(text)[0]/2, FILE_ICON_TEXT_ROW), text, FILE_ICON_TEXT_COLOR, font=font)
    img.save(os.path.join(OUTPUT_DIR, text + '.jpg'))


if __name__ == '__main__':
    image_write('avi')
    image_write('qwer')
    image_write('qwerty')
    image_write('application')
    image_write('mpeg')
    image_write('doc')
    image_write('mp3')
