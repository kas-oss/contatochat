import axios from 'axios'

const baseUrl = 'http://localhost'

const api = axios.create({
    baseUrl: baseUrl,
    transformRequest: [
        (data, headers) => {
            const token = localStorage.getItem('user')
            if (token) headers.common.Authorization = `Bearer ${token}`
            return data
        }
    ]
})

const routes = {
    
}