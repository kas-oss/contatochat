using System.Collections.Generic;
using System.Data;
using System;
using CONTATOCHAT_API.Models;

namespace CONTATOCHAT_API.Services
{
    public class UsuarioService : IUsuarioService
    {

        public List<Contato> ListUsuarios()
        {
            var dataTable = new Data.Chat().ListUsuarios();
            var contatoList = new List<Contato>();

            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    var contato = new Contato
                    {
                        id      = Convert.ToInt32(row["id"]),
                        name    = row["nome"].ToString(),
                        email   = row["email"].ToString(),
                        phone   = row["telefone"].ToString(),
                    };
                    contatoList.Add(contato);
                }
            }
            return contatoList;
        }

        public int RegistrarContato(NovoContato contato)
        {

            var idContato = new Data.Chat().RegistrarContato(contato);

            return idContato;
        }



    }
}
