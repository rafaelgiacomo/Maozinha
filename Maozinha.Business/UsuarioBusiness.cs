using Maozinha.Model;
using Maozinha.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maozinha.Business
{
    public class UsuarioBusiness
    {
        private string _connectionString;

        public UsuarioModel SelecionarPorLogin(string login)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    UsuarioModel entidade = new UsuarioModel();

                    entidade.Login = login;

                    return unit.Usuarios.SelecionarPorLogin(entidade);
                }
            }
            catch
            {
                throw;
            }
        }

        public UsuarioBusiness(string connectionString)
        {
            _connectionString = connectionString;
        }

    }
}