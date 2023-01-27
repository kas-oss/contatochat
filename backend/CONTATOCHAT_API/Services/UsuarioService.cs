using System.Collections.Generic;
using System.Data;
using System;
using CONTATOCHAT_API.Models;

namespace CONTATOCHAT_API.Services
{
    public class UsuarioService : IUsuarioService
    {

        public List<Contato> ListContato()
        {
            var dataTable = new Data.Chat().ListContato();
            var contatoList = new List<Contato>();

            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    var contato = new Contato
                    {
                        id       = Convert.ToInt32(row["id"]),
                        nome     = row["nome"].ToString(),
                        email    = row["email"].ToString(),
                        telefone = row["telefone"].ToString(),
                    };
                    contatoList.Add(contato);
                }
            }
            return contatoList;
        }

        public List<Conversa> ListConvesaId(int id)
        {
            new Data.Chat();

            var conversas = new List<Conversa>();

            return conversas;
        }

        public int RegistrarUsuario(NovoUsuario usuario)
        {

            var idContato = new Data.Chat().RegistrarUsuario(usuario);

            return idContato;
        }



    }
}
