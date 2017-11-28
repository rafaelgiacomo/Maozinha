using Maozinha.Model;
using Maozinha.Repository;
using System;
using System.Collections.Generic;

namespace Maozinha.Business
{
    public class VoluntarioBusiness
    {
        private string _connectionString;

        public List<VoluntarioModel> ListarCandidatosPorProjeto(int projetoId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    return unit.Voluntarios.ListarCandidatosProjeto(projetoId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<VoluntarioModel> ListarSelecionadosPorProjeto(int projetoId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    return unit.Voluntarios.ListarSelecionadosProjeto(projetoId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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

        public VoluntarioModel SelecionarPorId(int id)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    VoluntarioModel entidade = new VoluntarioModel();

                    entidade.Id = id;

                    return unit.Voluntarios.SelecionarPorId(entidade);
                }
            }
            catch (Exception ex)
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