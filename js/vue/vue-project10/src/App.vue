<template>
  <v-app>
    <v-navigation-drawer
            temporary
            app
            v-model="drawer"
    >
      <v-list>
        <v-list-tile
                v-for="link in links"
                v-bind:key="link.title"
                v-bind:to="link.url"
        >
          <v-list-tile-action>
            <v-icon>{{link.icon}}</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title v-text="link.title"></v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
      </v-list>
    </v-navigation-drawer>
    <v-toolbar app dark color="primary">
      <v-toolbar-side-icon class="hidden-md-and-up"
        v-on:click="drawer = !drawer"
      ></v-toolbar-side-icon>
      <v-toolbar-title>
        <router-link to="/" tag="span" class="pointer">Application</router-link>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <v-toolbar-items class="hidden-sm-and-down">
        <v-btn
                v-for="link in links"
                v-bind:key="link.title"
                v-bind:to="link.url"
                flat
        >
          <v-icon left>{{link.icon}}</v-icon>{{link.title}}
        </v-btn>
      </v-toolbar-items>
    </v-toolbar>
    <v-content>
      <router-view></router-view>
    </v-content>
  </v-app>
</template>

<script>
export default {
  name: 'app',
  data () {
    return {
      drawer: false,
      links: [
        {
          title: 'login',
          icon: 'lock',
          url: '/login'
        },
        {
          title: 'Registration',
          icon: 'face',
          url: '/registration'
        },
        {
          title: 'Orders',
          icon: 'bookmark_border',
          url: '/orders'
        },
        {
          title: 'New ad',
          icon: 'note_add',
          url: '/new'
        },
        {
          title: 'My ads',
          icon: 'list',
          url: '/list'
        },
      ]
    }
  }
}
</script>

<style scoped>
  .pointer {
    cursor: pointer;
  }
</style>
