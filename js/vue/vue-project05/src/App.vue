<template>
  <div id="app">
    <h2>Inputs</h2>
    <app-onoff v-model="onoffswitch"></app-onoff>{{onoffswitch}}
    <hr>
    <p><input type="text" v-model="name"></p>
    <p><textarea v-model="textarea"></textarea></p>
    <p>{{name}}</p>
    <p class="textarea">{{textarea}}</p>
    <div>
      <label>
        <input type="checkbox" value="instagram" v-model="social"> Instagram
      </label>
      <label>
        <input type="checkbox" value="facebook" v-model="social"> Facebook
      </label>
      <label>
        <input type="checkbox" value="vk" v-model="social"> VK
      </label>
    </div>
    <ul>
      <li v-for="v in social" v-bind:key="v">{{v}}</li>
    </ul>
    <hr>
    <div>
      <label>
        <input type="radio" value="instagram" v-model="radio"> Instagram
      </label>
      <label>
        <input type="radio" value="facebook" v-model="radio"> Facebook
      </label>
      <label>
        <input type="radio" value="vk" v-model="radio"> VK
      </label>
    </div>
    <p>{{radio}}</p>
    <hr>
    <select v-model="socialitem">
      <option v-for="s in sociallist" v-bind:key="s">{{s}}</option>
    </select> {{socialitem}}
    <hr>
    <input type="text" v-model.number="age">{{age}}
  </div>
</template>

<script>
import onoff from './components/onoff'

export default {
  name: 'app',
  data() {
    return {
      name: '',
      textarea: 'text on textarea',
      social: ['vk'],
      radio: 'facebook',
      sociallist: ['instagram', 'facebook', 'vk'],
      socialitem: 'vk',
      age: 22,
      onoffswitch: true
    }
  },
  components: {
    'app-onoff': onoff
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  margin-top: 30px;
}
  textarea{
    height: 100px;
    width: 400px;
  }
  .textarea {
    white-space: pre;
  }
</style>
