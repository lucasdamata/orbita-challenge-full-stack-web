import axios from "axios";

export const  customAxios = () => {
  const instance = axios.create({
    headers: {
      Authorization: `Baerer ${localStorage.getItem('access-token')}` 
    }
  })

  return instance
}