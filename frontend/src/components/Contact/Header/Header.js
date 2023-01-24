import './Header.css'

const Header = ({ logout }) =>{
    return(
        <div className="header">
            <span className='user'>Daniel Caitano</span>
            <span className='logout' onClick={logout}>Sair</span>
        </div>
    )
}

export default Header