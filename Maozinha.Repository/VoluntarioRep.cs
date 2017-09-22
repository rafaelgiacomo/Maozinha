using Maozinha.Interface;
using Maozinha.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Maozinha.Repository
{
    public class VoluntarioRep : IRepositorioGenerico<VoluntarioModel>
    {
        private Context _context;

        #region Constantes

        private const string PROCEDURE_LISTAR_TODOS = "LISTAR_TODOS_VOLUNTARIOS";
        private const string PROCEDURE_SELECIONAR_ID = "SELECIONAR_VOLUNTARIO_ID";
        private const string PROCEDURE_SALVAR = "SP_SALVAR_VOLUNTARIO";

        private const string COLUNA_USUARIO_ID = "UsuarioId";
        private const string COLUNA_CPF = "Cpf";

        #endregion

        #region Metodos Publicos

        public void Alterar(VoluntarioModel entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(VoluntarioModel entidade)
        {
            throw new NotImplementedException();
        }

        public void Inserir(VoluntarioModel entidade)
        {
            try
            {
                string[] parameters = 
                {
                    UsuarioRep.COLUNA_NOME, UsuarioRep.COLUNA_UF, UsuarioRep.COLUNA_CIDADE, UsuarioRep.COLUNA_ENDERECO,
                    UsuarioRep.COLUNA_EMAIL, UsuarioRep.COLUNA_TELEFONE, UsuarioRep.COLUNA_LOGIN, UsuarioRep.COLUNA_SENHA,
                    UsuarioRep.COLUNA_ROLE_ID, UsuarioRep.COLUNA_DESCRIMINADOR, COLUNA_CPF, UsuarioRep.COLUNA_DESCRICAO
                };

                object[] values = 
                {
                    entidade.Nome, entidade.Uf, entidade.Cidade, entidade.Endereco, entidade.Email, entidade.Telefone,
                    entidade.Login, entidade.Senha, entidade.RoleId, entidade.Descriminador,
                    entidade.Cpf, entidade.Descricao
                };

                _context.ExecuteProcedureNoReturn(PROCEDURE_SALVAR, parameters, values);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public VoluntarioModel SelecionarPorId(VoluntarioModel entidade)
        {
            try
            {
                VoluntarioModel entidadeRet = null;
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

        public VoluntarioModel SelecionarPorLogin(VoluntarioModel entidade)
        {
            try
            {
                VoluntarioModel entidadeRet = null;
                SqlDataReader reader = null;

                string[] parameters = { UsuarioRep.COLUNA_LOGIN };
                object[] values = { entidade.Login };

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
                throw new Exception("Classe: EntidadeRep, Metodo: ListarTodos Mensagem: " + ex.Message, ex);
            }
        }

        public List<VoluntarioModel> ListarTodos()
        {
            try
            {
                List<VoluntarioModel> lista = new List<VoluntarioModel>();
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
                throw new Exception("Classe: VoluntarioRep, Metodo: ListarTodos Mensagem: " + ex.Message, ex);
            }
        }

        #endregion

        #region Metodos Privados

        private VoluntarioModel ReaderEmObjeto(SqlDataReader reader)
        {
            var entidade = new VoluntarioModel();

            entidade.Id = Convert.ToInt32(reader[UsuarioRep.COLUNA_ID]);
            entidade.Nome = reader[UsuarioRep.COLUNA_NOME].ToString();
            entidade.Uf = reader[UsuarioRep.COLUNA_UF].ToString();
            entidade.Cidade = reader[UsuarioRep.COLUNA_CIDADE].ToString();
            entidade.Endereco = reader[UsuarioRep.COLUNA_ENDERECO].ToString();
            entidade.Email = reader[UsuarioRep.COLUNA_EMAIL].ToString();
            entidade.Telefone = reader[UsuarioRep.COLUNA_TELEFONE].ToString();
            entidade.Login = reader[UsuarioRep.COLUNA_LOGIN].ToString();
            entidade.Senha = reader[UsuarioRep.COLUNA_SENHA].ToString();
            entidade.Cpf = reader[COLUNA_CPF].ToString();
            entidade.Descricao = reader[UsuarioRep.COLUNA_DESCRICAO].ToString();

            var roleId = reader[UsuarioRep.COLUNA_NOME].ToString();
            var arquivoId = reader[UsuarioRep.COLUNA_NOME].ToString();
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

        public VoluntarioRep(Context context)
        {
            _context = context;
        }
    }
}
