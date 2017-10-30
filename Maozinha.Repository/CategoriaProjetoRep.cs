using Maozinha.Interface;
using Maozinha.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Maozinha.Repository
{
    public class CategoriaProjetoRep : IRepositorioGenerico<CategoriaProjetoModel>
    {
        private Context _context;

        #region Constantes

        private const string PROCEDURE_LISTAR_TODOS = "SP_LISTAR_TODAS_CATEGORIAS_PROJETO";
        private const string PROCEDURE_SELECIONAR_ID = "SP_SELECIONAR_CATEGORIA_PROJETO_ID";

        private const string COLUNA_ID = "Id";
        private const string COLUNA_DESCRICAO = "Descricao";

        #endregion

        #region Metodos Publicos

        public void Alterar(CategoriaProjetoModel entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(CategoriaProjetoModel entidade)
        {
            throw new NotImplementedException();
        }

        public void Inserir(CategoriaProjetoModel entidade)
        {
            throw new NotImplementedException();
        }

        public CategoriaProjetoModel SelecionarPorId(CategoriaProjetoModel entidade)
        {
            try
            {
                CategoriaProjetoModel entidadeRet = null;
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

        public List<CategoriaProjetoModel> ListarTodos()
        {
            try
            {
                List<CategoriaProjetoModel> lista = new List<CategoriaProjetoModel>();
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
            catch (Exception ex)
            {
                throw new Exception("Classe: TipoUsuarioRep, Metodo: ListarTodos Mensagem: " + ex.Message, ex);
            }
        }

        #endregion

        #region Metodos Privados

        private CategoriaProjetoModel ReaderEmObjeto(SqlDataReader reader)
        {
            var entidade = new CategoriaProjetoModel();

            entidade.Id = Convert.ToInt32(reader[COLUNA_ID]);
            entidade.Descricao = reader[COLUNA_DESCRICAO].ToString();

            return entidade;
        }

        #endregion

        public CategoriaProjetoRep(Context context)
        {
            _context = context;
        }
    }
}
