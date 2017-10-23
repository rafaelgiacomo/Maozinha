using Maozinha.UI.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maozinha.Business;
using Maozinha.Model;

namespace Maozinha.UI.Web.Controllers
{
    public class ContaEntidadeController : BaseController
    {

        #region Propriedades

        private readonly EntidadeBusiness _entidadeBusiness;

        #endregion

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Salvar(ContaEntidadeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = viewModel.ParaModel();

                _entidadeBusiness.InserirEntidade(model);

            }

            return View();
        }

        public ContaEntidadeController()
        {
            _entidadeBusiness = new EntidadeBusiness(_connectionString);
        }
    }
}