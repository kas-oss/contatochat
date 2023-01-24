import { useContext } from "react"
import { Navigate, Outlet } from "react-router-dom"
import { UserContext } from "../../hooks/UserContext"

const PrivateRoute = () =>{
    const {user} = useContext(UserContext) 

    if(user){ 
        return <Outlet />
    }else{
        return <Navigate replace to='/login' />
    }
}

export default PrivateRoute