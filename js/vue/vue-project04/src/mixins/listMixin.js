export default {
    data() {
        return {
            names: ['qwerty', 'asdfgh', 'zxcvb', 'zaqwsxcde', 'ytrewq'],
            searchName: ''
        }
    },
    computed: {
        filteredNames() {
            return this.names.filter(name => {
                return name.indexOf(this.searchName) != -1
            })
        }
    }
}