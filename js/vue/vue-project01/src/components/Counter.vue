<template>
    <div>
        <h1>Counter: {{ counter }}</h1>
    </div>
</template>

<script>
    import {eventEmitter} from "../main"

    export default {
        name: "Counter",
        data() {
            return {
                counter: 0
            }
        },
        created() {
            eventEmitter.$on('counterUpdated', (num) => {
                this.counter += num;
            })
        }
    }
</script>

<style scoped>

</style>