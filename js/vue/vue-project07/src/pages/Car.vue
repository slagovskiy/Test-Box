<template>
    <div>
        <h1>Car id {{ id }}</h1>

        <button class="btn btn-sm btn-info" v-on:click="gotoCars">Back</button>
        <router-link
                tag="button"
                class="btn btn-sm btn-default"
                v-bind:to="{name: 'carDetail', params: {id: id}, query: {name: 'Ford', year: '2005'}, hash: '#scroll'}"
        >Detail</router-link>
        <hr>
        <router-view></router-view>
    </div>
</template>

<script>
    export default {
        name: "Car",
        data() {
            return {
                id: this.$router.currentRoute.params['id']
            }
        },
        watch: {
            $route (toRoute) {
                this.id = toRoute.params['id']
            }
        },
        methods: {
            gotoCars() {
                this.$router.push('/cars/')
            },
            gotoDetail() {

            }
        },
        beforeRouteLeave(to, from, next) {
            if (window.confirm('Leave?')) {
                next()
            } else {
                next(false)
            }
        }
    }
</script>

<style scoped>

</style>