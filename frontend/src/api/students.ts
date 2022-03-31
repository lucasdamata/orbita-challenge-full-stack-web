import helpers from '../helpers/helpers'
import { customAxios } from './genericApi'


interface CreateStudent {
  name: string
  email: string
  ra: string
  cpf: string
}

interface UpdateStudent {
  name: string
  email: string
}

export default {
  createStudent(params :CreateStudent) {
    return customAxios().post(`${helpers.API_STUDENT}`, params)
  },
  getAllStudents() {
    return customAxios().get(`${helpers.API_STUDENT}`)
  },
  getStudentById(id: Number) {
    return customAxios().get(`${helpers.API_STUDENT}/${id}`)
  },
  updateSudentById(id: Number, params: UpdateStudent) {
    return customAxios().put(`${helpers.API_STUDENT}/${id}`, params)
  },
  deleteStudentById(id: Number) {
    return customAxios().delete(`${helpers.API_STUDENT}/${id}`)
  },
}