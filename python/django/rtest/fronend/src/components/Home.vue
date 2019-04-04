<template>
    <div>
        <h1>Chat!</h1>
        <button v-on:click="gotoLogin">Login</button>
        <room></room>
    </div>
</template>

<script>
    import Room from './Room'
    export default {
        name: 'Home',
        props: {
        },
        components: {
            Room
        },
        methods: {
            gotoLogin() {
                this.$router.push({ name: 'login' })
            }
        }
    }
</script>

<style scoped>

</style>
