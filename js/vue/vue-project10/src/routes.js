import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import Ad from '@/components/Ads/Ad'
import AdLisy from '@/components/Ads/AdList'
import NewAd from '@/components/Ads/NewAdd'
import Login from '@/components/Auth/Login'
import Registration from '@/components/Auth/Registration'
import Orders from '@/components/User/Orders'

Vue.use(Router)

export default new Router({
    routes: [
        {
            path: '/',
            name: 'home',
            component: Home
        },
        {
            path: '/ad/:id',
            props: true,
            name: 'ad',
            component: Ad
        },
        {
            path: '/list',
            name: 'list',
            component: AdLisy
        },
        {
            path: '/new',
            name: 'newAd',
            component: NewAd
        },
        {
            path: '/login',
            name: 'login',
            component: Login
        },
        {
            path: '/registration',
            name: 'reg',
            component: Registration
        },
        {
            path: '/orders',
            name: 'orders',
            component: Orders
        },
    ],
    mode: 'history',
})