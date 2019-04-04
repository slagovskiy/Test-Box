<template>
    <div class="login">
        Login: <input type="text" v-model="username" placeholder="Username"><br>
        Password: <input type="password" v-model="password" placeholder="Password"><br>
        <button v-on:click="login">Login</button>
    </div>
</template>

<script>
    import $ from 'jquery'

    export default {
        name: "Login",
        data() {
            return {
                username: '',
                password: '',
            }
        },
        methods: {
            login() {
                $.ajax({
                    url: 'http://127.0.0.1:8000/auth/token/create',
                    type: 'POST',
                    data: {
                        username: this.username,
                        password: this.password
                    },
                    success: (response) => {
                        sessionStorage.setItem('auth_token', response.auth_token)
                        this.$router.push({'name': 'home'})
                    },
                    error: (response) => {
                        if (response.status === 400)
                            alert('login or password is incorrect!')
                        else
                            alert('Error ' + response.status)
                    }
                })
            }
        }
    }
</script>

<style scoped>
    .login {
        margin-right: 50%;
        margin-left: 50%;
        margin-top: 100px;
    }
</style>