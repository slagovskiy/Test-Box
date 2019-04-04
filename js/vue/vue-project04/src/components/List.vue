<template>
    <div>
        <h1>List</h1>
        <div>
            <div><input type="text" v-model="searchName"></div>
            <ul>
                <li v-for="(name, index) of filteredNames" v-bind:key="index">{{ index }} {{ name }}</li>
            </ul>
        </div>
    </div>
</template>

<script>
    import listMixin from '../mixins/listMixin'

    export default {
        name: "List",
        mixins: [listMixin]
    }
</script>

<style scoped>

</style>