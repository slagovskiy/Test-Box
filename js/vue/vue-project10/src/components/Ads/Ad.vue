<template>
    <v-container>
        <v-layout row>
            <v-flex xs12>
                <v-card class="elevation-10">
                    <v-img
                        v-bind:src="ad.imageSrc"
                        height="300px"
                    ></v-img>
                    <v-card-text>
                        <h1 class="text--primary">{{ad.title}}</h1>
                        <p>{{ad.description}}</p>
                    </v-card-text>
                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn class="warning">edit</v-btn>
                        <v-btn class="success">buy</v-btn>
                    </v-card-actions>
                </v-card>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
    export default {
        name: "Ad",
        props: {
            id: {
                type: String
            }
        },
        data() {
            return {

            }
        },
        computed: {
            ad() {
                const id = this.id
                return this.$store.getters.adById(id)
            }
        }
    }
</script>

<style scoped>

</style>