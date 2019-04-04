<template>
    <div>
        <h4>Car name: {{ $route.query['name'] }}</h4>
        <h5>Car year: {{ $route.query['year'] }}</h5>
        <div class="scroll"></div>
        <h6 id="scroll">some text</h6>
    </div>
</template>

<script>
    export default {
        name: "CarDetail",
        beforeRouteEnter (to, from, next) {
            next()
        }
    }
</script>

<style scoped>
    .scroll {
        width: 100px;
        height: 2000px;
    }
</style>