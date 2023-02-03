import { createContext, useState, useCallback } from "react";
import apiRoutes from "../services/api"

export const UserContext = createContext()

const UserContextProvider = ({ children }) => {

    const userToken = localStorage.getItem('userToken')
    const [user, setUser] = useState(JSON.parse(userToken))

    const contactsToken = localStorage.getItem('contactsToken')
    const [contacts, setContacts] = useState(JSON.parse(contactsToken))

    const saveTokenContacts = (contatoList, userId) =>{
        localStorage.removeItem('contactsToken')
        const removeMyOwnContact = contatoList.filter(con => !(con.id === userId))
        setContacts(removeMyOwnContact)
        localStorage.setItem('contactsToken', JSON.stringify(removeMyOwnContact))
    }

    const saveTokenUser = (data) =>{
        console.log(data)
        setUser(data.usuario)        
        localStorage.setItem('userToken', JSON.stringify(data.usuario)) 
        saveTokenContacts(data.contatoList, data.usuario.id)  
    }

    const updateListContacts = useCallback(async() =>{
        const res = await apiRoutes.listContacts();
        saveTokenContacts(res.data, user.id)
    },[user])

    const registration = async (name, email, phone, pass, confirmPass, profilePicture) => {
        logout()
        const res = await apiRoutes.registration({ name, email, phone, pass, confirmPass, profilePicture });
        saveTokenUser(res.data)
    }

    const login = async (email, password) => {
        logout()
        const res = await apiRoutes.login({ login: email, password });
        saveTokenUser(res.data)
    }

    const logout = () => {
        setUser(null)
        localStorage.removeItem('userToken')
        localStorage.removeItem('contactsToken')
    }
    const contextValues = { 
        login, 
        logout, 
        registration, 
        user, 
        contacts, 
        updateListContacts
    }
    return (
        <UserContext.Provider value={contextValues}>
            {children}
        </UserContext.Provider>
    )
}

export default UserContextProvider
