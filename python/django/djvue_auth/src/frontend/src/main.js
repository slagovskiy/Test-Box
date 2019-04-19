import Vue from 'vue'
import VueRouter from 'vue-router'
import Vuelidate from 'vuelidate'
import Vuetify from 'vuetify'
import 'vuetify/dist/vuetify.min.css'
import Axios from 'axios'

import App from './App.vue'
import store from './store/index'
import router from './routes'


Vue.prototype.$http  =  Axios;
Axios.defaults.xsrfCookieName = 'csrftoken'
Axios.defaults.xsrfHeaderName = 'X-CSRFToken'
const  accessToken  =  localStorage.getItem('access_token')
if (accessToken) {
  Vue.prototype.$http.defaults.headers.common['Authorization'] =  accessToken
}

Vue.use(VueRouter)
Vue.use(Vuetify)
Vue.use(Vuelidate)

Vue.config.productionTip = false

new Vue({
  render: h => h(App),
  store: store,
  router: router
}).$mount('#app')
