import { createStore } from 'vuex'

import createPersistedState from 'vuex-persistedstate'

import account from './modules/account'
import students from './modules/students'

export const store = createStore({
  modules: {
    account,
    students
  },
  plugins: [createPersistedState()]
})