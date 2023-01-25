import './Footer.css'
import api from '../../../services/api'

const Footer = () => {
    return (
        <div className="chat-box-input">
            <input type="text" placeholder="Digite sua mensagem..." />
            <input type="button" value={"enviar"} onClick={async() => console.log(await api.loadMessage())} />
        </div>
    )
}

export default Footer