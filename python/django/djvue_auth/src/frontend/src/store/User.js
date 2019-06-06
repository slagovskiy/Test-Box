import axios from 'axios'
import apiUrl from '../common/api'


export default {
    state: {
        authUser: {},
        isAuthenticated: false,
        jwt: localStorage.getItem('jwt_token'),
    },
    mutations: {
        auth_success() {

        },
        updateToken(store, token) {
            store.jwt = token
            localStorage.setItem('jwt_token', token)
        }

    },
    actions: {
        login({commit}, payload) {
            axios.post(apiUrl.getToken, payload)
                .then((response) => {
                    this.$store.commit('updateToken', response.data.token)
                    /*
                    const base = {
                        baseURL: this.$store.state.endpoints.baseUrl,
                        headers: {
                            // Set your Authorization to 'JWT', not Bearer!!!
                            Authorization: `JWT ${this.$store.state.jwt}`,
                            'Content-Type': 'application/json'
                        },
                        xhrFields: {
                            withCredentials: true
                        }
                    }
                    const axiosInstance = axios.create(base)
                    axiosInstance({
                        url: "/user/",
                        method: "get",
                        params: {}
                    })
                        .then((response) => {
                            this.$store.commit("setAuthUser",
                                {authUser: response.data, isAuthenticated: true}
                            )
                            this.$router.push({name: 'Home'})
                        })
                    */
                })
                /*
                .catch((error) => {

                    //console.log(error);
                    //console.debug(error);
                    //console.dir(error);
                })
                */
        },
    },
    getters: {
        isAuthenticated: state => !!state.token
    }
}
