from django.db import models


class db(models.Model):
    name = models.CharField(max_length=50, default='')

    def __str__(self):
        return self.name


class db_fld(models.Model):
    TYPE_NUMERIC = 1
    TYPE_STRING = 2
    TYPE_DATE = 3
    TYPE_IP = 4
    TYPE_PASSWORD = 5
    TYPES = (
        (TYPE_NUMERIC, 'NUMERIC'),
        (TYPE_STRING, 'STRING'),
        (TYPE_DATE, 'DATE'),
        (TYPE_IP, 'IP'),
        (TYPE_PASSWORD, 'PASSWORD')
    )
    db = models.ForeignKey(db)
    name = models.CharField(max_length=50, default='')
    type = models.IntegerField(choices=TYPES)
    order = models.IntegerField(default=10)
    deleted = models.BooleanField(default=False)

    def __str__(self):
        return self.name

    class Meta:
        ordering = ['order']


class db_indx(models.Model):
    db = models.ForeignKey(db)
    num = models.IntegerField(default=0)
    deleted = models.BooleanField(default=False)

    def __str__(self):
        return str(self.num)


class db_val(models.Model):
    nid = models.ForeignKey(db_indx)
    fld = models.ForeignKey(db_fld)
    val = models.CharField(max_length=255, default='')

    def __str__(self):
        return self.val
