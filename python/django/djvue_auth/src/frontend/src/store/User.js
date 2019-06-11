import api from '../common/api'

const initState = {
    User: {},
    isAuthenticated: false,
    jwt: localStorage.getItem('jwt_token'),
}

export default {
    initState: initState,
    state: initState,
    mutations: {
        setUser(store, payload) {
            store.User = payload.user
            store.isAuthenticated = payload.isAuthenticated
        },
        updateToken(store, token) {
            if (token != '' && token != null) {
                store.jwt = token
                localStorage.setItem('jwt_token', token)
                api.http.defaults.headers.common['Authorization'] = 'JWT ' + this.getters.jwt
            } else {
                localStorage.removeItem('jwt_token')
                api.http.defaults.headers.common['Authorization'] = ''
            }
        }

    },
    actions: {
        logout({commit}) {
            commit('clearError')
            commit('updateToken', '')
            commit('setUser', {'user': {}, 'isAuthenticated': false})
        },
        login({commit}, payload) {
            commit('clearError')
            commit('setLoading', true)
            return api.http.post(api.getToken, payload)
                .then(
                    (response) => {
                        commit('updateToken', response.data.token)
                    })
                .catch((error) => {
                    if (error.response.status === 400) {
                        commit('setError', 'Wrong username or password.')
                        commit('setLoading', false)
                    } else if (error.response.status === 500) {
                        commit('setError', 'Error on server, please, try again later.')
                        commit('setLoading', false)
                    } else {
                        commit('setError', 'Something going wrong. ' + error.response.statusText)
                        commit('setLoading', false)
                    }
                })
        },
        autoLogin: function ({commit}) {
            commit('clearError')
            commit('setLoading', true)
            if (this.getters.jwt != null && this.getters.jwt != '') {
                api.http.defaults.headers.common['Authorization'] = 'JWT ' + this.getters.jwt
                return api.http.get(api.userInfo, {})
                    .then((response) => {
                        commit("setUser",
                            {user: response.data.data[0], isAuthenticated: true}
                        )
                        commit('setLoading', false)
                    })
                    .catch((error) => {
                        commit('updateToken', '')
                        if (error.response.status === 401) {
                            commit('setError', 'Session time out. Please, login again.')
                            commit('setLoading', false)
                        } else if (error.response.status === 500) {
                            commit('setError', 'Error on server, please, try again later.')
                            commit('setLoading', false)
                        } else {
                            commit('setError', 'Something going wrong. ' + error.response.statusText)
                            commit('setLoading', false)
                        }
                    })
            } else {
                commit('setLoading', false)
            }
        }
    },
    getters: {
        isAuthenticated(state) {
            return state.isAuthenticated
        },
        jwt(state) {
            return state.jwt
        },
        user(state) {
            return state.User
        }
    }
}
