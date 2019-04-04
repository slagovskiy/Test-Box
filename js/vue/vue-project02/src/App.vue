<template>
    <div id="app">
        <app-car carName="Ford"></app-car>
        <app-counter>
            <div slot="title">Counter</div>
            <div slot="count">{{ counter }}</div>
        </app-counter>
    </div>
</template>

<script>

    import Car from './components/Car.vue'
    import Counter from './components/Counter.vue'

    export default {
        name: 'app',
        data() {
            return {
                counter: 100
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
