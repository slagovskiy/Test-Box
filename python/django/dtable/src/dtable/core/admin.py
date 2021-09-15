from django.contrib import admin
from .models import db, db_fld, db_indx, db_val


class db_admin(admin.ModelAdmin):
    list_display = ('name', 'uuid',)
    fields = ('uuid', 'name',)
    readonly_fields = ('uuid',)


class db_fld_admin(admin.ModelAdmin):
    list_display = ('name', 'db', 'order')
    fields = ('uuid', 'db', 'name', 'type', 'order', 'deleted')
    readonly_fields = ('uuid',)


class db_idx_admin(admin.ModelAdmin):
    list_display = ('num',)
    fields = ('db', 'num', 'deleted')


class db_val_admin(admin.ModelAdmin):
    list_display = ('nid', 'fld', 'val')
    fields = ('nid', 'fld', 'val')


admin.site.register(db, db_admin)
admin.site.register(db_fld, db_fld_admin)
admin.site.register(db_indx, db_idx_admin)
admin.site.register(db_val, db_val_admin)
