from rest_framework import serializers
from .models import User


class UserSerializer(serializers.ModelSerializer):

    class Meta:
        model = User
        fields = ('id', 'email', 'avatar', 'firstname', 'lastname')
        #read_only_fields = ('email',)
