import axios from "axios";

export const  customAxios = () => {
  const instance = axios.create({
    headers: {
      Authorization: `Bearer ${localStorage.getItem('access-token')}` 
    },
  })

  return instance
}