import './Main.css'

const Main = ({ messagesData, user }) => {

    return (
        <div className="chat-box">
            {messagesData?.mensagemList?.map(message => {
                return <div key={message.id} className={message.contatoId === user.id? "message my-message" : "message friend-message"}>
                    <p>{message.conteudo}<br /></p>
                </div>
            })
            }
            <div style={{ opacity: 0 }} className="message my-message">
                <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Modi voluptate commodi, corrupti provident ipsa facilis magni corporis doloribus eos quisquam tempora repellendus. Rerum, adipisci placeat consequatur iusto quidem nesciunt assumenda.<br /></p>
            </div>
        </div>
    )
}

export default Main