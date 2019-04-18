import Vue from 'vue'
import Vuex from 'vuex'
import User from './User'

Vue.use(Vuex)

export default new Vuex.Store({
    modules: {
        user: User
    },
    state: {},
    getters: {},
    mutations: {},
    actions: {}
})