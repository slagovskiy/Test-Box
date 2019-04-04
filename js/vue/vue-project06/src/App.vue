<template>
  <div id="app">
    <div class="container">
      <form class="pt-3" v-on:submit.prevent="onSubmit">
        <div class="form-group">
          <label for="email">Email</label>
          <input
                  type="email"
                  id="email"
                  class="form-control "
                  v-bind:class="{'is-invalid': $v.email.$error}"
                  v-model="email"
                  v-on:blur="$v.email.$touch()"
          >
          <div class="invalid-feedback">
            <div v-if="!$v.email.required">Email field is required</div>
            <div v-if="!$v.email.email">Please enter a valid email.</div>
            <div v-if="!$v.email.uniqEmail">Bad email.</div>
          </div>
        </div>
        <div class="form-group">
          <label for="email2">Email</label>
          <input
                  type="email"
                  id="email2"
                  class="form-control "
                  v-bind:class="{'is-invalid': $v.email2.$error}"
                  v-model="email2"
                  v-on:blur="$v.email2.$touch()"
          >
          <div class="invalid-feedback">
            <div v-if="!$v.email2.required">Email field is required</div>
            <div v-if="!$v.email2.email">Please enter a valid email.</div>
          </div>
        </div>
        <div class="form-group">
          <label for="password">Password</label>
          <input
                  type="password"
                  id="password"
                  class="form-control "
                  v-bind:class="{'is-invalid': $v.password.$error}"
                  v-model="password"
                  v-on:blur="$v.password.$touch()"
          >
          <div class="invalid-feedback">
            <div v-if="!$v.password.minLength || !$v.password.required">Min length of password is {{ $v.password.$params.minLength.min}}. Now it is {{ password.length }}</div>
          </div>
        </div>
        <div class="form-group">
          <label for="confirmPassword">Confirm Password</label>
          <input
                  type="password"
                  id="confirmPassword"
                  class="form-control "
                  v-bind:class="{'is-invalid': $v.confirmPassword.$error}"
                  v-model="confirmPassword"
                  v-on:blur="$v.confirmPassword.$touch()"
          >
          <div class="invalid-feedback">
            <div v-if="!$v.confirmPassword.sameAs">Password should match</div>
          </div>
        </div>
        <button class="btn btn-success" type="submit" v-bind:disabled="$v.$invalid">Submit</button>
      </form>
    </div>
  </div>
</template>

<script>
  import { required, email, minLength, sameAs } from 'vuelidate/lib/validators'

  export default {
    name: 'app',
    data() {
      return {
        email: '',
        email2: '',
        password: '',
        confirmPassword: ''
      }
    },
    methods: {
      onSubmit() {
        console.log('Email', this.email)
        console.log('Password', this.password)
      }
    },
    validations: {
      email: {
        required: required,
        email: email,
        uniqEmail: function(newEmail) {
          if (newEmail === '') return true

          return new Promise((resolve, reject) => {
            setTimeout(() => {
              const value = newEmail !== 'test@mail.ru'
              resolve(value)
            }, 1000)
          })
        }
      },
      email2: {
        required: required,
        email: email
      },
      password: {
        required: required,
        minLength: minLength(6)
      },
      confirmPassword: {
        sameAs: sameAs('password')
      },
      /*
      confirmPassword: {
        sameAs: sameAs((vue) => {
          return vue.password
        })
      }
      */
    }
  }
</script>

<style>
#app {
}
</style>
