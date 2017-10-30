using Maozinha.Model;
using Maozinha.Repository;
using System;
using System.Collections.Generic;

namespace Maozinha.Business
{
    public class ProjetoBusiness
    {
        private string _connectionString;

        public ProjetoModel SelecionarProjetoPorId(int projetoId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    ProjetoModel entidade = new ProjetoModel();

                    entidade.Id = projetoId;

                    return unit.Projetos.SelecionarPorId(entidade);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProjetoModel> ListarPorEntidade(int entidadeId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    ProjetoModel entidade = new ProjetoModel();

                    entidade.EntidadeId = entidadeId;

                    return unit.Projetos.ListarProjetosEntidadeId(entidade);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void InserirProjeto(ProjetoModel entidade)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    unit.Projetos.Inserir(entidade);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarProjeto(ProjetoModel entidade)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    unit.Projetos.Alterar(entidade);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirProjeto(int id)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    var entidade = new ProjetoModel();
                    entidade.Id = id;

                    unit.Projetos.Excluir(entidade);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProjetoBusiness(string connectionString)
        {
            _connectionString = connectionString;
        }

    }
}