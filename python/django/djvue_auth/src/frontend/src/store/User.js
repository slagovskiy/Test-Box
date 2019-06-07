import axios from 'axios'
import apiUrl from '../common/api'


export default {
    state: {
        User: {},
        isAuthenticated: false,
        jwt: localStorage.getItem('jwt_token'),
    },
    mutations: {
        setUser(store, payload) {
            store.User = payload.user
            store.isAuthenticated = payload.isAuthenticated
        },
        updateToken(store, token) {
            store.jwt = token
            localStorage.setItem('jwt_token', token)
        }

    },
    actions: {
        login({commit, dispatch}, payload) {
            axios.post(apiUrl.getToken, payload)
                .then((response) => {
                    commit('updateToken', response.data.token)
                    dispatch('autoLogin')
                })
                /*
                .catch((error) => {

                    //console.log(error);
                    //console.debug(error);
                    //console.dir(error);
                })
                */
        },
        autoLogin({commit}) {
            if (this.getters.jwt!='') {
                const base = {
                    // baseURL: '',
                    headers: {
                        Authorization: 'JWT ' + this.getters.jwt,
                        'Content-Type': 'application/json'
                    },
                    xhrFields: {
                        withCredentials: true
                    }
                }
                const axiosInstance = axios.create(base)
                axiosInstance({
                    url: apiUrl.userInfo,
                    method: "get",
                    params: {}
                })
                    .then((response) => {
                        commit("setUser",
                            {user: response.data.data[0], isAuthenticated: true}
                        )
                    })
                    .catch(() => {
                        commit('updateToken', '')
                    })
            }
        }
    },
    getters: {
        isAuthenticated (state) {
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
