import { useContext, useEffect, useState, useCallback } from 'react'
import './Chat.css'

import { UserContext } from '../../hooks/UserContext'
import apiRoute from '../../services/api'

import Contacts from '../../components/Contact/Contact'
import Message from '../../components/Message/Message'

const Chat = () => {
  const { logout, contacts, messages, user, updateListContacts, updateListMessages } = useContext(UserContext)
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
    const res = await apiRoute.sendMessage(data)
    setMessagesData(res.data)
  }

  const loadMessages = useCallback(async (id) => {
    try {
      if (id) {
        const res = await apiRoute.loadMessages(id)
        setMessagesData(res.data)
      }
    } catch (error) {
      console.error(error)
    }
  }, [])

  const loadContact = useCallback(async (p1Name, p2Name, p1Id, p2Id) => {
    await updateListMessages()
    try {
      let idMessage;
      const hasChat = messages.current.find(chat => chat.nome === p1Name + p2Name || chat.nome === p2Name + p1Name)
      if (hasChat) {
        setChatInfo(hasChat)
        idMessage = hasChat.id
        setChatInfo(hasChat)
      } else {
        const chat = {
          nome: p1Name + p2Name,
          foto: "string",
          id: 0,
          participante1: p1Id,
          participante2: p2Id
        }
        if (chat.participante2) {
          const res = await apiRoute.loadChat(chat)
          idMessage = res.data.id
          setChatInfo(res.data)
        }
      }
      loadMessages(idMessage)

    } catch (error) {
      console.error(error)
    }
  }, [loadMessages, updateListMessages, messages])

  useEffect(() => {
    loadContact(user.name, contactActive.nome, user.id, contactActive.id)
  }, [loadContact, contactActive, user])

  useEffect(() => {
    const update = setInterval(() => {
      loadMessages(chatInfo.id).catch(e => console.error(e))
      updateListContacts().catch(e => console.error(e))
    }, 5000);

    return () => clearInterval(update)
  }, [chatInfo, loadMessages, updateListContacts])

  return (
    <div className="containerChat">
      <Contacts logout={logout} contactList={[...contacts]} user={user} contactActive={contactActive} setContactActive={setContactActive} />
      <Message user={user} sendMessage={sendMessage} messagesData={messagesData} contactActive={contactActive} />
    </div>
  )
}

export default Chat