using System;
using System.Configuration;
using System.Web.Mvc;

namespace Maozinha.UI.Web.Controllers
{
    public class BaseController : Controller, IDisposable
    {
        public readonly string _connectionString = ConfigurationManager.ConnectionStrings["Maozinha"].ConnectionString;

        public ActionResult Erro()
        {
            ViewBag.mensagem = TempData["mensagem"];
            return View();
        }

        void IDisposable.Dispose()
        {
        }
    }
}