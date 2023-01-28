import { createContext, useState } from "react";
import apiRoutes from "../services/api"

export const UserContext = createContext()

const UserContextProvider = ({ children }) => {

    const userToken = localStorage.getItem('userToken')
    const [user, setUser] = useState(JSON.parse(userToken))

    const contactsToken = localStorage.getItem('contactsToken')
    const [contacts, setContacts] = useState(JSON.parse(contactsToken))

    const registration = async (name, email, phone, pass, confirmPass, profilePicture) => {
        logout()
        const res = await apiRoutes.registration({ name, email, phone, pass, confirmPass, profilePicture });
        
        setUser(res.data.usuario)
        setContacts(res.data.contatoList)
        localStorage.setItem('userToken', JSON.stringify(res.data.usuario))
        localStorage.setItem('contactsToken', JSON.stringify(res.data.contatoList))
    }

    const login = async (email, password) => {
        logout()
        const res = await apiRoutes.login({ login: email, password });

        setUser(res.data.usuario)
        setContacts(res.data.contatoList)
        localStorage.setItem('userToken', JSON.stringify(res.data.usuario))
        localStorage.setItem('contactsToken', JSON.stringify(res.data.contatoList))
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
    }
    return (
        <UserContext.Provider value={contextValues}>
            {children}
        </UserContext.Provider>
    )
}

export default UserContextProvider
