using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Por favor inicie sesión para acceder a la aplicación.";
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(reclutador model)
        {
            if (model.validar(model.usuario, model.password))
            {
                FormsAuthentication.SetAuthCookie(model.usuario, model.rememberMe);
                return View("_Layout");
                //return RedirectToAction("Index", "Home");
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "El usuario y/o contraseña son incorrectos.");
            return View("_Layout");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
