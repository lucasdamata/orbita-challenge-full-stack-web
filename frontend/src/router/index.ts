import { store } from '../store/index'
import { createRouter, createWebHistory } from 'vue-router'

import { Public, Private, Login, Academic } from '../pages'

const routes = [
  {
    path: '/:pathMatch(.*)*',
    redirect: '/'
  },
  {
    path: '/',
    name: 'Public',
    redirect: '/login',
    component: Public,
    beforeEnter: (to: any, from : any, next : any) => {
      if(store.getters.getterAccount && Object.keys(store.getters.getterAccount).length > 0) {
        next({ name: 'Private' })
      } else {
        next()
      }
    },
    children: [
      {
        path: '/login',
        name: 'Login',
        component: Login
      }
    ]
  },
  {
    path: '/academic',
    name: 'Private',
    redirect: '/academic',
    component: Private,
    beforeEnter: (to: any, from: any, next: any) => {
      if(store.getters.getterAccount && Object.keys(store.getters.getterAccount).length > 0) {
        next()
      } else {
        next({ name: 'Public' })
      }
    },
    children: [
      {
        path: '/academic',
        name: 'Academic',
        component: Academic
      },
    ]
  }
]

const router = createRouter({
  history: createWebHistory(""),
  routes
})

export default router
