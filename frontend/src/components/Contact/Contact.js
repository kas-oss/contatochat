import './Contact.css'

import Header from './Header/Header'
import Search from './Search/Search'
import List from './List/List'

const Contact = () => {
  return (
    <div className="leftSide">
      <Header />
      <Search />
      <List/>
    </div>
  )
}

export default Contact