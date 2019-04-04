<template>
    <div id="app">
        <router-view/>
    </div>
</template>

<script>
    import $ from 'jquery'

    export default {
        name: 'App',
        created() {
            if(localStorage.getItem('auth_token')) {
                $.ajaxSetup({
                    headers: {
                        'Authorization': 'Token ' + localStorage.getItem('auth_token')
                    }
                })
            }
        }
    }
</script>

<style>
    #app {
        font-family: 'Avenir', Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
    }
</style>
