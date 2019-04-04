from django.contrib import admin
from .models import db, db_fld, db_indx, db_val


class db_admin(admin.ModelAdmin):
    list_display = ('name',)


class dbfld_admin(admin.ModelAdmin):
    list_display = ('name', 'db', 'order')


class dbidx_admin(admin.ModelAdmin):
    list_display = ('num',)


class dbval_admin(admin.ModelAdmin):
    list_display = ('nid', 'fld', 'val')


admin.site.register(db, db_admin)
admin.site.register(db_fld, dbfld_admin)
admin.site.register(db_indx, dbidx_admin)
admin.site.register(db_val, dbval_admin)
