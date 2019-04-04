import Vue from 'vue'
import App from './App.vue'
import List from './components/List'

Vue.config.productionTip = false

Vue.filter('upperCase', (value) => value.toUpperCase())

Vue.component('app-list', List)

new Vue({
  render: h => h(App),
}).$mount('#app')
