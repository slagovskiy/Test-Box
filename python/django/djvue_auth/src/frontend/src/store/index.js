import Vue from 'vue'
import Vuex from 'vuex'
import User from './User'
import Global from './Global'

Vue.use(Vuex)

export default new Vuex.Store({
    modules: {
        user: User,
        global: Global
    },
    state: {},
    getters: {},
    mutations: {},
    actions: {}
})
