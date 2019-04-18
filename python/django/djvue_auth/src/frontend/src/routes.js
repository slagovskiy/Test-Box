import VueRouter from 'vue-router'
import Home from './views/Home'
import User from './views/User/User'
import Login from './views/User/Login'
import Error404 from './views/Error'

/*
const Cars = resolve => {
    require.ensure(['./pages/Cars.vue'], () => {
        resolve(
            require('./pages/Cars')
        )
    })
}
*/

export default new VueRouter({
    routes: [
        {
            path: '',
            component: Home
        },
        {
            path: '/user/:name',
            component: User,
            name: 'user',
            children: [
                {
                    path: 'login',
                    component: Login,
                    name: 'user-login',
                    beforeEnter(to, from, next) {
                        next()
                        /*
                        if (true) {
                            next(true)
                        } else {
                            next(false)
                        }*/
                    }
                },
            ]
        },
        {
            path: '*',
            component: Error404
        }
    ],
    mode: 'history',
    scrollBehavior (to, from, savedPosition) {
        if (savedPosition) {
            return savedPosition
        }
        if(to.hash) {
            return {selector: to.hash}
        }
        return {
            x: 0,
            y: 0
        }
    }
})