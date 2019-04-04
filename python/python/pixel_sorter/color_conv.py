"""Conversion functions between RGB and other color systems.

This modules provides two functions for each color system ABC:

  rgb_to_abc(r, g, b) --> a, b, c
  abc_to_rgb(a, b, c) --> r, g, b

All inputs and outputs are triples of floats in the range [0.0...1.0]
(with the exception of I and Q, which covers a slightly larger range).
Inputs outside the valid range may cause exceptions or invalid outputs.

Supported color systems:
RGB: Red, Green, Blue components
YIQ: Luminance, Chrominance (used by composite video signals)
HLS: Hue, Luminance, Saturation
HSV: Hue, Saturation, Value
"""

# References:
# http://en.wikipedia.org/wiki/YIQ
# http://en.wikipedia.org/wiki/HLS_color_space
# http://en.wikipedia.org/wiki/HSV_color_space

__all__ = ["rgb_to_yiq","yiq_to_rgb","rgb_to_hls","hls_to_rgb",
           "rgb_to_hsv","hsv_to_rgb"]

# Some floating point constants

ONE_THIRD = 1.0/3.0
ONE_SIXTH = 1.0/6.0
TWO_THIRD = 2.0/3.0

def rgb_to_grb(r, g, b):
    return (g, r, b)

def rgb_to_gbr(r, g, b):
    return (g, b, r)

def rgb_to_rbg(r, g, b):
    return (r, b, g)

def rgb_to_brg(r, g, b):
    return (b, r, g)

def rgb_to_bgr(r, g, b):
    return (b, g, r)

# YIQ: used by composite video signals (linear combinations of RGB)
# Y: perceived grey level (0.0 == black, 1.0 == white)
# I, Q: color components

def rgb_to_yiq(r, g, b):
    y = 0.299*r + 0.587*g + 0.114*b
    i = 0.596*r - 0.275*g - 0.321*b
    q = 0.212*r - 0.523*g + 0.311*b
    return (y, i, q)

def rgb_to_yqi(r, g, b):
    t = rgb_to_yiq(r, g, b)
    return (t[0], t[2], t[1])

def rgb_to_qyi(r, g, b):
    t = rgb_to_yiq(r, g, b)
    return (t[2], t[0], t[1])

def rgb_to_qiy(r, g, b):
    t = rgb_to_yiq(r, g, b)
    return (t[2], t[1], t[0])

def rgb_to_iqy(r, g, b):
    t = rgb_to_yiq(r, g, b)
    return (t[1], t[2], t[0])

def rgb_to_iyq(r, g, b):
    t = rgb_to_yiq(r, g, b)
    return (t[1], t[0], t[2])

def yiq_to_rgb(y, i, q):
    r = y + 0.948262*i + 0.624013*q
    g = y - 0.276066*i - 0.639810*q
    b = y - 1.105450*i + 1.729860*q
    if r < 0.0:
        r = 0.0
    if g < 0.0:
        g = 0.0
    if b < 0.0:
        b = 0.0
    if r > 1.0:
        r = 1.0
    if g > 1.0:
        g = 1.0
    if b > 1.0:
        b = 1.0
    return (r, g, b)

# YUV model defines a color space in terms of one luma (Y')
# and two chrominance (UV) components.

def rgb_to_yuv(r, g, b):
    y = 0.299*r + 0.587*g + 0.114*b
    u = -0.14713*r - 0.28886*g + 0.436*b + 128
    v = 0.615*r - 0.51499*g - 0.10001*b + 128
    return (y, u, v)

def rgb_to_yvu(r, g, b):
    t = rgb_to_yuv(r, g, b)
    return (t[0], t[2], t[1])

def rgb_to_vyu(r, g, b):
    t = rgb_to_yuv(r, g, b)
    return (t[2], t[0], t[1])

def rgb_to_vuy(r, g, b):
    t = rgb_to_yuv(r, g, b)
    return (t[2], t[1], t[0])

def rgb_to_uyv(r, g, b):
    t = rgb_to_yuv(r, g, b)
    return (t[1], t[0], t[2])

def rgb_to_uvy(r, g, b):
    t = rgb_to_yuv(r, g, b)
    return (t[1], t[2], t[0])

# CIE XYZ
# The cone-shaped space formed by (x, y, z) weights, that
# when applied to the CIE primaries, match any visible color.

def rgb_to_xyz(r, g, b):
    x = 3.240479*r - 1.537150*g - 0.498535*b
    y = -0.969256*r + 1.875992*g + 0.041556*b
    z = 0.055648*r - 0.204043*g + 1.057311*b
    return (x, y, z)

def rgb_to_xzy(r, g, b):
    t = rgb_to_xyz(r, g, b)
    return (t[0], t[2], t[1])

def rgb_to_yxz(r, g, b):
    t = rgb_to_xyz(r, g, b)
    return (t[1], t[0], t[2])

def rgb_to_yzx(r, g, b):
    t = rgb_to_xyz(r, g, b)
    return (t[1], t[2], t[0])

def rgb_to_zxy(r, g, b):
    t = rgb_to_xyz(r, g, b)
    return (t[2], t[0], t[1])

def rgb_to_zyx(r, g, b):
    t = rgb_to_xyz(r, g, b)
    return (t[2], t[1], t[0])

# HLS: Hue, Luminance, Saturation
# H: position in the spectrum
# L: color lightness
# S: color saturation

def rgb_to_hls(r, g, b):
    maxc = max(r, g, b)
    minc = min(r, g, b)
    # XXX Can optimize (maxc+minc) and (maxc-minc)
    l = (minc+maxc)/2.0
    if minc == maxc:
        return 0.0, l, 0.0
    if l <= 0.5:
        s = (maxc-minc) / (maxc+minc)
    else:
        if (2.0-maxc-minc) == 0:
            maxc = maxc + 1
        s = (maxc-minc) / (2.0-maxc-minc)
    rc = (maxc-r) / (maxc-minc)
    gc = (maxc-g) / (maxc-minc)
    bc = (maxc-b) / (maxc-minc)
    if r == maxc:
        h = bc-gc
    elif g == maxc:
        h = 2.0+rc-bc
    else:
        h = 4.0+gc-rc
    h = (h/6.0) % 1.0
    return h, l, s

def rgb_to_hsl(r, g, b):
    t = rgb_to_hls(r, g, b)
    return (t[0], t[2], t[1])

def rgb_to_shl(r, g, b):
    t = rgb_to_hls(r, g, b)
    return (t[2], t[0], t[1])

def rgb_to_slh(r, g, b):
    t = rgb_to_hls(r, g, b)
    return (t[2], t[1], t[0])

def rgb_to_lsh(r, g, b):
    t = rgb_to_hls(r, g, b)
    return (t[1], t[2], t[0])

def rgb_to_lhs(r, g, b):
    t = rgb_to_hls(r, g, b)
    return (t[1], t[0], t[2])

def hls_to_rgb(h, l, s):
    if s == 0.0:
        return l, l, l
    if l <= 0.5:
        m2 = l * (1.0+s)
    else:
        m2 = l+s-(l*s)
    m1 = 2.0*l - m2
    return (_v(m1, m2, h+ONE_THIRD), _v(m1, m2, h), _v(m1, m2, h-ONE_THIRD))

def _v(m1, m2, hue):
    hue = hue % 1.0
    if hue < ONE_SIXTH:
        return m1 + (m2-m1)*hue*6.0
    if hue < 0.5:
        return m2
    if hue < TWO_THIRD:
        return m1 + (m2-m1)*(TWO_THIRD-hue)*6.0
    return m1

# HSV: Hue, Saturation, Value
# H: position in the spectrum
# S: color saturation ("purity")
# V: color brightness

def rgb_to_hsv(r, g, b):
    maxc = max(r, g, b)
    minc = min(r, g, b)
    v = maxc
    if minc == maxc:
        return 0.0, 0.0, v
    s = (maxc-minc) / maxc
    rc = (maxc-r) / (maxc-minc)
    gc = (maxc-g) / (maxc-minc)
    bc = (maxc-b) / (maxc-minc)
    if r == maxc:
        h = bc-gc
    elif g == maxc:
        h = 2.0+rc-bc
    else:
        h = 4.0+gc-rc
    h = (h/6.0) % 1.0
    return h, s, v

def rgb_to_hvs(r, g, b):
    t = rgb_to_hsv(r, g, b)
    return (t[0], t[2], t[1])

def rgb_to_shv(r, g, b):
    t = rgb_to_hsv(r, g, b)
    return (t[1], t[0], t[2])

def rgb_to_svh(r, g, b):
    t = rgb_to_hsv(r, g, b)
    return (t[1], t[2], t[0])

def rgb_to_vhs(r, g, b):
    t = rgb_to_hsv(r, g, b)
    return (t[2], t[0], t[1])

def rgb_to_vsh(r, g, b):
    t = rgb_to_hsv(r, g, b)
    return (t[2], t[1], t[0])

def hsv_to_rgb(h, s, v):
    if s == 0.0:
        return v, v, v
    i = int(h*6.0) # XXX assume int() truncates!
    f = (h*6.0) - i
    p = v*(1.0 - s)
    q = v*(1.0 - s*f)
    t = v*(1.0 - s*(1.0-f))
    i = i%6
    if i == 0:
        return v, t, p
    if i == 1:
        return q, v, p
    if i == 2:
        return p, v, t
    if i == 3:
        return p, q, v
    if i == 4:
        return t, p, v
    if i == 5:
        return v, p, q
    # Cannot get here

cmyk_scale = 100

def rgb_to_cmyk(r,g,b):
    if (r == 0) and (g == 0) and (b == 0):
        # black
        return 0, 0, 0, cmyk_scale

    # rgb [0,255] -> cmy [0,1]
    c = 1 - r / 255.
    m = 1 - g / 255.
    y = 1 - b / 255.

    # extract out k [0,1]
    min_cmy = min(c, m, y)
    c = (c - min_cmy) / (1 - min_cmy)
    m = (m - min_cmy) / (1 - min_cmy)
    y = (y - min_cmy) / (1 - min_cmy)
    k = min_cmy

    # rescale to the range [0,cmyk_scale]
    return c*cmyk_scale, m*cmyk_scale, y*cmyk_scale, k*cmyk_scale

def rgb_to_cmky(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[0], t[1], t[3], t[2])

def rgb_to_cymk(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[0], t[2], t[1], t[3])

def rgb_to_cykm(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[0], t[2], t[3], t[1])

def rgb_to_ckmy(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[0], t[3], t[1], t[2])

def rgb_to_ckym(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[0], t[3], t[2], t[1])

def rgb_to_mcyk(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[1], t[0], t[2], t[3])

def rgb_to_mcky(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[1], t[0], t[3], t[2])

def rgb_to_mkcy(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[1], t[3], t[0], t[2])

def rgb_to_mkyc(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[1], t[3], t[2], t[0])

def rgb_to_mykc(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[1], t[2], t[3], t[0])

def rgb_to_myck(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[1], t[2], t[0], t[3])

def rgb_to_ymck(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[2], t[1], t[0], t[3])

def rgb_to_ymkc(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[2], t[1], t[3], t[0])

def rgb_to_ykmc(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[2], t[3], t[1], t[0])

def rgb_to_ykcm(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[2], t[3], t[0], t[1])

def rgb_to_yckm(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[2], t[0], t[3], t[1])

def rgb_to_ycmk(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[2], t[0], t[1], t[3])

def rgb_to_kycm(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[3], t[2], t[0], t[1])

def rgb_to_kymc(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[3], t[2], t[1], t[0])

def rgb_to_kmyc(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[3], t[1], t[2], t[0])

def rgb_to_kmcy(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[3], t[1], t[0], t[2])

def rgb_to_kcmy(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[3], t[0], t[1], t[2])

def rgb_to_kcym(r, g, b):
    t = rgb_to_cmyk(r,g,b)
    return (t[3], t[0], t[2], t[1])
