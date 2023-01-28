import './List.css'

const List = ({ contactList, contactActive, setContactActive }) => {
    return (
        <div className="chat-list">
            {contactList.map(contact => (
                <div key={contact.id} className={`block ${contactActive.id === contact.id && "active"}`} onClick={()=> setContactActive(contact)}>
                    <div className="details">
                        <div className="list-head">
                            <h4>{contact.nome}</h4>
                        </div>
                    </div>
                </div>
            ))
            }
        </div>
    )
}

export default List