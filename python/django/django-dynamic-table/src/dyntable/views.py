from django.shortcuts import render
from dyntable.dtable.models import *

def index(request):
    d = db.objects.all()[0]
    f = db_fld.objects.filter(db=d)
    v = db_val.objects.select_related('nid', 'fld').filter(nid__db=d)
    cnt = {}
    for _v in v:
        if str(_v.nid.num) in cnt:
            cnt[str(_v.nid.num)][_v.fld.name] = _v.val
        else:
            cnt[str(_v.nid.num)] = {_v.fld.name: _v.val}
    content = {
        'flds': f,
        'cnt': cnt
    }
    return render(request, 'index.html', content)
