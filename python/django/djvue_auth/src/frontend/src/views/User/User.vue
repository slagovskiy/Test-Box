<template>
    <v-container grid-list-md fill-height>
        <v-layout row wrap v-if="isAuthenticated">
            <v-flex xs4>
                <v-card>
                    <template v-if="user.avatar">
                        <v-img
                            v-bind:src="this.$config.BASE_URL + user.avatar"
                            height="125px"
                            contain
                        ></v-img>
                    </template>
                    <v-card-actions>
                        <v-spacer/>
                        <v-btn color="primary" v-on:click="dialogAvatar = true">Change avatar</v-btn>
                        <v-spacer/>
                    </v-card-actions>
                </v-card>
                <template>
                    <v-layout row justify-center>
                        <v-dialog v-model="dialogAvatar" persistent max-width="290">
                            <v-form v-model="validAvatar" ref="formAvatar" lazy-validation
                                    enctype="multipart/form-data">
                                <v-card>
                                    <v-card-title class="headline">Select image</v-card-title>
                                    <v-card-text class="text-md-center">
                                        <img
                                            v-bind:src="imageUrl"
                                            height="125px"
                                            v-if="imageUrl"
                                        />
                                        <v-text-field
                                            label="Select Image"
                                            v-on:click='pickFile'
                                            v-model='imageName'
                                            v-bind:rules="avatarRules"
                                            prepend-icon='attach_file'
                                            ref="imageText"
                                        ></v-text-field>
                                        <input
                                            name="file"
                                            type="file"
                                            style="display: none"
                                            ref="image"
                                            accept="image/*"
                                            v-on:change="onFilePicked"
                                        >
                                    </v-card-text>
                                    <v-card-actions>
                                        <v-spacer></v-spacer>
                                        <v-btn color="" v-on:click="dialogAvatar = false">Cancel</v-btn>
                                        <v-btn
                                            color="primary"
                                            v-on:click.prevent="uploadAvatar"
                                            v-bind:loading="loading"
                                            v-bind:disabled="!validAvatar"
                                        >Upload
                                        </v-btn>
                                    </v-card-actions>
                                </v-card>
                            </v-form>
                        </v-dialog>
                    </v-layout>
                </template>
            </v-flex>
            <v-flex xs8>
                <v-card>
                    <v-card-title primary-title>
                        <h1 class="uppercase">{{user.email}}</h1>
                    </v-card-title>
                    <v-card-text class="">
                        <v-text-field
                            v-model="userFirstname"
                            label="First name"
                            required
                        ></v-text-field>
                        <v-text-field
                            v-model="userLastname"
                            label="Last name"
                            required
                        ></v-text-field>
                    </v-card-text>
                    <v-card-actions>
                        <v-btn
                            color="primary"
                            v-on:click="saveUser"
                            v-bind:loading="loading"
                        >Save
                        </v-btn>
                    </v-card-actions>
                </v-card>
            </v-flex>
        </v-layout>
        <v-layout v-else>
            <v-flex xs12>
                <v-alert
                    v-bind:value="true"
                    type="error"
                >
                    Access denied!
                </v-alert>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
    import api from '../../common/api'

    export default {
        name: "User",
        mounted() {
            this.userFirstname = this.user.firstname
            this.userLastname = this.user.lastname
        },
        data() {
            return {
                validAvatar: false,
                dialogAvatar: false,
                form: new FormData(),
                imageName: '',
                imageUrl: '',
                imageFile: '',
                userFirstname: '',
                userLastname: '',
                avatarRules: [
                    v => !!v || 'Image is required'
                ]
            }
        },
        methods: {
            pickFile() {
                this.$refs.image.click()
            },

            onFilePicked(e) {
                const files = e.target.files
                if (files[0] !== undefined) {
                    this.imageName = files[0].name
                    if (this.imageName.lastIndexOf('.') <= 0) {
                        return
                    }
                    const fr = new FileReader()
                    fr.readAsDataURL(files[0])
                    fr.addEventListener('load', () => {
                        this.imageUrl = fr.result
                        this.imageFile = files[0]
                        this.form.append('file', this.$refs.image.files[0])
                        this.form.append('filename', this.imageName)
                    })
                } else {
                    this.imageName = ''
                    this.imageFile = ''
                    this.imageUrl = ''
                }
            },
            uploadAvatar() {
                this.$store.dispatch('setLoading', true)
                api.http.post(api.userAvatar,
                    this.form,
                    {
                        headers: {
                            'Content-Type': 'multipart/form-data'
                        }
                    }
                )
                    .then((response) => {
                        if (response.data.status == 'ok') {
                            this.dialogAvatar = false
                            this.imageFile = ''
                            this.imageName = ''
                            this.imageUrl = ''
                            this.form = new FormData()
                            this.$store.dispatch('autoLogin')
                                .then(() => {
                                    this.$store.dispatch('setMessage', 'Avatar is updated.')
                                })
                        }
                    })
                    .catch((error) => {
                        this.$store.dispatch('setError', 'Data transfer error. ' + error)
                    })
                    .finally(() => {
                        this.$store.dispatch('setLoading', false)
                    })
            },
            saveUser() {

            }
        },
        computed: {
            isAuthenticated() {
                return this.$store.getters.isAuthenticated
            },
            user() {
                return this.$store.getters.user
            },
            loading() {
                return this.$store.getters.loading
            }
        }

    }
</script>

<style scoped>
</style>
