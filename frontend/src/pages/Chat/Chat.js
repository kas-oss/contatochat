import { useContext, useState } from 'react'
import './Chat.css'

import { UserContext } from '../../hooks/UserContext'

import Contacts from '../../components/Contact/Contact'
import Message from '../../components/Message/Message'


const Chat = () => {
  const { logout, contacts, user } = useContext(UserContext)  
  const [contactActive, setContactActive] = useState({})
  return (
    <div className="containerChat">
      <Contacts logout={logout} contactList={contacts} user={user} contactActive={contactActive} setContactActive={setContactActive}/>
      <Message contactActive={contactActive}/>
    </div>
  )
}

export default Chat