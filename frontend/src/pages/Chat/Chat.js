import './Chat.css'

import Contacts from '../../components/Contact/Contact'
import Message from '../../components/Message/Message'

const Chat = () => {
  return (
    <div className="containerChat">
      <Contacts />
      <Message />
    </div>
  )
}

export default Chat