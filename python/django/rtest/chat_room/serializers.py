from rest_framework import serializers
from chat_room.models import Room, Chat
from django.contrib.auth.models import User


class UserSerializer(serializers.ModelSerializer):
    class Meta:
        model = User
        fields = ('id', 'username')


class RoomSerializers(serializers.ModelSerializer):
    creator = UserSerializer()
    invited = UserSerializer(many = True)
    class Meta:
        model = Room
        fields = ('creator', 'invited', 'date')


class ChatSerializers(serializers.ModelSerializer):
    user = UserSerializer()
    class Meta:
        model = Chat
        fields = ('room', 'user', 'text', 'date')


class ChatPostSerializers(serializers.ModelSerializer):
    class Meta:
        model = Chat
        fields = ('room', 'text',)
