using Maozinha.Model;
using Maozinha.Repository;
using System;

namespace Maozinha.Business
{
    public class EntidadeBusiness
    {
        private string _connectionString;

        public EntidadeModel SelecionarPorLogin(string login)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    EntidadeModel entidade = new EntidadeModel();

                    entidade.Login = login;

                    return unit.Entidades.SelecionarPorLogin(entidade);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void InserirEntidade(EntidadeModel entidade)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    var tipo = new TipoUsuarioModel();
                    tipo.Descricao = TipoUsuarioModel.DescricaoEntidade;

                    entidade.TipoUsuario = unit.TiposUsuario.SelecionarPorDescricao(tipo);
                    entidade.RoleId = entidade.TipoUsuario.Id;
                    entidade.Descriminador = UsuarioModel.DescriminadorEntidade;

                    unit.Entidades.Inserir(entidade);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EntidadeBusiness(string connectionString)
        {
            _connectionString = connectionString;
        }

    }
}