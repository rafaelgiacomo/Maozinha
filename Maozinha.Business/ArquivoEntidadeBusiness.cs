using Maozinha.Model;
using Maozinha.Repository;
using System;
using System.Collections.Generic;

namespace Maozinha.Business
{
    public class ArquivoEntidadeBusiness
    {
        private string _connectionString;

        public ArquivoModel SelecionarArquivoPorId(int projetoId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    ArquivoModel entidade = new ArquivoModel();

                    entidade.Id = projetoId;

                    return unit.ArquivosEntidades.SelecionarPorId(entidade);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ArquivoModel> ListarPorEntidade(int entidadeId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    return unit.ArquivosEntidades.ListarTodosEntidade(entidadeId);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void InserirArquivo(ArquivoModel entidade, int entidadeId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    unit.ArquivosEntidades.Inserir(entidade, entidadeId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirArquivo(int id, int entidadeId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    var entidade = new ProjetoModel();
                    entidade.Id = id;

                    unit.ArquivosEntidades.Excluir(id, entidadeId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ArquivoEntidadeBusiness(string connectionString)
        {
            _connectionString = connectionString;
        }

    }
}