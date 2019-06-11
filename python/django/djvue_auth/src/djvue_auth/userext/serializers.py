from rest_framework import serializers
from .models import User


class UserSerializer(serializers.ModelSerializer):
    """
    Serializer for user
    """
    class Meta:
        model = User
        fields = ('id', 'email', 'avatar', 'firstname', 'lastname')


class ChangePasswordSerializer(serializers.Serializer):
    """
    Serializer for password change
    """
    old_password = serializers.CharField(required=True)
    new_password = serializers.CharField(required=True)


class AvatarSerializer(serializers.Serializer):
    """
    Serializer for image
    """
    avatar = serializers.ImageField()
