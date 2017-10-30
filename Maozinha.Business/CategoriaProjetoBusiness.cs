using Maozinha.Model;
using Maozinha.Repository;
using System;
using System.Collections.Generic;

namespace Maozinha.Business
{
    public class CategoriaProjetoBusiness
    {
        private string _connectionString;

        public List<CategoriaProjetoModel> ListarTodasCategorias()
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    return unit.CategoriasProjeto.ListarTodos();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public CategoriaProjetoModel SelecionarCategoriaPorId(int id)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    CategoriaProjetoModel cat = new CategoriaProjetoModel();

                    return unit.CategoriasProjeto.SelecionarPorId(cat);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CategoriaProjetoBusiness(string connectionString)
        {
            _connectionString = connectionString;
        }

    }
}