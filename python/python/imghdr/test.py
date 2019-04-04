from imghdr import what

print('is it BMP?', what('test.bmp'))

print('is it GIF?', what('test.gif'))

print('is it JPG?', what('test.jpg'))

print('is it PNG?', what('test.png'))

print('is it TIFF?', what('test.tif'))

print('is it Image?', what('test.txt'))

print('is it Image?', what('test.test'))
