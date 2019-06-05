import axios from 'axios'
import apiUrl from '../common/api'


export default {
    state: {
        authUser: {},
        isAuthenticated: false,
        jwt: localStorage.getItem('token'),
    },
    mutations: {
        auth_success() {

        }

    },
    actions: {
        login({commit}, payload) {
            //console.log('action')
            //console.log(apiUrl.getToken)
            //console.log(payload)
            axios.post(apiUrl.getJWT, payload)
                .then((response) => {
                    localStorage.setItem('token', response.data.token)
                    //console.log(response.data.token)
                    //this.$store.commit('updateToken', response.data.token)
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
