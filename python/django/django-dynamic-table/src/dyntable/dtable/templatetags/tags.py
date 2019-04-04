from django import template

register = template.Library()


@register.filter
def get_item(dictionary, key):
    tmp = dictionary.get(key)
    if tmp == None:
        return ''
    else:
        return tmp
