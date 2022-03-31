const API_HOST_LOGIN = () => {
  return 'http://localhost:6001'
}

const API_HOST_APP = () => {
  return 'http://localhost:5001'
}

const API_URL_LOGIN = `${API_HOST_LOGIN()}`
const API_URL_APP = `${API_HOST_APP()}`
const API_SESSION = `${API_URL_LOGIN}/login`
const API_REGISTER = `${API_URL_LOGIN}/register`
const API_STUDENT = `${API_URL_APP}/student`

export default {
  API_HOST_LOGIN,
  API_URL_APP,
  API_SESSION,
  API_REGISTER,
  API_STUDENT
}