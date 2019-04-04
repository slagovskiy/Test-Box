from django.db import models
from django.contrib.auth.models import User


class Room(models.Model):
    '''
    Room model
    '''
    creator = models.ForeignKey(User, on_delete=models.CASCADE)
    invited = models.ManyToManyField(User, related_name='invited_user')
    date = models.DateTimeField(auto_now_add=True)


class Chat(models.Model):
    '''
    Chat Message Model
    '''
    room = models.ForeignKey(Room, on_delete=models.CASCADE)
    user = models.ForeignKey(User, on_delete=models.CASCADE)
    text = models.TextField(max_length=500)
    date = models.DateTimeField(auto_now_add=True)
