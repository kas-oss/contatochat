import './Contact.css'

import Header from './Header/Header'
import Search from './Search/Search'
import List from './List/List'

const Contact = ({ logout }) => {
  return (
    <div className="leftSide">
      <Header logout={logout} />
      <Search />
      <List />
    </div>
  )
}

export default Contact