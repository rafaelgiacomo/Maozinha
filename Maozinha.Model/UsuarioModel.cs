using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Maozinha.Model
{
    public class UsuarioModel
    {

        #region Constantes

        public const int DescriminadorEntidade = 1;
        public const int DescriminadorVoluntario = 2;

        #endregion

        #region Propriedades

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Uf { get; set; }

        public string Cidade { get; set; }

        public string Endereco { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public int ArquivoId { get; set; }

        public int RoleId { get; set; }

        public int Descriminador { get; set; }

        public string Descricao { get; set; }

        private readonly Hash _hash = new Hash(SHA512.Create());

        public TipoUsuarioModel TipoUsuario { get; set; }

        public ArquivoModel Arquivo { get; set; }

        #endregion

        #region Metodos para definir senha criptografada

        public void DefinirSenha(string senha)
        {
            Senha = _hash.CriptografarSenha(senha);
        }

        public bool VerificarSenha(string senhaDigitada, string senhaCadastrada)
        {
            return _hash.VerificarSenha(senhaDigitada, senhaCadastrada);
        }

        #endregion

    }
}
