import './Header.css'

const Header = ({ logout, user }) =>{
    return(
        <div className="header">
            <span className='user'>{user.name}</span>
            <span className='logout' onClick={logout}>Sair</span>
        </div>
    )
}

export default Header