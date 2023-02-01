﻿using System.Collections.Generic;
using System.Data;
using System;
using CONTATOCHAT_API.Models;

namespace CONTATOCHAT_API.Services
{
    public class ChatService : IChatService
    {
        public ConversaCreate CriarConversa(ConversaCreate conversaCreate)
        {

            var dataTable = new Data.Chat().CriarConversa(conversaCreate);
            var conversa = new ConversaCreate();
           
            if (dataTable.Tables.Count > 0)
            {
                DataRow row1 = dataTable.Tables[1].Rows[0];
                DataRow row2 = dataTable.Tables[1].Rows[1];

                conversa.id = Convert.ToInt32(row1["id"]);
                conversa.nome = row1["nome"].ToString();
                conversa.foto = row1["foto_conversa"].ToString();
                conversa.participante1 = Convert.ToInt32(row1["contato_id"]);
                conversa.participante2 = Convert.ToInt32(row2["contato_id"]);
            }

            return conversa;
        }

    }
}
