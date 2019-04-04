import VueRouter from 'vue-router'
import Home from './pages/Home'
import CarDetail from './pages/CarDetail'
import Error404 from './pages/Error'

const Cars = resolve => {
    require.ensure(['./pages/Cars.vue'], () => {
        resolve(
            require('./pages/Cars')
        )
    })
}

const Car = resolve => {
    require.ensure(['./pages/Car.vue'], () => {
        resolve(
            require('./pages/Car')
        )
    })
}

export default new VueRouter({
    routes: [
        {
            path: '',
            component: Home
        },
        {
            path: '/cars',
            component: Cars,
            name: 'cars'
        },
        {
            path: '/car/:id',
            component: Car,
            children: [
                {
                    path: 'detail',
                    component: CarDetail,
                    name: 'carDetail',
                    beforeEnter(to, from, next) {
                        next()
                        /*
                        if (true) {
                            next(true)
                        } else {
                            next(false)
                        }*/
                    }
                }
            ]
        },
        {
            path: '/none',
            redirect: '/cars'
        },
        {
            path: '/none2',
            redirect: {
                name: 'cars'
            }
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