import { createContext, useState } from "react";

export const UserContext = createContext() 

const UserContextProvider = ({children}) =>{
    const [user, setUser] = useState({})
    const [error, setError] = useState('')

    const login = (email, password) =>{
        try {
            console.log(email, password)
        } catch (error) {
            
        }
    }

    const logout = () =>{

    }

    return(
        <UserContext.Provider value={{login, logout, user, error}}>
            {children}
        </UserContext.Provider>
    )
}

export default UserContextProvider
