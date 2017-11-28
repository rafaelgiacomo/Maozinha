using Maozinha.Business;
using Maozinha.UI.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Maozinha.UI.Web.Controllers
{
    public class PerfilVoluntarioController : BaseController
    {
        #region Propriedades

        private readonly VoluntarioBusiness _voluntarioBusiness;
        private readonly ProjetoBusiness _projBusiness;
        private readonly CategoriaProjetoBusiness _categoriaBusiness;

        #endregion

        // GET: PerfilVoluntario
        public ActionResult Index()
        {
            var entidade = _voluntarioBusiness.SelecionarPorLogin(User.Identity.Name);

            ContaVoluntarioViewModel viewModel = new ContaVoluntarioViewModel();

            viewModel.ParaViewModel(entidade);

            return View(viewModel);
        }

        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public PerfilVoluntarioController()
        {
            _voluntarioBusiness = new VoluntarioBusiness(_connectionString);
            _projBusiness = new ProjetoBusiness(_connectionString);
            _categoriaBusiness = new CategoriaProjetoBusiness(_connectionString);
        }
    }
}