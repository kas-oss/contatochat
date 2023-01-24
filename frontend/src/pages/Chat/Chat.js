import { useContext } from 'react'
import './Chat.css'

import { UserContext } from '../../hooks/UserContext'

import Contacts from '../../components/Contact/Contact'
import Message from '../../components/Message/Message'


const Chat = () => {
  const { logout } = useContext(UserContext)  

  return (
    <div className="containerChat">
      <Contacts logout={logout} />
      <Message />
    </div>
  )
}

export default Chat