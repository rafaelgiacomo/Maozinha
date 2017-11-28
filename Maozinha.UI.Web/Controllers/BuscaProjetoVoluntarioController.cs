using Maozinha.Business;
using Maozinha.UI.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maozinha.UI.Web.Controllers
{
    public class BuscaProjetoVoluntarioController : BaseController
    {

        #region Propriedades

        private readonly ProjetoBusiness _projBusiness;
        private readonly CategoriaProjetoBusiness _categoriaBusiness;
        private readonly VoluntarioBusiness _volBusiness;

        #endregion

        public ActionResult Index()
        {
            BuscaProjetosViewModel viewModel = new BuscaProjetosViewModel();

            viewModel.Projetos = _projBusiness.ListarDisponiveis();

            return View(viewModel);
        }

        public ActionResult DetalhesProjeto(int projetoId)
        {
            var voluntario = _volBusiness.SelecionarPorLogin(User.Identity.Name);
            var projeto = _projBusiness.SelecionarProjetoPorId(projetoId);

            if (projeto == null)
            {
                TempData["mensagem"] = "Ocorreu um erro ao carregar dados.";
                return RedirectToAction("Erro");
            }

            projeto.Categoria = _categoriaBusiness.SelecionarCategoriaPorId(projeto.CategoriaId);

            ProjetoViewModel viewModel = new ProjetoViewModel(new List<Model.CategoriaProjetoModel>());

            viewModel.NomeCategoria = projeto.Categoria.Descricao;
            viewModel.JaInscrito = _projBusiness.VerificarCandidaturaVoluntario(projeto.Id, voluntario.Id);

            viewModel.ParaViewModel(projeto);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DetalhesProjeto(ProjetoViewModel viewModel)
        {
            var voluntario = _volBusiness.SelecionarPorLogin(User.Identity.Name);

            if (viewModel.JaInscrito)
            {
                _projBusiness.ExcluirCandidatoProjeto(viewModel.Id, voluntario.Id);
            }
            else
            {
                _projBusiness.InserirCandidatoProjeto(viewModel.Id, voluntario.Id);
            }            

            return RedirectToAction("Index");
        }

        public BuscaProjetoVoluntarioController()
        {
            _projBusiness = new ProjetoBusiness(_connectionString);
            _categoriaBusiness = new CategoriaProjetoBusiness(_connectionString);
            _volBusiness = new VoluntarioBusiness(_connectionString);
        }
    }
}