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

        private readonly EntidadeBusiness _entidadeBusiness;
        private readonly ArquivoEntidadeBusiness _arqEntBusiness;

        #endregion

        #region Métodos Públicos

        public ActionResult Index()
        {
            var entidade = _entidadeBusiness.SelecionarPorLogin(User.Identity.Name);
            IndexFotosEntidadeViewModel viewModel = new IndexFotosEntidadeViewModel();

            viewModel.ListaFotos = _arqEntBusiness.ListarPorEntidade(entidade.Id);

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
                var entidade = _entidadeBusiness.SelecionarPorLogin(User.Identity.Name);

                foreach (var file in viewModel.Files)
                {
                    if (file.ContentLength > 0)
                    {
                        ArquivoModel arq = new ArquivoModel();

                        arq.Titulo = Path.GetFileNameWithoutExtension(file.FileName);
                        arq.Tipo = Path.GetExtension(file.FileName);
                        arq.Id = _arqEntBusiness.DefinirProximoId();
                        arq.Caminho = Path.Combine(Server.MapPath(ArquivoViewModel.CaminhoUpload), arq.Id + arq.Tipo);
                        arq.Descricao = viewModel.Descricao;

                        _arqEntBusiness.InserirArquivo(arq, entidade.Id);

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
            var entidade = _entidadeBusiness.SelecionarPorLogin(User.Identity.Name);
            var arq = _arqEntBusiness.SelecionarArquivoPorId(id);

            _arqEntBusiness.ExcluirArquivo(id, entidade.Id);

            System.IO.File.Delete(arq.Caminho);

            return RedirectToAction("Index");
        }

        public FileResult Download(int id)
        {
            try
            {
                string contentType = "";
                ArquivoModel arquivo = _arqEntBusiness.SelecionarArquivoPorId(id);

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

        public FotosEntidadeController()
        {
            _arqEntBusiness = new ArquivoEntidadeBusiness(_connectionString);
            _entidadeBusiness = new EntidadeBusiness(_connectionString);
        }

        #endregion
    }
}