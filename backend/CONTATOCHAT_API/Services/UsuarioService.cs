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
            var dataTable = new Data.Chat().ListConversa(id);
            var conversaList = new List<Conversa>();

            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    var conversa = new Conversa
                    {
                        id = Convert.ToInt32(row["id"]),
                        nome = row["nome"].ToString(),
                        foto = row["foto_conversa"].ToString(),
                    };
                    conversaList.Add(conversa);
                }
            }


            var conversas = new List<Conversa>();

            return conversas;
        }

        public Usuario ConsultarUsuarioId(int id)
        {
            var dataTable = new Data.Chat().ConsultarUsuario(id);
            var usuario = new Usuario();

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                usuario.id = Convert.ToInt32(row["id"]);
                usuario.name = row["nome"].ToString();
                usuario.email = row["email"].ToString();
                usuario.telefone = row["telefone"].ToString();
                usuario.fotoPerfil = row["foto_perfil"].ToString();
            }
            return usuario;
        }

        public Usuario TestLogin(UsuarioLogin login)
        {
            var dataTable = new Data.Chat().TestLogin(login);
            var usuario = new Usuario();

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                usuario.id = Convert.ToInt32(row["id"]);
                usuario.name = row["nome"].ToString();
                usuario.email = row["email"].ToString();
                usuario.telefone = row["telefone"].ToString();
                usuario.fotoPerfil = row["foto_perfil"].ToString();
            }
            return usuario;
        }


        public int RegistrarUsuario(NovoUsuario usuario)
        {

            var idContato = new Data.Chat().RegistrarUsuario(usuario);

            return idContato;
        }



    }
}
