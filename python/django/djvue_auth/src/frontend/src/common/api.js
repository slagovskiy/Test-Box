const baseUrl = 'http://127.0.0.1:8000/'

const getToken =      baseUrl + 'api/v1/auth/obtain_token/'
const updateToken =   baseUrl + 'api/v1/auth/refresh_token/'
const userInfo =      baseUrl + 'api/v1/user/'

export default {
    getToken,
    updateToken,
    userInfo,

    baseUrl
}
