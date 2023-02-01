using System;
using System.Data;
using CONTATOCHAT_API.Models;
using MySql.Data.MySqlClient;

namespace CONTATOCHAT_API.Data
{
    public class Chat
    {
        readonly DBContext _context;
        readonly bool _internalSession = false;

        public Chat()
        {
            _internalSession = true;
            _context = new DBContext();
        }

        public Chat(DBContext context)
        {
            _context = context;
        }

        #region "Serviços de Usuário"

        public int RegistrarUsuario(NovoUsuario contato)
        {
            MySqlCommand command = (MySqlCommand)_context.InicializeProcedure("RegistrarUsuario");
            command.Parameters.AddWithValue("@nome", contato.name);
            command.Parameters.AddWithValue("@email", contato.email);
            command.Parameters.AddWithValue("@telefone", contato.phone);
            command.Parameters.AddWithValue("@foto_perfil", contato.profilePicture);
            command.Parameters.AddWithValue("@senha", contato.pass);


            command.Parameters.Add("@id", MySqlDbType.Bit);
            
            command.Parameters["@id"].Direction = ParameterDirection.Output;


            _context.ExecutaNonQuery(command);

            var result = Convert.ToInt32(command.Parameters["@id"].Value);

            if (_internalSession)
            {
                _context.Commit();
                _context.CloseConnection();
            }

            return result;
        }


        public DataSet CriarConversa(ConversaCreate conversaCreate)
        {
            MySqlCommand command = (MySqlCommand)_context.InicializeProcedure("criarConversa");
            command.Parameters.AddWithValue("@id", conversaCreate.id);
            command.Parameters.AddWithValue("@nome", conversaCreate.nome);
            command.Parameters.AddWithValue("@foto_conversa", conversaCreate.foto);
            command.Parameters.AddWithValue("@participante1_id", conversaCreate.participante1);
            command.Parameters.AddWithValue("@participante2_id", conversaCreate.participante2);

            DataSet dt = new DataSet("conversa");
            //DataTable dataTable = new DataTable("convesa");


            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            adapter.Fill(dt);

            //adapter.Fill(dataTable);

            if (_internalSession)
            {
                _context.CloseConnection();
            }

            return dt;
        }


        public DataTable ConsultarUsuario(int id)
        {
            MySqlCommand command = (MySqlCommand)_context.InicializeProcedure("listarUsuario");
            command.Parameters.AddWithValue("@id", id);

            DataTable dataTable = new DataTable("usuarios");
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(dataTable);

            if (_internalSession)
            {
                _context.CloseConnection();
            }

            return dataTable;
        }

        public DataTable TestLogin(UsuarioLogin login)
        {
            MySqlCommand command = (MySqlCommand)_context.InicializeProcedure("testLogin");
            command.Parameters.AddWithValue("@login", login.login);
            command.Parameters.AddWithValue("@pass", login.password);

            DataTable dataTable = new DataTable("usuarios");
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(dataTable);

            if (_internalSession)
            {
                _context.CloseConnection();
            }

            return dataTable;
        }

        public DataTable ListContato()
        {
            MySqlCommand command = (MySqlCommand)_context.InicializeProcedure("listarContatos");

            DataTable dataTable = new DataTable("contatos");
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(dataTable);

            if (_internalSession)
            {
                _context.CloseConnection();
            }

            return dataTable;
        }

        public DataTable ListConversa(int id)
        {
            MySqlCommand command = (MySqlCommand)_context.InicializeProcedure("listarConversas");
            command.Parameters.AddWithValue("@id", id);

            DataTable dataTable = new DataTable("conversas");
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(dataTable);

            if (_internalSession)
            {
                _context.CloseConnection();
            }

            return dataTable;
        }

        #endregion
    }
}
