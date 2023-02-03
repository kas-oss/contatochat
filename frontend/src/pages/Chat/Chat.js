import { useContext, useEffect, useState, useCallback } from 'react'
import './Chat.css'

import { UserContext } from '../../hooks/UserContext'
import apiRoute from '../../services/api'

import Contacts from '../../components/Contact/Contact'
import Message from '../../components/Message/Message'

const Chat = () => {
  const { logout, contacts, user, updateListContacts } = useContext(UserContext)
  const [contactActive, setContactActive] = useState({})
  const [chatInfo, setChatInfo] = useState({})
  const [messagesData, setMessagesData] = useState({})

  const sendMessage = async (message) => {
    const data = {
      conteudo: message,
      contatoId: user.id,
      conversaId: chatInfo.id,
      tipoConteudo: 0
    }
    console.log(data)
    const res = await apiRoute.sendMessage(data)
    setMessagesData(res.data)
  }

  const loadMessages = useCallback(async (id) => {
    
    try {
      if (!id) throw new Error('Dados insuficientes M')
      const res = await apiRoute.loadMessages(id)
      setMessagesData(res.data)
    } catch (error) {
      console.error(error)
    }
  }, [])

  const loadContact = useCallback(async (nameChat, p1, p2) => {
    try {
      const chat = {
        nome: nameChat,
        foto: "string",
        id: 0,
        participante1: p1,
        participante2: p2
      }
      console.log(chat)
      if (!chat.participante2) throw new Error('Dados insuficientes')
      const res = await apiRoute.loadChat(chat)
      setChatInfo(res.data)
      console.log(res.data)
      loadMessages(res.data.id)
    } catch (error) {
      console.error(error)
    }
  }, [loadMessages])

  useEffect(() => {
    loadContact(contactActive.nome, user.id, contactActive.id)
  }, [loadContact, contactActive, user])

  // useEffect(() => {
  //   const update = setInterval(() => {
  //     loadMessages(chatInfo.id)
  //       .then(() => console.log('ok'))
  //       .catch(e => console.error(e))

  //       updateListContacts()
  //       .then(() => console.log('ok2'))
  //       .catch(e => console.error(e))
  //   }, 10000);

  //   return () => clearInterval(update)
  // }, [chatInfo, loadMessages, updateListContacts])

  return (
    <div className="containerChat">
      <Contacts logout={logout} contactList={contacts} user={user} contactActive={contactActive} setContactActive={setContactActive} />
      <Message user={user} sendMessage={sendMessage} messagesData={messagesData} contactActive={contactActive} />
    </div>
  )
}

export default Chat