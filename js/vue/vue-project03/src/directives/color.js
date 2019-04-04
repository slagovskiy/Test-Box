export default {
    bind(el, bindings, vnode) {
        const arg = bindings.arg
        const fontMod = bindings.modifiers['font']
        const delayMod = bindings.modifiers['delay']
        let delay = 0

        if (fontMod) {
            el.style.fontSize = '40px'
        }
        if (delayMod) {
            delay = 2000
        }
        setTimeout(() => {
            el.style[arg] = bindings.value
        }, delay)
        //console.log('bind')
    }
    /*,
    inserted(el, bindings, vnode) {
        console.log('inserted')
    },
    update(el, bindings, vnode, oldVnode){
        console.log('update')
    },
    componentUpdated(el, bindings, vnode, oldVnode){
        console.log('componentUpdated')
    },
    unbind() {
        console.log('unbind')
    }*/
}