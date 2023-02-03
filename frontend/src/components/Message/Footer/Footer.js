import './Footer.css'

const Footer = ({contactActive, sendMessage}) => {
    
    const onChange = (e) =>{
        if(e.key === 'Enter'){
            sendMessage(e.target.value)
            e.target.value = ''
        }
    }

    return (
        <div className="chat-box-input">
            {contactActive.id && <input onKeyUp={onChange} type="text" placeholder="Digite sua mensagem..." />}
        </div>
    )
}

export default Footer