<template>
    <div>
        <h1>Cars</h1>
        <ul>
            <router-link
                tag="li"
                v-for="car in 5"
                v-bind:to="'/car/' + car"
                v-bind:key="car"
                >
                <a>Car {{ car }}</a>
            </router-link>
        </ul>
    </div>
</template>

<script>
    export default {
        name: "Cars"
    }
</script>

<style scoped>

</style>