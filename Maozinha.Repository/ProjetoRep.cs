using Maozinha.Interface;
using Maozinha.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Maozinha.Repository
{
    public class ProjetoRep : IRepositorioGenerico<ProjetoModel>
    {
        private Context _context;

        #region Constantes

        private const string PROCEDURE_LISTAR_TODOS = "SP_LISTAR_TODOS_PROJETOS";
        private const string PROCEDURE_LISTAR_PROJETOS_ENTIDADE = "SP_LISTAR_PROJETOS_ENTIDADE";
        private const string PROCEDURE_SELECIONAR_ID = "SP_SELECIONAR_PROJETO_ID";
        private const string PROCEDURE_SALVAR = "SP_SALVAR_PROJETO";
        private const string PROCEDURE_ALTERAR = "SP_ALTERAR_PROJETO";
        private const string PROCEDURE_EXCLUIR = "SP_EXCLUIR_PROJETO";

        public const string COLUNA_ID = "Id";
        public const string COLUNA_NOME = "Nome";
        public const string COLUNA_DESCRICAO = "Descricao";
        public const string COLUNA_DATA_INICIO = "DataInicio";
        public const string COLUNA_DATA_FIM = "DataFim";
        public const string COLUNA_UF = "Uf";
        public const string COLUNA_CIDADE = "Cidade";
        public const string COLUNA_ENDERECO = "Endereco";
        public const string COLUNA_QTD_VAGAS = "QtdVagas";
        public const string COLUNA_ARQUIVO_ID = "ArquivoId";
        public const string COLUNA_ENTIDADE_ID = "EntidadeId";
        public const string COLUNA_CATEGORIA_ID = "CategoriaId";

        #endregion

        #region Metodos Publicos

        public void Alterar(ProjetoModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    COLUNA_NOME, COLUNA_DESCRICAO, COLUNA_DATA_INICIO, COLUNA_DATA_FIM, COLUNA_UF, COLUNA_CIDADE, COLUNA_ENDERECO,
                    COLUNA_QTD_VAGAS, COLUNA_ENTIDADE_ID, COLUNA_CATEGORIA_ID, COLUNA_ID
                };

                object[] values =
                {
                    entidade.Nome, entidade.Descricao, entidade.DataInicio, entidade.DataFim, entidade.Uf, entidade.Cidade, entidade.Endereco,
                    entidade.QtdVagas, entidade.EntidadeId,entidade.CategoriaId, entidade.Id
                };

                _context.ExecuteProcedureNoReturn(PROCEDURE_ALTERAR, parameters, values);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(ProjetoModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    COLUNA_ID
                };

                object[] values =
                {
                    entidade.Id
                };

                _context.ExecuteProcedureNoReturn(PROCEDURE_EXCLUIR, parameters, values);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Inserir(ProjetoModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    COLUNA_NOME, COLUNA_DESCRICAO, COLUNA_DATA_INICIO, COLUNA_DATA_FIM, COLUNA_UF, COLUNA_CIDADE, COLUNA_ENDERECO,
                    COLUNA_QTD_VAGAS, COLUNA_ENTIDADE_ID, COLUNA_CATEGORIA_ID
                };

                object[] values =
                {
                    entidade.Nome, entidade.Descricao, entidade.DataInicio, entidade.DataFim, entidade.Uf, entidade.Cidade, entidade.Endereco,
                    entidade.QtdVagas, entidade.EntidadeId,entidade.CategoriaId
                };

                _context.ExecuteProcedureNoReturn(PROCEDURE_SALVAR, parameters, values);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProjetoModel SelecionarPorId(ProjetoModel entidade)
        {
            try
            {
                ProjetoModel entidadeRet = null;
                SqlDataReader reader = null;

                string[] parameters = { COLUNA_ID };
                object[] values = { entidade.Id };

                reader = _context.ExecuteProcedureWithReturn(PROCEDURE_SELECIONAR_ID, parameters, values);

                if (reader.Read())
                {
                    entidadeRet = ReaderEmObjeto(reader);
                }

                reader.Close();

                return entidadeRet;
            }
            catch (Exception ex)
            {
                throw new Exception("Classe: TipoUsuarioRep, Metodo: ListarTodos Mensagem: " + ex.Message, ex);
            }
        }

        public List<ProjetoModel> ListarTodos()
        {
            try
            {
                List<ProjetoModel> lista = new List<ProjetoModel>();
                SqlDataReader reader = null;

                string[] parameters = { };
                object[] values = { };

                reader = _context.ExecuteProcedureWithReturn(PROCEDURE_LISTAR_TODOS, parameters, values);

                while (reader.Read())
                {
                    var entidade = ReaderEmObjeto(reader);

                    lista.Add(entidade);
                }

                reader.Close();

                return lista;
            }
            catch(Exception ex)
            {
                throw new Exception("Classe: TipoUsuarioRep, Metodo: ListarTodos Mensagem: " + ex.Message, ex);
            }
        }

        public List<ProjetoModel> ListarProjetosEntidadeId(ProjetoModel entidade)
        {
            try
            {
                List<ProjetoModel> lista = new List<ProjetoModel>();
                SqlDataReader reader = null;

                string[] parameters = { COLUNA_ENTIDADE_ID };
                object[] values = { entidade.EntidadeId };

                reader = _context.ExecuteProcedureWithReturn(PROCEDURE_LISTAR_PROJETOS_ENTIDADE, parameters, values);

                while (reader.Read())
                {
                    var proj = ReaderEmObjeto(reader);

                    lista.Add(proj);
                }

                reader.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Classe: TipoUsuarioRep, Metodo: ListarTodos Mensagem: " + ex.Message, ex);
            }
        }

        #endregion

        #region Metodos Privados

        private ProjetoModel ReaderEmObjeto(SqlDataReader reader)
        {
            var entidade = new ProjetoModel();

            entidade.Id = Convert.ToInt32(reader[COLUNA_ID]);
            entidade.Nome = reader[COLUNA_NOME].ToString();
            entidade.Uf = reader[COLUNA_UF].ToString();
            entidade.Cidade = reader[COLUNA_CIDADE].ToString();
            entidade.Endereco = reader[COLUNA_ENDERECO].ToString();
            entidade.Descricao = reader[COLUNA_DESCRICAO].ToString();

            var qtdVagas = reader[COLUNA_QTD_VAGAS].ToString();
            var entidadeId = reader[COLUNA_ENTIDADE_ID].ToString();
            var categoriaId = reader[COLUNA_CATEGORIA_ID].ToString();
            var arquivoId = reader[COLUNA_ARQUIVO_ID].ToString();
            var dataInicio = reader[COLUNA_DATA_INICIO].ToString();
            var dataFim = reader[COLUNA_DATA_FIM].ToString();

            if (!"".Equals(qtdVagas))
            {
                entidade.QtdVagas = int.Parse(qtdVagas);
            }

            if (!"".Equals(entidadeId))
            {
                entidade.EntidadeId = int.Parse(entidadeId);
            }

            if (!"".Equals(categoriaId))
            {
                entidade.CategoriaId = int.Parse(categoriaId);
            }

            if (!"".Equals(arquivoId))
            {
                entidade.ArquivoId = int.Parse(arquivoId);
            }

            if (!"".Equals(dataInicio))
            {
                entidade.DataInicio = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dataInicio));
            }

            if (!"".Equals(dataFim))
            {
                entidade.DataFim = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dataFim));
            }

            return entidade;
        }

        #endregion

        public ProjetoRep(Context context)
        {
            _context = context;
        }

    }
}
