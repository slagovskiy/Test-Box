from django.db import models
import uuid

class db(models.Model):
    uuid = models.SlugField(unique=True, verbose_name=u'Key')
    name = models.CharField(max_length=50, default='')

    def __str__(self):
        return self.name

    def save(self, *args, **kwargs):
        if not self.uuid:
            self.uuid = uuid.uuid1()
        super(db, self).save(*args, **kwargs)

    class Meta:
        ordering = ['name']
        verbose_name = u'Table'
        verbose_name_plural = u'Tables'


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
    uuid = models.SlugField(unique=True, verbose_name=u'Key')
    db = models.ForeignKey(db, on_delete=models.CASCADE)
    name = models.CharField(max_length=50, default='')
    type = models.IntegerField(choices=TYPES)
    order = models.IntegerField(default=10)
    deleted = models.BooleanField(default=False)

    def __str__(self):
        return self.name

    def save(self, *args, **kwargs):
        if not self.uuid:
            self.uuid = uuid.uuid1()
        super(db_fld, self).save(*args, **kwargs)

    class Meta:
        ordering = ['db', 'order', 'name']
        verbose_name = u'Field'
        verbose_name_plural = u'Fields'


class db_indx(models.Model):
    db = models.ForeignKey(db, on_delete=models.CASCADE)
    num = models.IntegerField(default=0)
    deleted = models.BooleanField(default=False)

    def __str__(self):
        return str(self.num)

    class Meta:
        ordering = ['db', 'num']
        verbose_name = u'Index'
        verbose_name_plural = u'Indexes'


class db_val(models.Model):
    nid = models.ForeignKey(db_indx, on_delete=models.CASCADE)
    fld = models.ForeignKey(db_fld, on_delete=models.CASCADE)
    val = models.CharField(max_length=255, default='')

    def __str__(self):
        return self.val

    class Meta:
        ordering = ['nid', 'fld', 'val']
        verbose_name = u'Value'
        verbose_name_plural = u'Values'
