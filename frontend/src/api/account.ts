import axios from "axios";
import helpers from '../helpers/helpers'

interface User {
  username: string,
  password: string
}

interface Response {
  message: string
}

export default {
  async login(params: User) {
    const request = await axios.post(`${helpers.API_SESSION}`, {
      username: params.username,
      password: params.password
    },)
    const token : Response = request.data[0]
    return token.message

  } 
}
