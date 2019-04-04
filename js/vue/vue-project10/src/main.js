import Vue from 'vue'
import * as fb from 'firebase'
import App from './App.vue'
import store from './store'
import Vuetify from 'vuetify'
import 'vuetify/dist/vuetify.min.css'

import router from './routes'

Vue.use(Vuetify)
Vue.config.productionTip = false

new Vue({
  render: h => h(App),
  router: router,
  store: store,
  create() {
    var config = {
      apiKey: "AIzaSyBMW7neWyLnTKZgaFsM7r2xc_GS79tBKL0",
      authDomain: "vue-project10.firebaseapp.com",
      databaseURL: "https://vue-project10.firebaseio.com",
      projectId: "vue-project10",
      storageBucket: "vue-project10.appspot.com",
      messagingSenderId: "435945755251"
    }
    fb.initializeApp(config);
  }
}).$mount('#app')
