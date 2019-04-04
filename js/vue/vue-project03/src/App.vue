<template>
    <div id="app">
        <h2 v-colored:background.font="'green'" v-if="visible">{{ title }}</h2>
        <h2 v-colored:color.delay="'blue'" v-if="visible">{{ title }}</h2>
        <h2 v-font v-if="visible">{{ title }}</h2>
        <button v-on:click="visible=!visible">visible</button>
        <button v-on:click="title='New title'">Change title</button>
    </div>
</template>

<script>

    export default {
        name: 'app',
        data() {
            return {
                title: 'Hello!!',
                visible: true
            }
        },
        directives: {
            font: {
                bind(el){
                    el.style.fontSize = '60px'
                }
            }
        }
    }
</script>

<style>

</style>
