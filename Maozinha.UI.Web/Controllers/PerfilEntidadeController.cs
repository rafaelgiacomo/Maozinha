using Maozinha.UI.Web.ViewModel;
using System.Web.Mvc;
using Maozinha.Business;
using Maozinha.Model;
using System.Web.Security;
using System.Configuration;

namespace Maozinha.UI.Web.Controllers
{
    public class PerfilEntidadeController : BaseController
    {

        #region Propriedades

        private readonly EntidadeBusiness _entidadeBusiness;
        private readonly ProjetoBusiness _projBusiness;

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
            }

            return View(viewModel);
        }

        public ActionResult AdicionarProjeto()
        {
            ProjetoViewModel viewModel = new ProjetoViewModel();

            return View();
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
        }

        #endregion

    }
}