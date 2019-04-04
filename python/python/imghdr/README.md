imghdr.py
=========

The imghdr module determines the type of image contained in a file or byte stream for Python3.

The imghdr module defines the following function:

**function: what(filename[, h])**

>Tests the image data contained in the file named by *filename*, and returns a string describing the image type.  If optional *h* is provided, the *filename* is ignored and *h* is assumed to contain the byte stream to test.

The following image types are recognized, as listed below with the return value from `what`:

| Value  | Image format                      |
|--------|:---------------------------------:|
| 'rgb'  | SGI ImgLib Files                  |
| 'gif'  | GIF 87a and 89a Files             |
| 'pbm'  | Portable Bitmap Files             |
| 'pgm'  | Portable Graymap Files            |
| 'ppm'  | Portable Pixmap Files             |
| 'tiff' | TIFF Files                        |
| 'rast' | Sun Raster Files                  |
| 'xbm'  | X Bitmap Files                    |
| 'jpeg` | JPEG data in JFIF or Exif formats |
| 'bmp'  | BMP files                         |
| 'png'  | Portable Network Graphics         |



Example:
```python
>>> import imghdr
>>> imghdr.what('bass.gif')
'gif'
```
