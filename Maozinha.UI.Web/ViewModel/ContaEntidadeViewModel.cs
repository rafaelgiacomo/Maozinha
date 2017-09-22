using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Maozinha.Model;

namespace Maozinha.UI.Web.ViewModel
{
    public class ContaEntidadeViewModel : UsuarioViewModel
    {
        #region Propriedades

        [Required]
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        [Display(Name = "Descreva mais sobre o que sua entidade faz, projetos que atua e que tipo de voluntário está procurando")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        #endregion

        #region Metodos Publicos

        public EntidadeModel ParaModel()
        {
            EntidadeModel ent = new EntidadeModel();

            ent.Nome = Nome;
            ent.Uf = Uf;
            ent.Cidade = Cidade;
            ent.Endereco = Endereco;
            ent.Email = Email;
            ent.Telefone = Telefone;
            ent.Login = Login;
            ent.DefinirSenha(Senha);
            ent.ArquivoId = ArquivoId;
            ent.Cnpj = Cnpj;
            ent.Descricao = Descricao;
            ent.Projetos = new List<ProjetoModel>();

            return ent;
        }

        public void ParaViewModel(EntidadeModel ent)
        {
            Id = ent.Id;
            Nome = ent.Nome;
            Uf = ent.Uf;
            Cidade = ent.Cidade;
            Endereco = ent.Endereco;
            Email = ent.Email;
            Telefone = ent.Telefone;
            Login = ent.Login;
            Senha = ent.Senha;
            ArquivoId = ent.ArquivoId;
            Cnpj = ent.Cnpj;
            Descricao = ent.Descricao;
        }

        #endregion
    }
}