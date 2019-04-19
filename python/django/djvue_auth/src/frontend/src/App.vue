<template>
    <v-app>
        <v-navigation-drawer app temporary v-model="drawer">
            <v-list>
                <v-list-tile
                    v-for="item in menu"
                    v-bind:key="item.title"
                    v-bind:to="item.link"
                >
                    <v-list-tile-action>
                        <v-icon>{{item.icon}}</v-icon>
                    </v-list-tile-action>
                    <v-list-tile-content>
                        <v-list-tile-title>{{item.title}}</v-list-tile-title>
                    </v-list-tile-content>
                </v-list-tile>
            </v-list>
        </v-navigation-drawer>
        <v-toolbar app dark color="primary">
            <v-toolbar-side-icon class="hidden-md-and-up"
                                 v-on:click="drawer = !drawer"
            ></v-toolbar-side-icon>
            <v-toolbar-title>
                <router-link to="/" tag="span" class="pointer">
                    <v-icon>sentiment_satisfied_alt</v-icon>
                    Application
                </router-link>
            </v-toolbar-title>
            <v-spacer></v-spacer>
            <v-toolbar-items class="hidden-sm-and-down">
                <v-btn flat
                       v-for="item in menu"
                       v-bind:key="item.title"
                       v-bind:to="item.link"
                >
                    <v-icon left>{{item.icon}}</v-icon>{{item.title}}
                </v-btn>
            </v-toolbar-items>
        </v-toolbar>
        <v-content>
            <v-container fluid>
                <router-view></router-view>
            </v-container>
        </v-content>
        <v-footer app></v-footer>
    </v-app>
</template>

<script>
    export default {
        name: 'app',
        data() {
            return {
                drawer: false,
                menu: [
                    {
                        icon: 'lock',
                        title: 'Login',
                        link: this.$router.resolve({name: 'user-login'}).href,
                        auth: false
                    },
                    {
                        icon: 'person_add',
                        title: 'Registration',
                        link: this.$router.resolve({name: 'user-register'}).href,
                        auth: false
                    },
                    {
                        icon: 'vpn_key',
                        title: 'Change password',
                        link: this.$router.resolve({name: 'user-password'}).href,
                        auth: true
                    },
                    {
                        icon: 'exit_to_app',
                        title: 'Logout',
                        link: this.$router.resolve({name: 'user-logout'}).href,
                        auth: true
                    },
                ]
            }
        },
        components: {},
        computed: {}
    }
</script>

<style>
    .pointer {
        cursor: pointer;
    }
</style>
