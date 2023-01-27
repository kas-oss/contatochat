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

        public DataTable ListContato()
        {
            MySqlCommand command = (MySqlCommand)_context.InicializeProcedure("listarContatos");

            DataTable dataTable = new DataTable("usuarios");
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(dataTable);

            if (_internalSession)
            {
                _context.CloseConnection();
            }

            return dataTable;
        }

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

    }
}
