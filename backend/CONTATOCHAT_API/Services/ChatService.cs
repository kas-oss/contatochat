using System.Collections.Generic;
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
                DataRow row1 = dataTable.Tables[2].Rows[0];
                DataRow row2 = dataTable.Tables[2].Rows[1];

                conversa.id = Convert.ToInt32(row1["id"]);
                conversa.nome = row1["nome"].ToString();
                conversa.foto = row1["foto_conversa"].ToString();
                conversa.participante1 = Convert.ToInt32(row1["contato_id"]);
                conversa.participante2 = Convert.ToInt32(row2["contato_id"]);
            }

            return conversa;
        }

        public Conversa GetConversa(int id) 
        {
            var dataSet = new Data.Chat().GetConversa(id);
            var conversa = new Conversa()
            {
                contatoList = new List<Contato>(),
                mensagemList= new List<Mensagem>()
            };

            if (dataSet.Tables.Count == 3)
            {
                DataTable dtConversa    = dataSet.Tables[0];

                conversa.id = Convert.ToInt32(dtConversa.Rows[0]["id"]);
                conversa.nome = dtConversa.Rows[0]["nome"].ToString();
                conversa.foto = dtConversa.Rows[0]["foto_conversa"].ToString();

                DataTable dtContatos    = dataSet.Tables[1];

                foreach (DataRow row in dtContatos.Rows)
                {
                    var contato = new Contato
                    {
                        id          = Convert.ToInt32(row["id"]),
                        nome        = row["nome"].ToString(),
                        email       = row["email"].ToString(),
                        telefone    = row["telefone"].ToString(),
                        fotoPerfil = row["foto_perfil"].ToString()
                    };
                    
                    conversa.contatoList.Add(contato);
                }

                DataTable dtMensagens   = dataSet.Tables[2];

                foreach (DataRow row in dtMensagens.Rows)
                {
                    var contato = new Mensagem()
                    {
                        id              = Convert.ToInt32(row["id"]),
                        contatoId       = Convert.ToInt32(row["contato_id"]),
                        conversaId      = Convert.ToInt32(row["conversa_id"]),
                        conteudo        = row["conteudo"].ToString(),

                        tipoConteudo = Convert.ToInt32(row["tipo_conteudo"]),
                        dataHora = Convert.ToDateTime(row["dt_inicio"])
                    };

                    conversa.mensagemList.Add(contato);
                }
            }

            return conversa;
        }

        public void EnviarMensagem(reqMensagem msg)
        {
            new Data.Chat().EnviarMensagem(msg);
        }

    }
}
