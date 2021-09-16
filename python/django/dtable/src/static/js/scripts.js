const DT = {
    delimiters: ["[[", "]]"],
    data() {
        return {
            counter: 0,
            showModal: false
        }
    }
}

DT.component("modal", {
    template: "#modal-template",
})


Vue.createApp(DT).mount('#app')