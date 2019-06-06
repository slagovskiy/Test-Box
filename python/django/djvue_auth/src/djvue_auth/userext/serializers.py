from rest_framework import serializers
from .models import User


class UserSerializer(serializers.ModelSerializer):

    class Meta:
        model = User
        fields = ('id',) #, 'avatar', 'firstname', 'lastname', 'register_date', 'is_active', 'is_admin')
        #read_only_fields = ('email',)
