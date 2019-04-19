<template>
    <v-container fluid fill-height>
        <v-layout align-center justify-center>
            <v-flex xs12 sm8 md6>
                <v-card class="elevation-12">
                    <v-toolbar dark color="primary">
                        <v-toolbar-title>Change password form</v-toolbar-title>
                    </v-toolbar>
                    <v-card-text>
                        <v-form v-model="valid" ref="form" lazy-validation>
                            <v-text-field
                                    id="oldpassword" prepend-icon="lock" name="oldpassword" label="Old password" type="password"
                                    v-model="oldPassword"
                                    v-bind:counter="6"
                                    v-bind:rules="passwordRules"
                            ></v-text-field>
                            <v-text-field
                                    id="password" prepend-icon="lock" name="password" label="Password" type="password"
                                    v-model="password"
                                    v-bind:counter="6"
                                    v-bind:rules="passwordRules"
                            ></v-text-field>
                            <v-text-field
                                    id="confirmPassword" prepend-icon="lock" name="confirmPassword" label="Confirm Password" type="password"
                                    v-model="confirmPassword"
                                    v-bind:counter="6"
                                    v-bind:rules="confirmPasswordRules"
                            ></v-text-field>
                        </v-form>
                    </v-card-text>
                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn color="primary" v-on:click.prevent="onSubmit" v-bind:disabled="!valid">Register</v-btn>
                    </v-card-actions>
                </v-card>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
    export default {
        name: "ChangePassword",
        data() {
            return {
                valid: false,
                oldPassword: '',
                password: '',
                confirmPassword: '',
                passwordRules: [
                    v => !!v || 'Password is required',
                    v => (v && v.length >= 6) || 'Password must be equal or more than 6 characters'
                ],
                confirmPasswordRules: [
                    v => !!v || 'Password is required',
                    v => v===this.password || 'Password should match'
                ]
            }
        },
        methods: {
            onSubmit() {
                if (this.$refs.form.validate()) {
                    /*
                    const data = {
                        oldPassword: this.oldPassword,
                        password: this.password
                    };
                    this.$store.dispatch('changePasswordUser', data)
                    */
                }
            }
        }
    }
</script>

<style scoped>

</style>