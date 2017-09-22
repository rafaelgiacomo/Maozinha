using Maozinha.UI.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maozinha.Business;
using Maozinha.Model;
using System.Web.Security;

namespace Maozinha.UI.Web.Controllers
{
    public class PerfilController : BaseController
    {

        #region Propriedades

        private readonly EntidadeBusiness _entidadeBusiness;

        #endregion

        #region Métodos públicos

        public ActionResult IndexEntidade()
        {
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

        public PerfilController()
        {
            _entidadeBusiness = new EntidadeBusiness(_connectionString);
        }

        #endregion

    }
}