import axios from 'axios'

const api = axios.create({
    baseURL: 'http://localhost:60731',
    headers:{
        "Content-Type": "application/json; charset=utf-8"
    },
    transformRequest: [
        (data, headers) => {
            const token = localStorage.getItem('user')
            if (token) headers.common.Authorization = `Bearer ${token}`
            return data
        }
    ]
})

const apiRoute = {
    //registration: (user) => api.get("/Account/teste")   
    registration: (user) => api.post("/Account/Create", JSON.stringify(user))   
}

export default apiRoute