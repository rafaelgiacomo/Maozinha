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
    public class FotosVoluntarioController : BaseController
    {
        #region Propriedades

        private readonly VoluntarioBusiness _voluntarioBusiness;
        private readonly ArquivoVoluntarioBusiness _arqVolBusiness;

        #endregion

        #region Métodos Públicos

        public ActionResult Index()
        {
            var entidade = _voluntarioBusiness.SelecionarPorLogin(User.Identity.Name);
            IndexFotosEntidadeViewModel viewModel = new IndexFotosEntidadeViewModel();

            viewModel.ListaFotos = _arqVolBusiness.ListarPorEntidade(entidade.Id);

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
                var entidade = _voluntarioBusiness.SelecionarPorLogin(User.Identity.Name);

                foreach (var file in viewModel.Files)
                {
                    if (file.ContentLength > 0)
                    {
                        ArquivoModel arq = new ArquivoModel();

                        arq.Titulo = Path.GetFileNameWithoutExtension(file.FileName);
                        arq.Tipo = Path.GetExtension(file.FileName);
                        arq.Id = _arqVolBusiness.DefinirProximoId();
                        arq.Caminho = Path.Combine(Server.MapPath(ArquivoViewModel.CaminhoUpload), arq.Id + arq.Tipo);
                        arq.Descricao = viewModel.Descricao;

                        _arqVolBusiness.InserirArquivo(arq, entidade.Id);

                        file.SaveAs(arq.Caminho);
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = "Erro ao subir imagens";
                return View(viewModel);
            }
        }

        public ActionResult Excluir(int id)
        {
            var entidade = _voluntarioBusiness.SelecionarPorLogin(User.Identity.Name);
            var arq = _arqVolBusiness.SelecionarArquivoPorId(id);

            _arqVolBusiness.ExcluirArquivo(id, entidade.Id);

            System.IO.File.Delete(arq.Caminho);

            return RedirectToAction("Index");
        }

        public FileResult Download(int id)
        {
            try
            {
                string contentType = "";
                ArquivoModel arquivo = _arqVolBusiness.SelecionarArquivoPorId(id);

                if (".pdf".Equals(arquivo.Tipo))
                    contentType = "application/pdf";
                if (".jpg".Equals(arquivo.Tipo) || ".gif".Equals(arquivo.Tipo) || ".png".Equals(arquivo.Tipo))
                    contentType = "application/image";

                return File(Path.Combine(Server.MapPath(ArquivoViewModel.CaminhoUpload), arquivo.Id + arquivo.Tipo), contentType,
                    arquivo.Titulo + arquivo.Tipo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public FotosVoluntarioController()
        {
            _arqVolBusiness = new ArquivoVoluntarioBusiness(_connectionString);
            _voluntarioBusiness = new VoluntarioBusiness(_connectionString);
        }

        #endregion
    }
}