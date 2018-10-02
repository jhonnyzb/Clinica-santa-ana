using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gestion_de_consulta.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Paciente()
        {
            return View();
        }
    }
}