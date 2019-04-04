<template>
    <h2>Counter {{counter.counter}}</h2>
</template>

<script>
    export default {
        name: "Counter",
        computed: {
            counter() {
                return this.$store.state.counter
            }
        }
    }
</script>

<style scoped>

</style>