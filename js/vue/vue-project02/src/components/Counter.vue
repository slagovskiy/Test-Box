<template>
    <div class="counter">
        <slot name="title"></slot>
        <slot name="count"></slot>
    </div>
</template>

<script>
    import {eventEmitter} from "../main"

    export default {
        name: "Counter",

    }
</script>

<style scoped>
    .counter {
        border: 1px solid gray;
        border-radius: 10px;
        margin: 10px;
        padding: 10px;
    }
</style>