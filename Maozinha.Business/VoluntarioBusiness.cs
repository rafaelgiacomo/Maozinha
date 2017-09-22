using Maozinha.Model;
using Maozinha.Repository;
using System;

namespace Maozinha.Business
{
    public class VoluntarioBusiness
    {
        private string _connectionString;

        public VoluntarioModel SelecionarPorLogin(string login)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    VoluntarioModel entidade = new VoluntarioModel();

                    entidade.Login = login;

                    return unit.Voluntarios.SelecionarPorLogin(entidade);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void InserirVoluntario(VoluntarioModel entidade)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    var tipo = new TipoUsuarioModel();
                    tipo.Descricao = TipoUsuarioModel.DescricaoVoluntario;

                    entidade.TipoUsuario = unit.TiposUsuario.SelecionarPorDescricao(tipo);
                    entidade.RoleId = entidade.TipoUsuario.Id;
                    entidade.Descriminador = UsuarioModel.DescriminadorVoluntario;

                    unit.Voluntarios.Inserir(entidade);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VoluntarioBusiness(string connectionString)
        {
            _connectionString = connectionString;
        }

    }
}