import { createContext, useState } from "react";
import apiRoutes from "../services/backend"

export const UserContext = createContext()

const UserContextProvider = ({ children }) => {

    const userToken = localStorage.getItem('userToken')
    const [user, setUser] = useState(userToken)

    const registration = async (name, email, phone, pass, confirmPass) => {
        const res = await apiRoutes.registration({ name, email, phone, pass, confirmPass });
        setUser(res.data)
        localStorage.setItem('userToken', res.data)
    }

    const login = async (email, pass) => {
        const res = await apiRoutes.registration({ email, pass });
        setUser(res.data)
        localStorage.setItem('userToken', res.data)
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
