using Maozinha.Model;
using Maozinha.Repository;
using System;
using System.Collections.Generic;

namespace Maozinha.Business
{
    public class ProjetoBusiness
    {
        private string _connectionString;

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
                    var tipo = new TipoUsuarioModel();
                    tipo.Descricao = TipoUsuarioModel.DescricaoEntidade;

                    unit.Projetos.Inserir(entidade);
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