# Generated by Django 2.2 on 2019-06-05 08:34

from django.db import migrations, models
import djvue_auth.userext.models


class Migration(migrations.Migration):

    initial = True

    dependencies = [
        ('auth', '0011_update_proxy_permissions'),
    ]

    operations = [
        migrations.CreateModel(
            name='User',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('password', models.CharField(max_length=128, verbose_name='password')),
                ('last_login', models.DateTimeField(blank=True, null=True, verbose_name='last login')),
                ('is_superuser', models.BooleanField(default=False, help_text='Designates that this user has all permissions without explicitly assigning them.', verbose_name='superuser status')),
                ('email', models.EmailField(db_index=True, max_length=255, unique=True, verbose_name='Email')),
                ('avatar', models.ImageField(blank=True, null=True, upload_to=djvue_auth.userext.models.User.avatar_path, verbose_name='Avatar')),
                ('firstname', models.CharField(blank=True, max_length=40, null=True, verbose_name='First name')),
                ('lastname', models.CharField(blank=True, max_length=40, null=True, verbose_name='Last name')),
                ('register_date', models.DateField(auto_now_add=True, verbose_name='Register')),
                ('is_active', models.BooleanField(default=True, verbose_name='is active')),
                ('is_admin', models.BooleanField(default=False, verbose_name='is admin')),
                ('groups', models.ManyToManyField(blank=True, help_text='The groups this user belongs to. A user will get all permissions granted to each of their groups.', related_name='user_set', related_query_name='user', to='auth.Group', verbose_name='groups')),
                ('user_permissions', models.ManyToManyField(blank=True, help_text='Specific permissions for this user.', related_name='user_set', related_query_name='user', to='auth.Permission', verbose_name='user permissions')),
            ],
            options={
                'verbose_name': 'User',
                'verbose_name_plural': 'Users',
            },
        ),
    ]