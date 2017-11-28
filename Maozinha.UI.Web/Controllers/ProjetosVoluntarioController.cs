using Maozinha.Business;
using Maozinha.UI.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maozinha.UI.Web.Controllers
{
    public class ProjetosVoluntarioController : BaseController
    {
        #region Propriedades

        private ProjetoBusiness _projBusiness;
        private VoluntarioBusiness _volBusiness;

        #endregion

        public ActionResult Index(string visao)
        {
            var voluntario = _volBusiness.SelecionarPorLogin(User.Identity.Name);

            IndexProjetosVoluntarioViewModel viewModel = new IndexProjetosVoluntarioViewModel();

            if (visao != null)
            {
                viewModel.Visao = int.Parse(visao);
            }

            if (viewModel.Visao == 1)
            {
                viewModel.ListaProjetos = _projBusiness.ListarPorVoluntarioAtuais(voluntario.Id);
            }

            if (viewModel.Visao == 2)
            {
                viewModel.ListaProjetos = _projBusiness.ListarPorVoluntarioPendentes(voluntario.Id);
            }

            if (viewModel.Visao == 3)
            {
                viewModel.ListaProjetos = _projBusiness.ListarPorVoluntarioConcluidos(voluntario.Id);
            }

            return View(viewModel);
        }

        public ProjetosVoluntarioController()
        {
            _projBusiness = new ProjetoBusiness(_connectionString);
            _volBusiness = new VoluntarioBusiness(_connectionString);
        }

    }
}