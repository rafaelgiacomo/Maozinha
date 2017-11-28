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
                    List<ProjetoModel> listaProjetos = new List<ProjetoModel>();

                    entidade.EntidadeId = entidadeId;
                    listaProjetos = unit.Projetos.ListarProjetosEntidadeId(entidade);

                    foreach (var item in listaProjetos)
                    {
                        item.Arquivo = unit.ArquivosEntidades.SelecionarPorId(new ArquivoModel() { Id = item.ArquivoId });
                    }

                    return listaProjetos;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<ProjetoModel> ListarDisponiveis()
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    var listaProjetos = unit.Projetos.ListarProjetosDisponiveis();

                    foreach (var item in listaProjetos)
                    {
                        item.Arquivo = unit.ArquivosEntidades.SelecionarPorId(new ArquivoModel() { Id = item.ArquivoId });
                    }

                    return listaProjetos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProjetoModel> ListarPorVoluntarioAtuais(int voluntarioId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    var listaProjetos = unit.Projetos.ListarProjetosVoluntarioAtuais(voluntarioId);

                    foreach (var item in listaProjetos)
                    {
                        item.Arquivo = unit.ArquivosEntidades.SelecionarPorId(new ArquivoModel() { Id = item.ArquivoId });
                    }

                    return listaProjetos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProjetoModel> ListarPorVoluntarioPendentes(int voluntarioId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    var listaProjetos = unit.Projetos.ListarProjetosVoluntarioPendentes(voluntarioId);

                    foreach (var item in listaProjetos)
                    {
                        item.Arquivo = unit.ArquivosEntidades.SelecionarPorId(new ArquivoModel() { Id = item.ArquivoId });
                    }

                    return listaProjetos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProjetoModel> ListarPorVoluntarioConcluidos(int voluntarioId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    var listaProjetos = unit.Projetos.ListarProjetosVoluntarioConcluidos(voluntarioId);

                    foreach (var item in listaProjetos)
                    {
                        item.Arquivo = unit.ArquivosEntidades.SelecionarPorId(new ArquivoModel() { Id = item.ArquivoId });
                    }

                    return listaProjetos;
                }
            }
            catch (Exception ex)
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

        public int VerQtdSelecionados(int projetoId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    return unit.VoluntariosProjetos.QtdVoluntariosSelecionados(projetoId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool VerificarVoluntarioSelecionado(int projetoId, int voluntarioId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    return unit.VoluntariosProjetos.VerificarVoluntarioSelecionado(projetoId, voluntarioId);
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

        public void InserirCandidatoProjeto(int projetoId, int voluntarioId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    unit.VoluntariosProjetos.Inserir(voluntarioId, projetoId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SelecionarCandidatoProjeto(int projetoId, int voluntarioId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    unit.VoluntariosProjetos.SelecionarCandidatoProjeto(voluntarioId, projetoId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoverSelecionadoProjeto(int projetoId, int voluntarioId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    unit.VoluntariosProjetos.RemoverSelecionadoProjeto(voluntarioId, projetoId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirCandidatoProjeto(int projetoId, int voluntarioId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    unit.VoluntariosProjetos.Excluir(voluntarioId, projetoId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool VerificarCandidaturaVoluntario(int projetoId, int voluntarioId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    return unit.VoluntariosProjetos.VerificarCandidatoIncluso(voluntarioId, projetoId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DefinirImagemProjeto(int arquivoId, int projetoId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    unit.Projetos.AlterarImagem(arquivoId, projetoId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EncerrarSelecao(int projetoId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    unit.Projetos.EncerrarSelecao(projetoId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool VerificarProjetoEncerrado(int projetoId)
        {
            try
            {
                using (UnitOfWorkAdo unit = new UnitOfWorkAdo(_connectionString))
                {
                    return unit.Projetos.VerificarProjetoEncerrado(projetoId);
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