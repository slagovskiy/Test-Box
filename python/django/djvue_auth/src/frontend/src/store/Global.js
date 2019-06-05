export default {
    state: {
        _floatMessageShow: false,
        _floatMessageText: ''
    },
    mutations: {
        showMessage(state, payload){
            state._floatMessageShow = true
            state._floatMessageText = payload
        }
    },
    actions: {
        showMessage(state, payload) {
            state.commit('showMessage', payload)
        }
    },
    getters: {
        floatMessageShow(state){
            return state._floatMessageShow
        },
        floatMessageText(state){
            return state._floatMessageText
        }
    }
}
