<template>
    <v-app>
        <v-navigation-drawer app temporary v-model="drawer">
            <v-list>
                <v-list-tile>
                    <v-list-tile-content>
                        {{this.$store.getters.user.email}}
                    </v-list-tile-content>
                </v-list-tile>
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
                    <v-icon class="">far fa-smile</v-icon>
                    Application
                </router-link>
            </v-toolbar-title>
            <v-spacer></v-spacer>
            <v-toolbar-title>
                <v-avatar
                size="36px"
                >
                    <img
                        v-if="user.avatar"
                        v-bind:src="this.$config.BASE_URL + user.avatar"
                        v-bind:alt="user.email"
                    >
                </v-avatar>
                {{user.email}}
            </v-toolbar-title>
            <v-toolbar-items class="hidden-sm-and-down">
                <template
                    v-for="item in menu"
                >
                <v-btn flat
                       v-bind:key="item.title"
                       v-bind:to="item.link"
                       v-if="item.auth === isAuthenticated"
                >
                    <v-icon left>{{item.icon}}</v-icon>{{item.title}}
                </v-btn>
                </template>
            </v-toolbar-items>
        </v-toolbar>
        <v-content>
            <v-container fluid>
                <router-view></router-view>
            </v-container>
        </v-content>
        <v-footer app></v-footer>
        <v-snackbar
            v-model="messageShow"
            :bottom="false"
            :left="false"
            :multi-line="false"
            :right="true"
            :timeout="5000"
            :top="true"
            :vertical="false"
        >{{ messageText }}
            <v-btn
                flat
                v-on:click="snackbar = false"
            >
                Close
            </v-btn>
        </v-snackbar>
    </v-app>
</template>

<script>
    export default {
        name: 'app',
        data() {
            return {
                drawer: false,
                snackbar: false,
                snackbar_text: "",
                menu: [
                    {
                        icon: 'fa-sign-in-alt',
                        title: 'Login',
                        link: this.$router.resolve({name: 'user-login'}).href,
                        auth: false
                    },
                    {
                        icon: 'fa-user',
                        title: 'Registration',
                        link: this.$router.resolve({name: 'user-register'}).href,
                        auth: false
                    },
                    {
                        icon: 'fa-key',
                        title: 'Change password',
                        link: this.$router.resolve({name: 'user-password'}).href,
                        auth: true
                    },
                    {
                        icon: 'fa-sign-out-alt',
                        title: 'Logout',
                        link: this.$router.resolve({name: 'user-logout'}).href,
                        auth: true
                    },
                ]
            }
        },
        components: {},
        computed: {
            messageShow: {
                get() {
                    return this.$store.getters.floatMessageShow
                },
                set(){}
            },
            messageText: {
                get() {
                    return this.$store.getters.floatMessageText
                }
            },
            isAuthenticated: {
                get() {
                    return this.$store.getters.isAuthenticated
                },
                set() {}
            },
            user: {
                get() {
                    return this.$store.getters.user
                },
                set() {}
            }
        }
    }
</script>

<style>
    .pointer {
        cursor: pointer;
    }
</style>
