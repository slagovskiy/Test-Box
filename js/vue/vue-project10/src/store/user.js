import * as fb from 'firebase'

class User {
    constructor(id){
        this.id = id
    }
}

export default {
    state: {
        user: null
    },
    mutations: {
        setUser(state, payload) {
            state.user = payload
        }
    },
    actions: {
        registerUser({commit}, payload) {
            fb.auth().createUserWithEmailAndPassword(payload.email, payload.password)
                .then(user => {
                    //uid
                    commit('setUser', new User(user.uid))
                })
        }
    },
    getters: {
        user(state) {
            return state.user
        }
    }
}