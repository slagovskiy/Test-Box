from django.shortcuts import render
from rest_framework.views import APIView
from rest_framework.response import Response
from rest_framework import permissions
from .models import User
from .serializers import UserSerializer


class APIUser(APIView):
    permission_classes = [permissions.IsAuthenticated,]
    # permission_classes = [permissions.AllowAny,]

    def get(self, request):
        # email = request.GET.get('email')
        email = request.user.email
        user = User.objects.filter(email=email)
        serializer = UserSerializer(user, many=True)
        return Response({
            'data': serializer.data
        })

    def post(self, request):
        user = UserSerializer(data=request.data)
        if user.is_valid():
            user.save()
            return Response({
                'status': 'add'
            })
        else:
            return Response({
                'status': 'error'
            })