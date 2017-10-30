using Maozinha.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maozinha.UI.Web.ViewModel
{
    public class ProjetoViewModel
    {
        #region Propriedades

        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Descreva mais sobre o projeto")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Data Início")]
        public string DataInicio { get; set; }

        [Display(Name = "Data Fim")]
        public string DataFim { get; set; }

        [Display(Name = "UF")]
        public string Uf { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required]
        [Display(Name = "Qtd de vagas para projeto.")]
        public int QtdVagas { get; set; }

        [Required]
        [Display(Name = "Entidade")]
        public int EntidadeId { get; set; }

        [Required]
        [Display(Name = "Categoria do Projeto")]
        public int CategoriaId { get; set; }

        [Display(Name = "Foto para o projeto")]
        public int ArquivoId { get; set; }

        public SelectList CategoriaLista { get; set; }

        #endregion

        #region Metodos Publicos

        public ProjetoModel ParaModel()
        {
            ProjetoModel ent = new ProjetoModel();

            ent.Id = Id;
            ent.Nome = Nome;
            ent.Uf = Uf;
            ent.Cidade = Cidade;
            ent.Endereco = Endereco;
            ent.ArquivoId = ArquivoId;
            ent.Descricao = Descricao;
            ent.QtdVagas = QtdVagas;
            ent.DataInicio = DataInicio;
            ent.DataFim = DataFim;
            ent.CategoriaId = CategoriaId;
            ent.EntidadeId = EntidadeId;
            ent.ArquivoId = ArquivoId;

            return ent;
        }

        public void ParaViewModel(ProjetoModel ent)
        {
            Id = ent.Id;
            Nome = ent.Nome;
            Uf = ent.Uf;
            Cidade = ent.Cidade;
            Endereco = ent.Endereco;
            ArquivoId = ent.ArquivoId;
            Descricao = ent.Descricao;
            QtdVagas = ent.QtdVagas;
            DataInicio = ent.DataInicio;
            DataFim = ent.DataFim;
            CategoriaId = ent.CategoriaId;
            EntidadeId = ent.EntidadeId;
            ArquivoId = ent.ArquivoId;
        }

        #endregion

        public ProjetoViewModel(List<CategoriaProjetoModel> listaCategorias)
        {
            CategoriaLista = new SelectList(listaCategorias, "Id", "Descricao");
        }

        public ProjetoViewModel()
        {

        }

    }
}