import './Contact.css'

import Header from './Header/Header'
import Search from './Search/Search'
import List from './List/List'
import { useState } from 'react'

const Contact = ({ logout, contactList, user, contactActive, setContactActive }) => {
  let [contactsFiltered, setContactsFiltered] = useState(contactList)

  const filterContact = (text) =>{
      text = text.toLowerCase()
      setContactsFiltered(contactList.filter(user => user.nome.toLowerCase().includes(text)))

      if(text === '') setContactsFiltered(contactList)
  }

  const clearContact = (text) =>{
      if(text === '') setContactsFiltered(contactList)
  }

  return (
    <div className="leftSide">
      <Header user={user} logout={logout} />
      <Search filterContact={filterContact} clearContact={clearContact}/>
      <List contactList={contactsFiltered} contactActive={contactActive} setContactActive={setContactActive}/>
    </div>
  )
}

export default Contact