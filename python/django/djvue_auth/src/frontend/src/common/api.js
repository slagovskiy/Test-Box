import axios from 'axios'

var http = axios.create()
if (localStorage.getItem('jwt_token') != null)
    http.defaults.headers.common['Authorization'] = 'JWT ' + localStorage.getItem('jwt_token')
else
    http.defaults.headers.common['Authorization'] = ''
http.defaults.headers.common['Content-Type'] = 'application/json'

const baseUrl = 'http://127.0.0.1:8000/'

const getToken =      baseUrl + 'api/v1/auth/obtain_token/'
const updateToken =   baseUrl + 'api/v1/auth/refresh_token/'
const userInfo =      baseUrl + 'api/v1/user/'

export default {
    http,

    getToken,
    updateToken,
    userInfo,

    baseUrl
}
