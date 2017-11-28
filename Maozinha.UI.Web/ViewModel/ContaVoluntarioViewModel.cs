using Maozinha.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Maozinha.UI.Web.ViewModel
{
    public class ContaVoluntarioViewModel : UsuarioViewModel
    {
        #region Propriedades

        [Required]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Display(Name = "Descreva mais sobre você, projetos que ja atuou e que tipo de entidade/projeto está procurando")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        public string DataNascimento { get; set; }

        #endregion

        #region Metodos Publicos

        public VoluntarioModel ParaModel()
        {
            VoluntarioModel ent = new VoluntarioModel();

            ent.Nome = Nome;
            ent.Uf = Uf;
            ent.Cidade = Cidade;
            ent.Endereco = Endereco;
            ent.Email = Email;
            ent.Telefone = Telefone;
            ent.Login = Login;
            ent.DefinirSenha(Senha);
            ent.ArquivoId = ArquivoId;
            ent.Cpf = Cpf;
            ent.Descricao = Descricao;
            ent.DataNascimento = DataNascimento;
            ent.Projetos = new List<ProjetoModel>();

            return ent;
        }

        public void ParaViewModel(VoluntarioModel ent)
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
            Cpf = ent.Cpf;
            Descricao = ent.Descricao;
            DataNascimento = ent.DataNascimento;
        }

        #endregion
    }
}