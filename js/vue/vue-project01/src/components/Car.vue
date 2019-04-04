<template>
    <div class="car">
        <h3>Name: {{ carName }}</h3>
        <p>Year: {{ carYear }}</p>
        <p>{{ reverseName }}</p>
        <button v-on:click="changeName">Change name</button>
        <button v-on:click="updateCounter">Add counter</button>
    </div>
</template>

<script>
    import {eventEmitter} from "../main";

    export default {
        name: "Car",
        props: {
            carName: {
                type: String,
                required: true,
                default: '_'
            },
            carYear: {
                type: Number,
                default: -1
            },
            changeName: Function
        },
        computed: {
            reverseName() {
                return this.carName.split('').reverse().join('')
            },
        },
        methods: {
            updateCounter() {
                //this.$emit('counterUpdated', this.counter+1)
                eventEmitter.$emit('counterUpdated', 5)
            }
        },
        data() {
            return {

            }
        }
    }
</script>

<style scoped>
    .car {
        border: 1px solid gray;
        border-radius: 10px;
        margin: 10px;
        padding: 10px;
    }
</style>