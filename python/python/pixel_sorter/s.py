from PIL import Image
import color_conv
import hilbert
import math
import os
import sys


basedir = os.path.abspath(os.path.dirname(__file__))
if not os.path.exists(os.path.join(basedir, 'result')):
    os.mkdir(os.path.join(basedir, 'result'))

resultdir = os.path.join(basedir, 'result')

if len(sys.argv) > 1:
    imagefile = sys.argv[1]
else:
    print("file not found")
    quit()

if len(sys.argv) > 2:
    maxsize  = int(sys.argv[2])
else:
    maxsize = 350

source = Image.open(imagefile)
if maxsize != -1:
    if source.size[0]>source.size[1]:
        wpercent = (maxsize/float(source.size[0]))
        hsize = int((float(source.size[1])*float(wpercent)))
        source = source.resize((maxsize,hsize), Image.ANTIALIAS)
    else:
        wpercent = (maxsize/float(source.size[1]))
        hsize = int((float(source.size[0])*float(wpercent)))
        source = source.resize((hsize,maxsize), Image.ANTIALIAS)
source.save(os.path.join(resultdir, 'img_src.jpg'))

colors = source.getcolors(source.size[0] * source.size[1])
pixels = []
for i, color in colors:
    pixels.extend(i * [color])



px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_cmyk(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_cmyk.jpg"))
print ('cmyk')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_cmky(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_cmky.jpg"))
print ('cmky')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_ckmy(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_ckmy.jpg"))
print ('ckmy')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_ckym(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_ckym.jpg"))
print ('ckym')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_cykm(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_cykm.jpg"))
print ('cykm')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_cymk(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_cymk.jpg"))
print ('cymk')


px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_mcyk(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_mcym.jpg"))
print ('mcyk')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_mcky(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_mcky.jpg"))
print ('mcky')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_myck(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_myck.jpg"))
print ('myck')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_mykc(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_mykc.jpg"))
print ('mykc')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_mkyc(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_mkyc.jpg"))
print ('mkyc')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_mkcy(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_mkcy.jpg"))
print ('mkcy')



px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_yckm(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_yckm.jpg"))
print ('yckm')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_ycmk(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_ycmk.jpg"))
print ('ycmk')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_ymck(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_ymck.jpg"))
print ('ymck')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_ymkc(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_ymkc.jpg"))
print ('ymkc')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_ykmc(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_ykmc.jpg"))
print ('ykmc')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_ykcm(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_ykcm.jpg"))
print ('ykcm')



px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_kycm(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_kycm.jpg"))
print ('kycm')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_kymc(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_kymc.jpg"))
print ('kymc')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_kcym(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_kcym.jpg"))
print ('kcym')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_kcmy(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_kcmy.jpg"))
print ('kcmy')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_kmyc(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_kmyc.jpg"))
print ('kmyc')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_kmcy(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_kmcy.jpg"))
print ('kmcy')


px = pixels[:]
px.sort()
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_rgb.jpg"))
print ('rgb')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_rbg(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_rbg.jpg"))
print ('rbg')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_brg(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_brg.jpg"))
print ('brg')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_bgr(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_bgr.jpg"))
print ('bgr')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_grb(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_grb.jpg"))
print ('grb')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_gbr(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_gbr.jpg"))
print ('gbr')

'''
px = pixels[:]
px.sort(key=hilbert.Hilbert_to_int)
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_hlb.jpg")
print ('hlb')
'''
px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_yiq(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_yiq.jpg"))
print ('yiq')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_yqi(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_yqi.jpg"))
print ('yqi')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_iyq(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_iyq.jpg"))
print ('iyq')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_iqy(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_iqy.jpg"))
print ('iqy')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_qiy(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_qiy.jpg"))
print ('qiy')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_qyi(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_qyi.jpg"))
print ('qyi')


px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_xyz(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_xyz.jpg"))
print ('xyz')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_xzy(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_xzy.jpg"))
print ('xzy')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_yxz(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_yxz.jpg"))
print ('yxz')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_yzx(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_yzx.jpg"))
print ('yzx')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_zxy(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_zxy.jpg"))
print ('zxy')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_zyx(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_zyx.jpg"))
print ('zyz')


px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_hsv(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_hsv.jpg"))
print ('hsv')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_hvs(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_hvs.jpg"))
print ('hvs')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_shv(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_shv.jpg"))
print ('shv')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_svh(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_svh.jpg"))
print ('svh')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_vsh(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_vsh.jpg"))
print ('vsh')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_vhs(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_vhs.jpg"))
print ('vhs')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_hls(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_hls.jpg"))
print ('hls')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_hsl(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_hsl.jpg"))
print ('hsl')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_lsh(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_lsh.jpg"))
print ('lsh')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_lhs(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_lhs.jpg"))
print ('lhs')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_slh(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_slh.jpg"))
print ('slh')

px = pixels[:]
px.sort(key=lambda rgb: color_conv.rgb_to_shl(*rgb))
new = Image.new('RGB', source.size)
new.putdata(px)
new.save(os.path.join(resultdir, "img_shl.jpg"))
print ('shl')
