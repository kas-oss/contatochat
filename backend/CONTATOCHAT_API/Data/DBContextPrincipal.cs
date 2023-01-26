using System;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;


namespace CONTATOCHAT_API.Data
{
    public class DBContext
    {
        private MySqlTransaction transaction;
        private MySqlConnection connection;
        private bool isAlreadyRolledBack = false;
        public static string ConnectionString { get; set; }

        public DBContext()
        {
            connection = this.GetConnection();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            transaction = connection.BeginTransaction();
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public DbCommand InicializeProcedure(String procedure)
        {
            var command = new MySqlCommand(procedure, connection)
            {
                CommandType = CommandType.StoredProcedure,

                Transaction = transaction
            };

            return command;
        }

        public DataSet SearchQueryDataSet(DbCommand command, String tabela)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter((MySqlCommand)command);
            da.Fill(ds);
            ds.Tables[0].TableName = tabela;
            return ds;
        }

        public int ExecutaNonQuery(DbCommand command)
        {
            try
            {
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                try
                {
                    transaction.Rollback();
                    isAlreadyRolledBack = true;
                }
                catch (Exception)
                {
                    //Do nothing
                }

                throw ex;
            }
        }

        public void CloseConnection()
        {

            connection.Close();
            connection.Dispose();
        }

        public void Commit()
        {
            if (transaction.Connection != null)
            {
                transaction.Commit();
            }
        }

        public bool IsClosed
        {
            get
            {
                return connection.State == ConnectionState.Closed;
            }
        }

        public void Rollback()
        {
            if (transaction.Connection != null && !isAlreadyRolledBack)
                transaction.Rollback();

        }
    }
}
