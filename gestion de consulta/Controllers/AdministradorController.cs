using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gestion_de_consulta.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        public ActionResult Inicio()
        {
            return View();
        }
    }
}