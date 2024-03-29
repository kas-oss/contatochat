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
    registration: (user) => api.post("/Account/Registro", JSON.stringify(user)),
    login: (user) => api.post("/Account/Login", JSON.stringify(user)),  
    loadChat: (data) => api.post("/Chat/Create", JSON.stringify(data)),
    loadMessages: (id) => api.get("/Chat/GetConversa?id="+id),
    sendMessage: (data) => api.post("Chat/EnviarMensagem", JSON.stringify(data)),
    listContacts: () => api.get("/Account/ListContatos"),
    listMessages: (id) => api.get("/Account/ListConversas?id="+id), 
}

export default apiRoute