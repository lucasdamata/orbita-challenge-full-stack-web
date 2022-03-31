import account from "../../../api/account";

interface User {
  username: string,
  password: string
}

export default {
  actionLogin({ commit } : any, params: User) {
    return account.login(params)
      .then((response) => {
        commit('SET_ACCOUNT', response)

        return Promise.resolve(response)
      })
      .catch((err) => {
        return Promise.reject(err.response)
      })
  },
}