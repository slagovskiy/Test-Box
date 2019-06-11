<template>
    <v-container grid-list-md fill-height>
        <v-layout row wrap>
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
                                        prepend-icon='attach_file'
                                    ></v-text-field>
                                    <input
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
                                    <v-btn color="primary" v-on:click="uploadAvatar">Upload</v-btn>
                                </v-card-actions>
                            </v-card>
                        </v-dialog>
                    </v-layout>
                </template>
            </v-flex>
            <v-flex xs8>
                <v-card>
                    <v-card-text class="px-0">qwerty</v-card-text>
                </v-card>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
    import api from '../../common/api'
    export default {
        name: "User",
        data() {
            return {
                dialogAvatar: false,
                form: new FormData(),
                imageName: '',
                imageUrl: '',
                imageFile: '',
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
                        this.form.append('files', files[0], files[0].name)
                    })
                } else {
                    this.imageName = ''
                    this.imageFile = ''
                    this.imageUrl = ''
                }
            },
            uploadAvatar() {

                for (var d of this.form) console.log(d)
                api.http.post(api.userAvatar,
                    this.form,
                    {
                        headers: {
                            'Content-Type': 'multipart/form-data'
                        }
                    }
                )
                    .then(function () {
                        console.log('SUCCESS!!');
                    })
                    .catch(function () {
                        console.log('FAILURE!!');
                    });
            }
        },
        computed: {
            isAuthenticated() {
                return this.$store.getters.isAuthenticated
            },
            user() {
                return this.$store.getters.user
            }
        }

    }
</script>

<style scoped>

</style>
