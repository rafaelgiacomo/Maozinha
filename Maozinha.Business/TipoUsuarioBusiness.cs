using Maozinha.Model;
using Maozinha.Repository;
using System.Collections.Generic;

namespace Maozinha.Business
{
    public class TipoUsuarioBusiness
    {

        private string _connectionString;

        public TipoUsuarioBusiness(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TipoUsuarioModel SelecionarTipoUsuarioPorId(int id)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    TipoUsuarioModel entidade = new TipoUsuarioModel();

                    entidade.Id = id;

                    return unit.TiposUsuario.SelecionarPorId(entidade);
                }
            }
            catch
            {
                throw;
            }
        }

        public List<TipoUsuarioModel> ListarTodosTiposUsuario()
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    return unit.TiposUsuario.ListarTodos();
                }
            }
            catch
            {
                throw;
            }
        }

    }

}
