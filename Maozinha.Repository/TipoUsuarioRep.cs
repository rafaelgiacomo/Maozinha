using Maozinha.Interface;
using Maozinha.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Maozinha.Repository
{
    public class TipoUsuarioRep : IRepositorioGenerico<TipoUsuarioModel>
    {
        private Context _context;

        #region Constantes

        private const string PROCEDURE_LISTAR_TODOS = "SP_LISTAR_TODOS_TIPOS_USUARIO";
        private const string PROCEDURE_SELECIONAR_ID = "SP_SELECIONAR_TIPO_USUARIO_ID";
        private const string PROCEDURE_SELECIONAR_DESCRICAO = "SP_SELECIONAR_TIPO_USUARIO_DESCRICAO";

        private const string COLUNA_ID = "Id";
        private const string COLUNA_DESCRICAO = "Descricao";

        #endregion

        #region Metodos Publicos

        public void Alterar(TipoUsuarioModel entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(TipoUsuarioModel entidade)
        {
            throw new NotImplementedException();
        }

        public void Inserir(TipoUsuarioModel entidade)
        {
            throw new NotImplementedException();
        }

        public TipoUsuarioModel SelecionarPorId(TipoUsuarioModel entidade)
        {
            try
            {
                TipoUsuarioModel entidadeRet = null;
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

        public TipoUsuarioModel SelecionarPorDescricao(TipoUsuarioModel entidade)
        {
            try
            {
                TipoUsuarioModel entidadeRet = null;
                SqlDataReader reader = null;

                string[] parameters = { COLUNA_DESCRICAO };
                object[] values = { entidade.Descricao };

                reader = _context.ExecuteProcedureWithReturn(PROCEDURE_SELECIONAR_DESCRICAO, parameters, values);

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

        public List<TipoUsuarioModel> ListarTodos()
        {
            try
            {
                List<TipoUsuarioModel> lista = new List<TipoUsuarioModel>();
                SqlDataReader reader;

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

        #endregion

        #region Metodos Privados

        private TipoUsuarioModel ReaderEmObjeto(SqlDataReader reader)
        {
            var entidade = new TipoUsuarioModel();

            entidade.Id = Convert.ToInt32(reader[COLUNA_ID]);
            entidade.Descricao = reader[COLUNA_DESCRICAO].ToString();

            return entidade;
        }

        #endregion

        public TipoUsuarioRep(Context context)
        {
            _context = context;
        }
    }
}
