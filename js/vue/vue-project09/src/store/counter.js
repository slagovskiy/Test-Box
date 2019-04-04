export default {
    state: {
        counter: 0
    },
    mutations: {
        changeCounter(state, payload) {
            return state.counter += payload
        }
    },
    actions: {
        asyncChangeCounter(context, payload) {
            setTimeout(() => {
                context.commit('changeCounter', payload.counterValue)
            }, payload.delay)
        }
    },
    getters: {
        modCounter(state) {
            return state.counter * Math.random()
        }
    }
}