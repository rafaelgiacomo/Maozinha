using Maozinha.Business;
using Maozinha.Model;
using Maozinha.UI.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Maozinha.UI.Web.Controllers
{
    public class FotosEntidadeController : BaseController
    {
        #region Propriedades

        private readonly ArquivoEntidadeBusiness _arqEntBusiness;

        #endregion

        #region Métodos Públicos

        public ActionResult Index()
        {
            IndexFotosEntidadeViewModel viewModel = new IndexFotosEntidadeViewModel();

            return View(viewModel);
        }

        public ActionResult Adicionar()
        {
            ArquivoViewModel viewModel = new ArquivoViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Adicionar(ArquivoViewModel viewModel)
        {
            try
            {
                foreach (var file in viewModel.Files)
                {
                    if (file.ContentLength > 0)
                    {
                        ArquivoModel arq = new ArquivoModel
                        {
                            Titulo = Path.GetFileNameWithoutExtension(file.FileName),
                            Tipo = Path.GetExtension(file.FileName),
                        };

                        arq.Caminho = Path.Combine(Server.MapPath(ArquivoViewModel.CaminhoUpload), arq.Titulo + arq.Tipo);

                        file.SaveAs(arq.Caminho);
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.Mensagem = "Erro ao subir imagens";
                return View(viewModel);
            }
        }

        public FotosEntidadeController()
        {
            _arqEntBusiness = new ArquivoEntidadeBusiness(_connectionString);
        }

        public FileResult Download(int id)
        {
            try
            {
                string contentType = "";
                //var arquivo = _unitOfWork.Arquivos.Encontrar(id);
                ArquivoModel arquivo = new ArquivoModel();

                if (".pdf".Equals(arquivo.Tipo))
                    contentType = "application/pdf";
                if (".jpg".Equals(arquivo.Tipo) || ".gif".Equals(arquivo.Tipo) || ".png".Equals(arquivo.Tipo))
                    contentType = "application/image";

                return File(Path.Combine(Server.MapPath(ArquivoViewModel.CaminhoUpload), arquivo.Titulo + arquivo.Tipo), contentType,
                    arquivo.Titulo + arquivo.Tipo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion
    }
}