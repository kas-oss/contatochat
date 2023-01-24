import { createContext, useState } from "react";
import apiRoutes from "../services/api"

export const UserContext = createContext()

const UserContextProvider = ({ children }) => {

    const userToken = localStorage.getItem('userToken')
    const [user, setUser] = useState(JSON.parse(userToken))

    const registration = async (name, email, phone, pass, confirmPass) => {
        const res = await apiRoutes.registration({ name, email, phone, pass, confirmPass });
        setUser(res.data)
        localStorage.setItem('userToken', JSON.stringify(res.data))
    }

    const login = async (email, password) => {
        const res = await apiRoutes.login({ login: email, password });
        setUser(res.data)
        localStorage.setItem('userToken', JSON.stringify(res.data))
    }

    const logout = () => {
        setUser(null)
        localStorage.removeItem('userToken')
    }

    return (
        <UserContext.Provider value={{ login, logout, registration, user }}>
            {children}
        </UserContext.Provider>
    )
}

export default UserContextProvider
