using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gestion_de_consulta.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Registrarse()
        {
            return View();
        }

        public ActionResult Recuperarcontraseña()
        {
            return View();
        }
    }
}