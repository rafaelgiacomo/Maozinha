using Maozinha.Business;
using Maozinha.Model;
using Maozinha.UI.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Maozinha.UI.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly UsuarioBusiness _usuarioBus;

        public ActionResult Index()
        {
            if (!"".Equals(User.Identity.Name))
            {
                var usuarioBus = new UsuarioBusiness(ConfigurationManager.ConnectionStrings["Maozinha"].ConnectionString);
                var usuario = usuarioBus.SelecionarPorLogin(User.Identity.Name);

                if (usuario != null)
                {
                    if (usuario.Descriminador == UsuarioModel.DescriminadorEntidade)
                    {
                        return RedirectToAction("IndexEntidade", "PerfilEntidade");
                    }

                    if (usuario.Descriminador == UsuarioModel.DescriminadorVoluntario)
                    {
                        return RedirectToAction("IndexVoluntario", "PerfilVoluntario");
                    }
                }
            }

            LoginViewModel viewModel = new LoginViewModel();

            if (TempData["tipo"] != null)
            {
                string tipoMsg = TempData["tipo"].ToString();
                string msg = TempData["mensagem"].ToString();

                if ("voluntario".Equals(tipoMsg))
                {
                    viewModel.MsgErroVoluntario = msg;
                }

                if ("entidade".Equals(tipoMsg))
                {
                    viewModel.MsgErroEntidade = msg;
                }

            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult LoginVoluntario(FormCollection form, string returnUrl)
        {
            string login = form["LoginVoluntario"];
            string senha = form["SenhaVoluntario"];

            try
            {
                UsuarioModel usuario = _usuarioBus.SelecionarPorLogin(login);

                if (usuario != null)
                {
                    if (usuario.Descriminador == UsuarioModel.DescriminadorVoluntario)
                    {
                        if (usuario.VerificarSenha(senha, usuario.Senha))
                        {
                            FormsAuthentication.SetAuthCookie(usuario.Login, false);

                            if (Url.IsLocalUrl(returnUrl)
                                && returnUrl.Length > 1
                                && returnUrl.StartsWith("/")
                                && !returnUrl.StartsWith("//")
                                && !returnUrl.StartsWith("/\\"))
                            {
                                return Redirect(returnUrl);
                            }

                            return RedirectToAction("IndexVoluntario", "PerfilVoluntario");
                        }
                        else
                        {
                            TempData["mensagem"] = "Login ou Senha inválidos";
                            TempData["tipo"] = "voluntario";
                        }                       
                    }
                    else
                    {
                        TempData["mensagem"] = "Usuario não tem perfil de voluntário. Faça o login como uma entidade!";
                        TempData["tipo"] = "voluntario";
                    }
                }
                else
                {
                    TempData["mensagem"] = "Login ou Senha inválidos";
                    TempData["tipo"] = "voluntario";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = ex.Message;
                return RedirectToAction("Erro");
            }
        }

        [HttpPost]
        public ActionResult LoginEntidade(FormCollection form, string returnUrl)
        {
            string login = form["LoginEntidade"];
            string senha = form["SenhaEntidade"];

            try
            {
                UsuarioModel usuario = _usuarioBus.SelecionarPorLogin(login);

                if (usuario != null)
                {
                    if (usuario.Descriminador == UsuarioModel.DescriminadorEntidade)
                    {
                        if (usuario.VerificarSenha(senha, usuario.Senha))
                        {
                            FormsAuthentication.SetAuthCookie(usuario.Login, false);

                            if (Url.IsLocalUrl(returnUrl)
                                && returnUrl.Length > 1
                                && returnUrl.StartsWith("/")
                                && !returnUrl.StartsWith("//")
                                && !returnUrl.StartsWith("/\\"))
                            {
                                return Redirect(returnUrl);
                            }

                            return RedirectToAction("IndexEntidade", "PerfilEntidade");
                        }
                        else
                        {
                            TempData["mensagem"] = "Login ou Senha inválidos";
                            TempData["tipo"] = "entidade";
                        }
                    }
                    else
                    {
                        TempData["mensagem"] = "Usuario não tem perfil de entidade. Faça o login como um voluntário!";
                        TempData["tipo"] = "entidade";
                    }
                }
                else
                {
                    TempData["mensagem"] = "Login ou Senha inválidos";
                    TempData["tipo"] = "entidade";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = ex.Message;
                return RedirectToAction("Erro");
            }
        }

        public HomeController()
        {
            _usuarioBus = new UsuarioBusiness(_connectionString);
        }

    }
}