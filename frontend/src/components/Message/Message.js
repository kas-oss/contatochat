import './Message.css'

import Header from './Header/Header'
import Main from './Main/Main'
import Footer from './Footer/Footer'

const Message = ({contactActive}) => {
  return (
    <div className="rightSide">
      <Header contactActive={contactActive}/>
      <Main contactActive={contactActive}/>
      <Footer contactActive={contactActive}/>
    </div>
  )
}

export default Message