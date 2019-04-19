import VueRouter from 'vue-router'
import Home from './views/Home'
import User from './views/User/User'
import Login from './views/User/Login'
import Register from './views/User/Register'
import ChangePassword from './views/User/ChangePassword'
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
            path: '/',
            component: Home,
            name: 'home'
        },
        {
            path: '/user',
            component: User,
            name: 'user'
        },
        {
            path: '/user/login',
            component: Login,
            name: 'user-login'
        },
        {
            path: '/user/register',
            component: Register,
            name: 'user-register'
        },
        {
            path: '/user/password',
            component: ChangePassword,
            name: 'user-password'
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