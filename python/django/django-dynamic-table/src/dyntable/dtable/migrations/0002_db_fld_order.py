# -*- coding: utf-8 -*-
# Generated by Django 1.11.4 on 2017-08-03 04:56
from __future__ import unicode_literals

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('dtable', '0001_initial'),
    ]

    operations = [
        migrations.AddField(
            model_name='db_fld',
            name='order',
            field=models.IntegerField(default=10),
        ),
    ]
