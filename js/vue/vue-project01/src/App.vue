<template>
    <div id="app">
        {{ carName }}
        <app-car
                v-bind:carName="carName"
                v-bind:carYear="carYear"
                v-bind:changeName="changeName"
                v-on:nameChanged="carName = $event"
        ></app-car>
        <app-counter></app-counter>
    </div>
</template>

<script>

    import Car from './components/Car.vue'
    import Counter from './components/Counter.vue'

    export default {
        name: 'app',
        data() {
          return {
              carName: 'Ford',
              carYear: 2018
          }
        },
        methods: {
            changeName() {
                this.carName = 'Audi'
            }
        },
        components: {
            appCar: Car,
            appCounter: Counter
        }
    }
</script>

<style>

</style>
