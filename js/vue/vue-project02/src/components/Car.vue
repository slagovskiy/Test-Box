<template>
    <div class="car">
        <h2>Car: {{ carName }}</h2>
        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Id, nostrum!</p>
    </div>
</template>

<script>
    import {eventEmitter} from "../main";

    export default {
        name: "Car",
        props: {
            carName: {
                type: String
            }
        }
    }
</script>

<style scoped>
    .car {
        border: 1px solid lightskyblue;
        border-radius: 10px;
        margin: 10px;
        padding: 10px;
    }
</style>