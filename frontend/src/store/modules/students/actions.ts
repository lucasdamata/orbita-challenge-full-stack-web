import student from "../../../api/students";

interface CreateStudent {
  name: string
  email: string
  ra: string
  cpf: string
}

interface UpdateStudent {
  id: number
  data: {
    name: string
    email: string
  }
}

export default {
  actionCreateStudent(_: any, params: CreateStudent) {
    return student.createStudent(params)
      .then((response) => {
        return Promise.resolve(response.data)
      })
      .catch((err) => {
        return Promise.reject(err.response)
      })
  },
  actionGetAllStudents() {
    return student.getAllStudents
  },
  actionGetStudentByUserId(_: any, id: Number) {
    return student.getStudentById(id)
      .then((response) => {
        return Promise.resolve(response.data)
      }).catch((err) => {
        return Promise.reject(err.response)
      });
  },
  actionDeleteStudentById(_: any, id: Number) {
    return student.deleteStudentById(id)
      .then((response) => {
        return Promise.resolve(response.data)
      }).catch((err) => {
        return Promise.reject(err.response)
      });
  },
  actionPutStudentById(_: any, params: UpdateStudent) {
    return student.updateSudentById(params.id, params.data)
      .then((response) => {
        return Promise.resolve(response.data)
      }).catch((err) => {
        return Promise.reject(err.response)
      });
  },
}