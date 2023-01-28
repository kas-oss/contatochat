import './Header.css'

const Header = ({contactActive}) => {
    return (
        <div className="header">
            <div className="img-text"> 
                <h4>{contactActive.nome}</h4>
            </div>
        </div>
    )
}

export default Header