import './Footer.css'

const Footer = ({contactActive}) => {
    return (
        <div className="chat-box-input">
            {contactActive.id && <input type="text" placeholder="Digite sua mensagem..." />}
        </div>
    )
}

export default Footer