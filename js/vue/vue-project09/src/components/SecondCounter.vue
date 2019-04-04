<template>
    <h2>Second counter {{counter}}</h2>
</template>

<script>
    export default {
        name: "Counter",
        computed: {
            counter() {
                return this.$store.getters.modCounter
            }
        }
    }
</script>

<style scoped>

</style>