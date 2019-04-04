from django.contrib import admin
from django.urls import path, include
from chat_room.views import *

urlpatterns = [
    #path('', )
    path('room/', Rooms.as_view()),
    path('dialog/', Dialog.as_view()),

]
