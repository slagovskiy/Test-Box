import Vue from 'vue'
import VueRouter from 'vue-router'
import Vuelidate from 'vuelidate'
import Vuetify from 'vuetify'
import 'vuetify/dist/vuetify.min.css'
import '@fortawesome/fontawesome-free/css/all.css'
import Axios from 'axios'

import App from './App.vue'
import store from './store/index'
import router from './routes'

Vue.prototype.$http = Axios;
Axios.defaults.xsrfCookieName = 'csrftoken'
Axios.defaults.xsrfHeaderName = 'X-CSRFToken'
const accessToken = localStorage.getItem('access_token')
if (accessToken) {
    Vue.prototype.$http.defaults.headers.common['Authorization'] = accessToken
}

Vue.use(VueRouter)
Vue.use(Vuetify, {
    iconfont: 'fa',
    theme: {
        "primary": "#546e7a", //"#1976D2",
        "secondary": "#424242",
        "accent": "#82B1FF",
        "error": "#FF5252",
        "info": "#2196F3",
        "success": "#4CAF50",
        "warning": "#FB8C00",

    }
})
Vue.use(Vuelidate)

Vue.config.productionTip = false

new Vue({
    render: h => h(App),
    store: store,
    router: router
}).$mount('#app')
