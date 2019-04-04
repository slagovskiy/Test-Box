<template>
  <div id="app" class="container text-center pt-5">
    <app-counter></app-counter>
    <app-second-counter></app-second-counter>
    <app-actions></app-actions>
  </div>
</template>

<script>
import Counter from './components/Counter.vue'
import SecondCounter from './components/SecondCounter'
import Actions from './components/Actions.vue'

export default {
  name: 'app',
  data() {
    return {
      counter: 0
    }
  },
  components: {
    appCounter: Counter,
    appSecondCounter: SecondCounter,
    appActions: Actions
  }
}
</script>

<style>

</style>
