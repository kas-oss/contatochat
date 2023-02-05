import './Contact.css'

import Header from './Header/Header'
import Search from './Search/Search'
import List from './List/List'
import { useState } from 'react'

const Contact = ({ logout, contactList, user, contactActive, setContactActive }) => {
  const [contactsFiltered, setContactsFiltered] = useState(null)

  const clearContact = (text) => {
    if (text === '') setContactsFiltered(null)
  }

  const filterContact = (text) => {
    text = text.toLowerCase()
    const value = contactList.filter(user => user.nome.toLowerCase().includes(text))
    setContactsFiltered(value)

    clearContact(text)
  }

  return (
    <div className="leftSide">
      <Header user={user} logout={logout} />
      <Search filterContact={filterContact} clearContact={clearContact} />
      <List contactList={contactsFiltered || contactList} contactActive={contactActive} setContactActive={setContactActive} />
    </div>
  )
}

export default Contact