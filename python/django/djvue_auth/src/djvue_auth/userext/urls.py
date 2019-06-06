from django.urls import path
from .views import APIUser


urlpatterns = [
    path('', APIUser.as_view()),
]