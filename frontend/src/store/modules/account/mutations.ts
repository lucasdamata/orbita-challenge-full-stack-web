import jwtDecode from 'jwt-decode'

export default {
  SET_ACCOUNT(state: any, token: string) {
    window.localStorage.setItem('access-token', token)

    const decodedToken = jwtDecode(token)

    state.account = decodedToken
  },
}