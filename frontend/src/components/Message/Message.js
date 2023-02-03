import './Message.css'

import Header from './Header/Header'
import Main from './Main/Main'
import Footer from './Footer/Footer'

const Message = ({contactActive, sendMessage, messagesData, user}) => {
  return (
    <div className="rightSide">
      <Header contactActive={contactActive}/>
      <Main user={user} messagesData={messagesData}/>
      <Footer contactActive={contactActive} sendMessage={sendMessage}/>
    </div>
  )
}

export default Message