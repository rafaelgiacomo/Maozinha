using Maozinha.Model;
using Maozinha.Repository;
using System;
using System.Collections.Generic;

namespace Maozinha.Business
{
    public class ArquivoVoluntarioBusiness
    {

        #region Constantes

        private string _connectionString;

        #endregion

        #region Métodos Públicos

        public ArquivoModel SelecionarArquivoPorId(int projetoId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    ArquivoModel entidade = new ArquivoModel();

                    entidade.Id = projetoId;

                    return unit.ArquivosVoluntarios.SelecionarPorId(entidade);
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
                    return unit.ArquivosVoluntarios.ListarTodosVoluntario(entidadeId);
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
                    unit.ArquivosVoluntarios.Inserir(entidade, entidadeId);
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

                    unit.ArquivosVoluntarios.Excluir(id, entidadeId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DefinirProximoId()
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    return unit.ArquivosVoluntarios.DefinirProximoId();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        public ArquivoVoluntarioBusiness(string connectionString)
        {
            _connectionString = connectionString;
        }

    }
}