<template>
    <v-container>
        <v-layout row>
            <v-flex xs12 sm-6 offset-sm3>
                <h1 class="text--secondary mb-3">Create new ad</h1>
                <v-form v-model="valid" ref="form" lazy-validation class="mb-3">
                    <v-text-field
                            id="title" name="title" label="Ad title" type="text"
                            v-model="title"
                            v-bind:rules="[v => !!v || 'Title is required']"
                    ></v-text-field>
                    <v-textarea
                            id="description" name="description" label="Description" type="text"
                            v-model="description"
                            v-bind:rules="[v => !!v || 'Description is required']"
                    ></v-textarea>
                </v-form>
                <v-layout row class="mb-3">
                    <v-flex xs12>
                        <v-btn class="warning">
                            Upload
                            <v-icon right dark>cloud_upload</v-icon>
                        </v-btn>
                    </v-flex>
                </v-layout>
                <v-layout row>
                    <v-flex xs12>
                        <img src="https://cdn.vuetifyjs.com/images/carousel/squirrel.jpg" height="100">
                    </v-flex>
                </v-layout>
                <v-layout row>
                    <v-flex xs12>
                        <v-switch
                                color="primary"
                                v-model="promo"
                                label="Add to promo"
                        ></v-switch>
                    </v-flex>
                </v-layout>
                <v-layout row>
                    <v-flex xs12>
                        <v-spacer></v-spacer>
                        <v-btn class="success" v-on:click="createAd" v-bind:disabled="!valid">Create Ad</v-btn>
                    </v-flex>
                </v-layout>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
    export default {
        name: "NewAd",
        data() {
            return {
                title: '',
                description: '',
                promo: false,
                valid: false
            }
        },
        methods: {
            createAd() {
                if (this.$refs.form.validate()) {
                    const ad = {
                        title: this.title,
                        description: this.description,
                        imageSrc: 'https://images.gog.com/00b2a353fd8cd69ee310d6588d0b34824f8877684119ee0709d8736dde23be51_bg_crop_1366x655.jpg',
                        promo: this.promo
                    }

                    this.$store.dispatch('createAd', ad)
                }
            }
        }
    }
</script>

<style scoped>

</style>