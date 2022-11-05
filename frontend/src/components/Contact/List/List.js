import './List.css'

const List = () => {
    return (
        <div className="chat-list">
            <div className="block active">
                <div className="details">
                    <div className="list-head">
                        <h4>Felipe Nascimento</h4>
                        <p className="time">14:29</p>
                    </div>
                    <div className="message-p">
                        <p>Boa tarde. Só lembrando do nosso trabalho de Design-Patterns.</p>
                        <b>2</b>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default List