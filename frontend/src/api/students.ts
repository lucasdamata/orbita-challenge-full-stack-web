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
  async getAllStudents() {
    const response = await customAxios().get(`${helpers.API_STUDENT}`)
    return response

  },
  async getStudentById(id: Number) {
    const response = await customAxios().get(`${helpers.API_STUDENT}/${id}`)
    return response
  },
  updateSudentById(id: Number, params: UpdateStudent) {
    return customAxios().put(`${helpers.API_STUDENT}/${id}`, params)
  },
  deleteStudentById(id: Number) {
    return customAxios().delete(`${helpers.API_STUDENT}/${id}`)
  },
}