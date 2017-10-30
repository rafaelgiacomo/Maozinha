using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maozinha.Interface;
using Maozinha.Model;
using System.Data.SqlClient;

namespace Maozinha.Repository
{
    public class ArquivoEntidadeRep
    {
        private Context _context;

        #region Constantes

        private const string PROCEDURE_LISTAR_ARQUIVOS_ENTIDADE = "SP_LISTAR_ARQUIVOS_ENTIDADE";
        private const string PROCEDURE_SELECIONAR_ID = "SP_SELECIONAR_ARQUIVO_ID";
        private const string PROCEDURE_SALVAR = "SP_SALVAR_ARQUIVO_ENTIDADE";
        private const string PROCEDURE_EXCLUIR = "SP_EXCLUIR_ARQUIVO_ENTIDADE";

        public const string COLUNA_ID = "Id";
        public const string COLUNA_TITULO = "Titulo";
        public const string COLUNA_DESCRICAO = "Descricao";
        public const string COLUNA_CAMINHO = "Caminho";
        public const string COLUNA_ENTIDADE_ID = "EntidadeId";

        #endregion

        #region Métodos Públicos

        public void Inserir(ArquivoModel entidade, int entidadeId)
        {
            try
            {
                string[] parameters =
                {
                    COLUNA_TITULO, COLUNA_DESCRICAO, COLUNA_CAMINHO, COLUNA_ENTIDADE_ID
                };

                object[] values =
                {
                    entidade.Titulo, entidade.Descricao, entidade.Caminho, entidadeId
                };

                _context.ExecuteProcedureNoReturn(PROCEDURE_SALVAR, parameters, values);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(int id, int entidadeId)
        {
            try
            {
                string[] parameters =
                {
                    COLUNA_ID, COLUNA_ENTIDADE_ID
                };

                object[] values =
                {
                    id, entidadeId
                };

                _context.ExecuteProcedureNoReturn(PROCEDURE_EXCLUIR, parameters, values);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ArquivoModel> ListarTodosEntidade(int entidadeId)
        {
            try
            {
                List<ArquivoModel> lista = new List<ArquivoModel>();
                SqlDataReader reader = null;

                string[] parameters = { COLUNA_ENTIDADE_ID };
                object[] values = { entidadeId };

                reader = _context.ExecuteProcedureWithReturn(PROCEDURE_LISTAR_ARQUIVOS_ENTIDADE, parameters, values);

                while (reader.Read())
                {
                    var entidade = ReaderEmObjeto(reader);

                    lista.Add(entidade);
                }

                reader.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Classe: ArquivoRep, Metodo: ListarTodos Mensagem: " + ex.Message, ex);
            }
        }

        public ArquivoModel SelecionarPorId(ArquivoModel entidade)
        {
            try
            {
                ArquivoModel entidadeRet = null;
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
                throw new Exception("Classe: ArquivoRep, Metodo: ListarTodos Mensagem: " + ex.Message, ex);
            }
        }

        #endregion

        #region Metodos Privados

        private ArquivoModel ReaderEmObjeto(SqlDataReader reader)
        {
            var entidade = new ArquivoModel();

            entidade.Id = Convert.ToInt32(reader[COLUNA_ID]);
            entidade.Titulo = reader[COLUNA_TITULO].ToString();
            entidade.Descricao = reader[COLUNA_DESCRICAO].ToString();
            entidade.Caminho = reader[COLUNA_CAMINHO].ToString();

            return entidade;
        }

        #endregion

        public ArquivoEntidadeRep(Context context)
        {
            _context = context;
        }
    }
}
