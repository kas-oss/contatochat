import { useContext } from 'react'
import { UserContext } from '../../../hooks/UserContext'
import './Header.css'

const Header = () =>{
    const { logout } = useContext(UserContext)

    return(
        <div className="header">
            <span className='user'>Daniel Caitano</span>
            <span className='logout' onClick={logout}>Sair</span>
        </div>
    )
}

export default Header