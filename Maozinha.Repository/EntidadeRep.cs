using Maozinha.Interface;
using Maozinha.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Maozinha.Repository
{
    public class EntidadeRep : IRepositorioGenerico<EntidadeModel>
    {
        private Context _context;

        #region Constantes

        private const string PROCEDURE_LISTAR_TODOS = "SP_LISTAR_TODOS_ENTIDADES";
        private const string PROCEDURE_SELECIONAR_ID = "SP_SELECIONAR_ENTIDADE_ID";
        private const string PROCEDURE_SELECIONAR_LOGIN = "SP_SELECIONAR_ENTIDADE_LOGIN";
        private const string PROCEDURE_SALVAR = "SP_SALVAR_ENTIDADE";

        private const string COLUNA_USUARIO_ID = "UsuarioId";
        private const string COLUNA_CNPJ = "Cnpj";

        #endregion

        #region Metodos Publicos

        public void Alterar(EntidadeModel entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(EntidadeModel entidade)
        {
            throw new NotImplementedException();
        }

        public void Inserir(EntidadeModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    UsuarioRep.COLUNA_NOME, UsuarioRep.COLUNA_UF, UsuarioRep.COLUNA_CIDADE, UsuarioRep.COLUNA_ENDERECO,
                    UsuarioRep.COLUNA_EMAIL, UsuarioRep.COLUNA_TELEFONE, UsuarioRep.COLUNA_LOGIN, UsuarioRep.COLUNA_SENHA,
                    UsuarioRep.COLUNA_ROLE_ID, UsuarioRep.COLUNA_DESCRIMINADOR, COLUNA_CNPJ, UsuarioRep.COLUNA_DESCRICAO
                };

                object[] values =
                {
                    entidade.Nome, entidade.Uf, entidade.Cidade, entidade.Endereco, entidade.Email, entidade.Telefone,
                    entidade.Login, entidade.Senha, entidade.RoleId, entidade.Descriminador,
                    entidade.Cnpj, entidade.Descricao
                };

                _context.ExecuteProcedureNoReturn(PROCEDURE_SALVAR, parameters, values);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EntidadeModel SelecionarPorId(EntidadeModel entidade)
        {
            try
            {
                EntidadeModel entidadeRet = null;
                SqlDataReader reader = null;

                string[] parameters = { COLUNA_USUARIO_ID };
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

        public EntidadeModel SelecionarPorLogin(EntidadeModel entidade)
        {
            try
            {
                EntidadeModel entidadeRet = null;
                SqlDataReader reader = null;

                string[] parameters = { UsuarioRep.COLUNA_LOGIN };
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
                throw new Exception("Classe: EntidadeRep, Metodo: ListarTodos Mensagem: " + ex.Message, ex);
            }
        }

        public List<EntidadeModel> ListarTodos()
        {
            try
            {
                List<EntidadeModel> lista = new List<EntidadeModel>();
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

        private EntidadeModel ReaderEmObjeto(SqlDataReader reader)
        {
            var entidade = new EntidadeModel();

            entidade.Id = Convert.ToInt32(reader[UsuarioRep.COLUNA_ID]);
            entidade.Nome = reader[UsuarioRep.COLUNA_NOME].ToString();
            entidade.Uf = reader[UsuarioRep.COLUNA_UF].ToString();
            entidade.Cidade = reader[UsuarioRep.COLUNA_CIDADE].ToString();
            entidade.Endereco = reader[UsuarioRep.COLUNA_ENDERECO].ToString();
            entidade.Email = reader[UsuarioRep.COLUNA_EMAIL].ToString();
            entidade.Telefone = reader[UsuarioRep.COLUNA_TELEFONE].ToString();
            entidade.Login = reader[UsuarioRep.COLUNA_LOGIN].ToString();
            entidade.Senha = reader[UsuarioRep.COLUNA_SENHA].ToString();
            entidade.Cnpj = reader[COLUNA_CNPJ].ToString();
            entidade.Descricao = reader[UsuarioRep.COLUNA_DESCRICAO].ToString();

            var roleId = reader[UsuarioRep.COLUNA_ROLE_ID].ToString();
            var arquivoId = reader[UsuarioRep.COLUNA_ARQUIVO_ID].ToString();
            var descriminador = reader[UsuarioRep.COLUNA_DESCRIMINADOR].ToString();

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

        public EntidadeRep(Context context)
        {
            _context = context;
        }
    }
}
