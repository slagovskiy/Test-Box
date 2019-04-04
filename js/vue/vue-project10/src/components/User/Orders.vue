<template>
    <v-container>
        <v-layout row>
            <v-flex xs12 sm6 offset-sm3>
                <h1 class="text--secondary mb-3">Orders</h1>
                <v-list
                        subheader
                        two-line
                >
                    <v-list-tile
                        avatar
                        v-for="order in orders"
                        v-bind:key="order.id"
                    >
                        <v-list-tile-action>
                            <v-checkbox
                                    color="success"
                                    v-bind:input-value="order.done"
                                    v-on:change="markDone(order)"
                            ></v-checkbox>
                        </v-list-tile-action>
                        <v-list-tile-content>
                            <v-list-tile-title>{{order.name}}</v-list-tile-title>
                            <v-list-tile-sub-title>{{order.phone}}</v-list-tile-sub-title>
                        </v-list-tile-content>
                        <v-list-tile-action>
                            <v-btn
                                    v-bind:to="'/ad/' + order.adId"
                                    class="primary"
                            >Open</v-btn>
                        </v-list-tile-action>
                    </v-list-tile>
                </v-list>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
    export default {
        name: "Orders",
        data() {
            return {
                orders: [
                    {
                        id: '1212',
                        name: 'Serjjjl',
                        phone: '8-999-888-1234',
                        adId: '123',
                        done: false
                    }
                ]
            }
        },
        methods: {
            markDone(order) {
                order.done = true
            }
        }
    }
</script>

<style scoped>

</style>