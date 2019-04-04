from django.contrib import admin
from chat_room.models import Room, Chat


class RoomAdmin(admin.ModelAdmin):
    list_display = ['creator', 'invited_users', 'date']

    def invited_users(self, o):
        return '\n'.join([user.username for user in o.invited.all()])


class ChatAdmin(admin.ModelAdmin):
    list_display = ['room', 'user', 'date']


admin.site.register(Room, RoomAdmin)
admin.site.register(Chat, ChatAdmin)
