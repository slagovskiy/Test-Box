<template>
    <v-container>
        <v-layout row>
            <v-flex xs12 sm6 offset-sm3>
                <h1 class="text--secondary mb-3">Ad List</h1>
                <v-card v-for="ad in myAds" v-bind:key="ad.id" class="elevation-10 mb-3">
                    <v-layout row>
                        <v-flex vs4>
                            <v-img v-bind:src="ad.imageSrc" height="175px"></v-img>
                        </v-flex>
                        <v-flex vs8>
                            <v-card-text>
                                <h2 class="text--primary">{{ad.title}}</h2>
                                <p>{{ad.description}}</p>
                            </v-card-text>
                            <v-card-actions>
                                <v-spacer></v-spacer>
                                <v-btn class="info" v-bind:to="'/ad/' + ad.id">Open</v-btn>
                            </v-card-actions>
                        </v-flex>
                    </v-layout>
                </v-card>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
    export default {
        name: "AdList",
        data() {
            return {

            }
        },
        computed: {
            myAds() {
                return this.$store.getters.myAds
            }
        }
    }
</script>

<style scoped>

</style>