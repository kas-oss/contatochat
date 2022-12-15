import axios from 'axios'

const baseUrl = 'http://localhost:5000'

// const api = axios.create({
//     baseUrl: baseUrl,
//     transformRequest: [
//         (data, headers) => {
//             const token = localStorage.getItem('user')
//             if (token) headers.common.Authorization = `Bearer ${token}`
//             return data
//         }
//     ]
// })



const apiRoutes = {

    registration:(user) => axios.post("http://localhost:5000/Account/Create", user)
}
export default apiRoutes