from django.shortcuts import render
from rest_framework.views import APIView
from rest_framework.response import Response
from rest_framework import permissions
from chat_room.models import Room, Chat
from chat_room.serializers import RoomSerializers, ChatSerializers, ChatPostSerializers


class Rooms(APIView):
    def get(self, request):
        rooms = Room.objects.all()
        serializer = RoomSerializers(rooms, many=True)
        return Response({
            'data': serializer.data
        })


class Dialog(APIView):
    permission_classes = [permissions.IsAuthenticated,]
    #permission_classes = [permissions.AllowAny,]

    def get(self, request):
        room = request.GET.get('room')
        chats = Chat.objects.filter(room=room)
        serializer = ChatSerializers(chats, many=True)
        return Response({
            'data': serializer.data
        })

    def post(self, request):
        dialog = ChatPostSerializers(data=request.data)
        if dialog.is_valid():
            dialog.save(user=request.user)
            return Response({
                'status': 'add'
            })
        else:
            return Response({
                'status': 'error'
            })