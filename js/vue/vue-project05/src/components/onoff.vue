<template>
    <div>
        <button
                class="on"
                v-bind:class="{'active': value}"
                v-on:click="onChange(true)"
        >on</button>
        <button
                class="off"
                v-bind:class="{'active': !value}"
                v-on:click="onChange(false)"
        >off</button>
    </div>
</template>

<script>
    export default {
        name: "onoff",
        props: {
            'value': {
                type: Boolean
            }
        },
        methods: {
            onChange (newValue) {
                this.$emit('input', newValue)
            }
        }
    }
</script>

<style scoped>
    button {
        border: none;
        padding: 10px;
        cursor: pointer;
        margin-right: 10px;
        outline: none;
    }
    button:active {
        box-shadow: inset 1px 1px 2px rgba(0, 0, 0, .5);
    }
    .on.active {
        background: green;
        color: #fff;
    }
    .off.active {
        background: red;
        color: #fff;
    }
</style>