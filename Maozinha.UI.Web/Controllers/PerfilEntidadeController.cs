using Maozinha.UI.Web.ViewModel;
using System.Web.Mvc;
using Maozinha.Business;
using System.Web.Security;
using System.Configuration;
using System;

namespace Maozinha.UI.Web.Controllers
{
    public class PerfilEntidadeController : BaseController
    {

        #region Propriedades

        private readonly EntidadeBusiness _entidadeBusiness;
        private readonly ProjetoBusiness _projBusiness;
        private readonly CategoriaProjetoBusiness _categoriaBusiness;
        private readonly ArquivoEntidadeBusiness _arqBusiness;
        private readonly VoluntarioBusiness _volBusiness;

        #endregion

        #region Métodos públicos

        public ActionResult IndexEntidade()
        {
            var entidade = _entidadeBusiness.SelecionarPorLogin(User.Identity.Name);

            ContaEntidadeViewModel viewModel = new ContaEntidadeViewModel();

            viewModel.ParaViewModel(entidade);

            return View(viewModel);
        }

        public ActionResult Fotos()
        {
            return View();
        }

        public ActionResult Projetos()
        {
            IndexProjetosEntidadeViewModel viewModel = new IndexProjetosEntidadeViewModel();
            var usuarioBus = new UsuarioBusiness(ConfigurationManager.ConnectionStrings["Maozinha"].ConnectionString);
            var usuario = usuarioBus.SelecionarPorLogin(User.Identity.Name);

            if (usuario != null)
            {
                viewModel.ListaProjetos = _projBusiness.ListarPorEntidade(usuario.Id);

                foreach (var item in viewModel.ListaProjetos)
                {
                    item.Encerrado = _projBusiness.VerificarProjetoEncerrado(item.Id);
                }
            }

            return View(viewModel);
        }

        public ActionResult AdicionarProjeto()
        {
            var listaCategorias = _categoriaBusiness.ListarTodasCategorias();

            ProjetoViewModel viewModel = new ProjetoViewModel(listaCategorias);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AdicionarProjeto(ProjetoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var entidade = _entidadeBusiness.SelecionarPorLogin(User.Identity.Name);
                var model = viewModel.ParaModel();

                model.EntidadeId = entidade.Id;

                _projBusiness.InserirProjeto(model);

                return RedirectToAction("Projetos");
            }
            else
            {
                return View(viewModel);
            }
        }

        public ActionResult EditarProjeto(int id)
        {

            var entidade = _projBusiness.SelecionarProjetoPorId(id);

            if (entidade == null)
            {
                TempData["mensagem"] = "Ocorreu um erro ao carregar dados.";
                return RedirectToAction("Erro");
            }

            var listaCategorias = _categoriaBusiness.ListarTodasCategorias();

            ProjetoViewModel viewModel = new ProjetoViewModel(listaCategorias);

            viewModel.ParaViewModel(entidade);

            return View(viewModel);
        }

        public ActionResult ImagemProjeto(int id)
        {
            var entidade = _entidadeBusiness.SelecionarPorLogin(User.Identity.Name);

            ImagemProjetoViewModel viewModel = new ImagemProjetoViewModel();

            viewModel.Imagens = _arqBusiness.ListarPorEntidade(entidade.Id);
            viewModel.ProjetoId = id;

            return View(viewModel);
        }

        public ActionResult DefinirImagemProjeto(int arquivoId, int projetoId)
        {
            _projBusiness.DefinirImagemProjeto(arquivoId, projetoId);

            return RedirectToAction("Projetos");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarProjeto(ProjetoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var entidade = viewModel.ParaModel();

                _projBusiness.AlterarProjeto(entidade);

                return RedirectToAction("Projetos");
            }

            return View(viewModel);
        }

        public ActionResult ExcluirProjeto(int id)
        {
            var entidade = _projBusiness.SelecionarProjetoPorId(id);

            if (entidade == null)
            {
                TempData["mensagem"] = "Ocorreu um erro ao carregar dados.";
                return RedirectToAction("Erro");
            }

            var listaCategorias = _categoriaBusiness.ListarTodasCategorias();

            ProjetoViewModel viewModel = new ProjetoViewModel(listaCategorias);

            viewModel.ParaViewModel(entidade);

            return View(viewModel);
        }

        [HttpPost, ActionName("ExcluirProjeto")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(int id)
        {
            try
            {
                _projBusiness.ExcluirProjeto(id);
                return RedirectToAction("Projetos");
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = ex.Message;
                return RedirectToAction("Erro");
            }
        }

        public ActionResult EditarInfo()
        {
            var entidade = _entidadeBusiness.SelecionarPorLogin(User.Identity.Name);
            ContaEntidadeViewModel viewModel = new ContaEntidadeViewModel();

            viewModel.ParaViewModel(entidade);

            return View(viewModel);
        }

        public ActionResult VerMaisVoluntario(int voluntarioId, int projetoId)
        {
            VerMaisVoluntarioViewModel viewModel = new VerMaisVoluntarioViewModel();

            var voluntario = _volBusiness.SelecionarPorId(voluntarioId);

            viewModel.ParaViewModel(voluntario);
            viewModel.ProjetoId = projetoId;
            viewModel.Selecionado = _projBusiness.VerificarVoluntarioSelecionado(projetoId, voluntarioId);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult VerMaisVoluntario(VerMaisVoluntarioViewModel viewModel)
        {
            _projBusiness.SelecionarCandidatoProjeto(viewModel.ProjetoId, viewModel.Id);

            return RedirectToAction("VerVoluntarios", new { @id = viewModel.ProjetoId });
        }

        [HttpPost]
        public ActionResult EditarInfo(ContaEntidadeViewModel viewModel)
        {
            var entidade = viewModel.ParaModel();

            if (ModelState.IsValid)
            {
                _entidadeBusiness.AlterarEntidade(entidade);

                return RedirectToAction("IndexEntidade");
            }           

            return View(viewModel);
        }

        public ActionResult VerVoluntarios(int id)
        {

            var entidade = _projBusiness.SelecionarProjetoPorId(id);

            if (entidade == null)
            {
                TempData["mensagem"] = "Ocorreu um erro ao carregar dados.";
                return RedirectToAction("Erro");
            }

            VerVoluntariosViewModel viewModel = new VerVoluntariosViewModel();

            viewModel.ListaVoluntarios = _volBusiness.ListarCandidatosPorProjeto(id);
            viewModel.Projeto = entidade;
            viewModel.QtdSelecionados = _projBusiness.VerQtdSelecionados(id);

            return View(viewModel);
        }

        public ActionResult VoluntariosSelecionados(int id)
        {

            var entidade = _projBusiness.SelecionarProjetoPorId(id);

            if (entidade == null)
            {
                TempData["mensagem"] = "Ocorreu um erro ao carregar dados.";
                return RedirectToAction("Erro");
            }

            VerVoluntariosViewModel viewModel = new VerVoluntariosViewModel();

            viewModel.ListaVoluntarios = _volBusiness.ListarSelecionadosPorProjeto(id);
            viewModel.Projeto = entidade;
            viewModel.QtdSelecionados = _projBusiness.VerQtdSelecionados(id);

            return View(viewModel);
        }

        public ActionResult RemoverSelecionado(int projetoId, int voluntarioId)
        {
            _projBusiness.RemoverSelecionadoProjeto(projetoId, voluntarioId);
            return RedirectToAction("VoluntariosSelecionados", new { @id = projetoId });
        }

        public ActionResult EncerrarSelecao(int projetoId)
        {
            _projBusiness.EncerrarSelecao(projetoId);

            return RedirectToAction("Projetos");
        }
        
        public ActionResult IndexVoluntario()
        {
            return View();
        }

        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public PerfilEntidadeController()
        {
            _entidadeBusiness = new EntidadeBusiness(_connectionString);
            _projBusiness = new ProjetoBusiness(_connectionString);
            _categoriaBusiness = new CategoriaProjetoBusiness(_connectionString);
            _arqBusiness = new ArquivoEntidadeBusiness(_connectionString);
            _volBusiness = new VoluntarioBusiness(_connectionString);
        }

        #endregion

    }
}