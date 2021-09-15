# Generated by Django 3.2.7 on 2021-09-15 07:57

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='db',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('uuid', models.SlugField(unique=True, verbose_name='Key')),
                ('name', models.CharField(default='', max_length=50)),
            ],
            options={
                'verbose_name': 'Table',
                'verbose_name_plural': 'Tables',
                'ordering': ['name'],
            },
        ),
        migrations.CreateModel(
            name='db_fld',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('uuid', models.SlugField(unique=True, verbose_name='Key')),
                ('name', models.CharField(default='', max_length=50)),
                ('type', models.IntegerField(choices=[(1, 'NUMERIC'), (2, 'STRING'), (3, 'DATE'), (4, 'IP'), (5, 'PASSWORD')])),
                ('order', models.IntegerField(default=10)),
                ('deleted', models.BooleanField(default=False)),
                ('db', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='core.db')),
            ],
            options={
                'verbose_name': 'Field',
                'verbose_name_plural': 'Fields',
                'ordering': ['db', 'name'],
            },
        ),
        migrations.CreateModel(
            name='db_indx',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('num', models.IntegerField(default=0)),
                ('deleted', models.BooleanField(default=False)),
                ('db', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='core.db')),
            ],
            options={
                'verbose_name': 'Index',
                'verbose_name_plural': 'Indexes',
                'ordering': ['db', 'num'],
            },
        ),
        migrations.CreateModel(
            name='db_val',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('val', models.CharField(default='', max_length=255)),
                ('fld', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='core.db_fld')),
                ('nid', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='core.db_indx')),
            ],
            options={
                'verbose_name': 'Value',
                'verbose_name_plural': 'Values',
                'ordering': ['nid', 'fld', 'val'],
            },
        ),
    ]
