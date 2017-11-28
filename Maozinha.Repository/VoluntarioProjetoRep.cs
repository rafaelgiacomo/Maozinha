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
    public class VoluntarioProjetoRep
    {
        private Context _context;

        #region Constantes
        
        private const string PROCEDURE_SALVAR = "SP_SALVAR_VOLUNTARIO_PROJETO";
        private const string PROCEDURE_SELECIONAR_VOLUNTARIO_PROJETO = "SP_SELECIONAR_VOLUNTARIO_PROJETO";
        private const string PROCEDURE_REMOVER_VOLUNTARIO_PROJETO = "SP_REMOVER_VOLUNTARIO_PROJETO";
        private const string PROCEDURE_EXCLUIR = "SP_EXCLUIR_VOLUNTARIO_PROJETO";
        private const string PROCEDURE_VERIFICAR = "SP_VERIFICAR_VOLUNTARIO_PROJETO";
        private const string PROCEDURE_VERIFICAR_SELECIONADO = "SP_VERIFICAR_VOLUNTARIO_SELECIONADO";
        private const string PROCEDURE_VER_QTD_SELECIONADOS_PROJETO = "SP_VER_QTD_VOLUNTARIOS_SELECIONADOS";

        public const string COLUNA_VOLUNTARIO_ID = "VoluntarioId";
        public const string COLUNA_PROJETO_ID = "ProjetoId";

        #endregion

        #region Métodos Públicos

        public void Inserir(int voluntarioId, int projetoId)
        {
            try
            {
                string[] parameters =
                {
                    COLUNA_VOLUNTARIO_ID, COLUNA_PROJETO_ID
                };

                object[] values =
                {
                    voluntarioId, projetoId
                };

                _context.ExecuteProcedureNoReturn(PROCEDURE_SALVAR, parameters, values);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(int volunarioId, int projetoId)
        {
            try
            {
                string[] parameters =
                {
                    COLUNA_VOLUNTARIO_ID, COLUNA_PROJETO_ID
                };

                object[] values =
                {
                    volunarioId, projetoId
                };

                _context.ExecuteProcedureNoReturn(PROCEDURE_EXCLUIR, parameters, values);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int QtdVoluntariosSelecionados(int projetoId)
        {
            try
            {
                int qtd = 0;
                SqlDataReader reader = null;

                string[] parameters = { COLUNA_PROJETO_ID };
                object[] values = { projetoId };

                reader = _context.ExecuteProcedureWithReturn(PROCEDURE_VER_QTD_SELECIONADOS_PROJETO, parameters, values);

                if (reader.Read())
                {
                    qtd = int.Parse(reader[0].ToString());
                }

                reader.Close();

                return qtd;
            }
            catch (Exception ex)
            {
                throw new Exception("Classe: TipoUsuarioRep, Metodo: ListarTodos Mensagem: " + ex.Message, ex);
            }
        }

        public bool VerificarVoluntarioSelecionado(int projetoId, int voluntarioId)
        {
            try
            {
                int qtd = 0;
                SqlDataReader reader = null;

                string[] parameters = { COLUNA_PROJETO_ID, COLUNA_VOLUNTARIO_ID };
                object[] values = { projetoId, voluntarioId };

                reader = _context.ExecuteProcedureWithReturn(PROCEDURE_VERIFICAR_SELECIONADO, parameters, values);

                if (reader.Read())
                {
                    qtd = int.Parse(reader[0].ToString());
                }

                reader.Close();

                return (qtd > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Classe: TipoUsuarioRep, Metodo: ListarTodos Mensagem: " + ex.Message, ex);
            }
        }

        public void SelecionarCandidatoProjeto(int voluntarioId, int projetoId)
        {
            try
            {
                string[] parameters =
                {
                    COLUNA_VOLUNTARIO_ID, COLUNA_PROJETO_ID
                };

                object[] values =
                {
                    voluntarioId, projetoId
                };

                _context.ExecuteProcedureNoReturn(PROCEDURE_SELECIONAR_VOLUNTARIO_PROJETO, parameters, values);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoverSelecionadoProjeto(int voluntarioId, int projetoId)
        {
            try
            {
                string[] parameters =
                {
                    COLUNA_VOLUNTARIO_ID, COLUNA_PROJETO_ID
                };

                object[] values =
                {
                    voluntarioId, projetoId
                };

                _context.ExecuteProcedureNoReturn(PROCEDURE_REMOVER_VOLUNTARIO_PROJETO, parameters, values);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool VerificarCandidatoIncluso(int voluntarioId, int projetoId)
        {
            try
            {
                string[] parameters =
                {
                    COLUNA_VOLUNTARIO_ID, COLUNA_PROJETO_ID
                };

                object[] values =
                {
                    voluntarioId, projetoId
                };

                var reader = _context.ExecuteProcedureWithReturn(PROCEDURE_VERIFICAR, parameters, values);

                if (reader.Read())
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Metodos Privados

        #endregion

        public VoluntarioProjetoRep(Context context)
        {
            _context = context;
        }
    }
}
