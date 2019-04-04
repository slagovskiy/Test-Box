<template>
  <div id="app">
    <h1>{{ title }}</h1>
    <table>
      <tr>
        <td valign="top"><app-list></app-list></td>
        <td valign="top"><app-list></app-list></td>
      </tr>
    </table>
  </div>
</template>

<script>

export default {
  name: 'app',
  data() {
    return {
      title: 'Hello Vue!',
    }
  },
  filters: {
    lowerCase(value) {
      return value.toLowerCase()
    }
  },
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  margin: 30px;
}
</style>
