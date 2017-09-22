using System;
using System.Data;
using System.Data.SqlClient;

namespace Maozinha.Repository
{
    public class Context : IDisposable
    {
        private readonly SqlConnection _myConnection;
        private SqlTransaction _tran;

        public Context(string conString)
        {
            try
            {
                _myConnection = new SqlConnection(conString);
            }
            catch
            {
                throw;
            }
        }

        public SqlDataReader ExecuteProcedureWithReturn(
            string procedureName, string[] parameters, params object[] values)
        {
            try
            {
                SqlDataReader reader = null;

                var cmdComando = new SqlCommand
                {
                    CommandText = procedureName,
                    CommandType = CommandType.StoredProcedure,
                    Connection = _myConnection,
                    Transaction = _tran
                };

                for (int i = 0; i < parameters.Length; i++)
                {
                    cmdComando.Parameters.AddWithValue(parameters[i], values[i]);
                }

                reader = cmdComando.ExecuteReader();

                return reader;
            }
            catch
            {
                throw;
            }
        }

        public void ExecuteProcedureNoReturn(string procedureName,
            string[] parameters, params object[] values)
        {
            try
            {
                var cmdComando = new SqlCommand
                {
                    CommandText = procedureName,
                    CommandType = CommandType.StoredProcedure,
                    Connection = _myConnection,
                    Transaction = _tran
                };

                for (int i = 0; i < parameters.Length; i++)
                {
                    cmdComando.Parameters.AddWithValue(parameters[i], values[i]);
                }

                cmdComando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public void ExecuteProcedureNoReturnNoTransaction(string procedureName,
            string[] parameters, params object[] values)
        {
            try
            {
                var cmdComando = new SqlCommand
                {
                    CommandText = procedureName,
                    CommandType = CommandType.StoredProcedure,
                    Connection = _myConnection
                };

                for (int i = 0; i < parameters.Length; i++)
                {
                    cmdComando.Parameters.AddWithValue(parameters[i], values[i]);
                }

                cmdComando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public void ExecuteSqlCommandNoReturn(string command)
        {
            try
            {
                var cmdComando = new SqlCommand
                {
                    CommandText = command,
                    CommandType = CommandType.Text,
                    Connection = _myConnection,
                    Transaction = _tran
                };

                cmdComando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public SqlDataReader ExecuteSqlCommandWithReturn(string commmand)
        {
            try
            {
                SqlDataReader reader = null;

                var cmdComando = new SqlCommand
                {
                    CommandText = commmand,
                    CommandType = CommandType.Text,
                    Connection = _myConnection,
                    Transaction = _tran
                };

                reader = cmdComando.ExecuteReader();

                return reader;
            }
            catch
            {
                throw;
            }
        }

        public SqlDataReader ExecuteSqlCommandWithReturnNoTransaction(string commmand)
        {
            try
            {
                SqlDataReader reader = null;

                var cmdComando = new SqlCommand
                {
                    CommandText = commmand,
                    CommandType = CommandType.Text,
                    Connection = _myConnection
                };

                reader = cmdComando.ExecuteReader();

                return reader;
            }
            catch
            {
                throw;
            }
        }

        public void OpenTransaction()
        {
            _tran = _myConnection.BeginTransaction();
        }

        public void Commit()
        {
            _tran.Commit();
        }

        public void RollBack()
        {
            _tran.Rollback();
        }

        public void AbrirConexao()
        {
            if (_myConnection.State == ConnectionState.Closed)
            {
                _myConnection.Open();
            }
        }

        public void FecharConexao()
        {
            if (_myConnection.State == ConnectionState.Open)
            {
                _myConnection.Close();
            }
        }

        public void MudarBase(string nomeBase)
        {
            try
            {
                _myConnection.ChangeDatabase(nomeBase);
            }
            catch
            {
                throw;
            }

        }

        public void Dispose()
        {
            if (_myConnection.State == ConnectionState.Open)
            {
                _myConnection.Close();
            }
        }
    }
}
