using Maozinha.Business;
using Maozinha.UI.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maozinha.UI.Web.Controllers
{
    public class ContaVoluntarioController : BaseController
    {
        #region Propriedades

        private readonly VoluntarioBusiness _voluntarioBusiness;

        #endregion

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Salvar(ContaVoluntarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = viewModel.ParaModel();

                _voluntarioBusiness.InserirVoluntario(model);

            }

            return View();
        }

        public ContaVoluntarioController()
        {
            _voluntarioBusiness = new VoluntarioBusiness(_connectionString);
        }
    }
}