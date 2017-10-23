using Maozinha.Interface;
using Maozinha.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Maozinha.Repository
{
    public class UsuarioRep : IRepositorioGenerico<UsuarioModel>
    {
        private Context _context;

        #region Constantes

        private const string PROCEDURE_LISTAR_TODOS = "SP_LISTAR_TODOS_USUARIOS";
        private const string PROCEDURE_SELECIONAR_ID = "SP_SELECIONAR_USUARIO_ID";
        private const string PROCEDURE_SELECIONAR_LOGIN = "SP_SELECIONAR_USUARIO_LOGIN";

        public const string COLUNA_ID = "Id";
        public const string COLUNA_NOME = "Nome";
        public const string COLUNA_UF = "Uf";
        public const string COLUNA_CIDADE = "Cidade";
        public const string COLUNA_ENDERECO = "Endereco";
        public const string COLUNA_EMAIL = "Email";
        public const string COLUNA_TELEFONE = "Telefone";
        public const string COLUNA_LOGIN = "Login";
        public const string COLUNA_SENHA = "Senha";
        public const string COLUNA_ROLE_ID = "RoleId";
        public const string COLUNA_ARQUIVO_ID = "ArquivoId";
        public const string COLUNA_DESCRIMINADOR = "Descriminador";
        public const string COLUNA_DESCRICAO = "Descricao";

        #endregion

        #region Metodos Publicos

        public void Alterar(UsuarioModel entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(UsuarioModel entidade)
        {
            throw new NotImplementedException();
        }

        public void Inserir(UsuarioModel entidade)
        {
            throw new NotImplementedException();
        }

        public UsuarioModel SelecionarPorId(UsuarioModel entidade)
        {
            try
            {
                UsuarioModel entidadeRet = null;
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

        public UsuarioModel SelecionarPorLogin(UsuarioModel entidade)
        {
            try
            {
                UsuarioModel entidadeRet = null;
                SqlDataReader reader = null;

                string[] parameters = { COLUNA_LOGIN };
                object[] values = { entidade.Login };

                reader = _context.ExecuteProcedureWithReturn(PROCEDURE_SELECIONAR_LOGIN, parameters, values);

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

        public List<UsuarioModel> ListarTodos()
        {
            try
            {
                List<UsuarioModel> lista = new List<UsuarioModel>();
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

        #endregion

        #region Metodos Privados

        private UsuarioModel ReaderEmObjeto(SqlDataReader reader)
        {
            var entidade = new UsuarioModel();

            entidade.Id = Convert.ToInt32(reader[COLUNA_ID]);
            entidade.Nome = reader[COLUNA_NOME].ToString();
            entidade.Uf = reader[COLUNA_UF].ToString();
            entidade.Cidade = reader[COLUNA_CIDADE].ToString();
            entidade.Endereco = reader[COLUNA_ENDERECO].ToString();
            entidade.Email = reader[COLUNA_EMAIL].ToString();
            entidade.Telefone = reader[COLUNA_TELEFONE].ToString();
            entidade.Login = reader[COLUNA_LOGIN].ToString();
            entidade.Senha = reader[COLUNA_SENHA].ToString();
            entidade.Descricao = reader[COLUNA_DESCRICAO].ToString();

            var roleId = reader[COLUNA_ROLE_ID].ToString();
            var arquivoId = reader[COLUNA_ARQUIVO_ID].ToString();
            var descriminador = reader[COLUNA_DESCRIMINADOR].ToString();

            if (!"".Equals(roleId))
            {
                entidade.RoleId = int.Parse(roleId);
            }

            if (!"".Equals(arquivoId))
            {
                entidade.ArquivoId = int.Parse(arquivoId);
            }

            if (!"".Equals(descriminador))
            {
                entidade.Descriminador = int.Parse(descriminador);
            }

            return entidade;
        }

        #endregion

        public UsuarioRep(Context context)
        {
            _context = context;
        }
    }
}
