<template>
    <div>
        <button class="btn btn-success" v-on:click="updateCounter(1)">Add</button>
        <button class="btn btn-danger" v-on:click="updateCounter(-1)">Subtract</button>
    </div>
</template>

<script>
    export default {
        name: "Actions",
        methods: {
            updateCounter(val) {
                //this.$store.state.counter += val
                //this.$store.commit('changeCounter', val)
                this.$store.dispatch('asyncChangeCounter', {
                    counterValue: val,
                    delay: 2000
                })
            }
        }
    }
</script>

<style scoped>

</style>