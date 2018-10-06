using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestion_de_consulta.Models;
using gestion_de_consulta.AccesoDatos;

namespace gestion_de_consulta.Controllers
{
    public class PacienteController : Controller
    {
        // GET: Usuario
        public ActionResult Inicio()
        {
         
                return View();  
            
        }


        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Registro(usuarios usuario)
        {
            AccesoDatosPaciente accpaciente = new AccesoDatosPaciente();
            var v_respuesta = accpaciente.Agregar(usuario);
            return Json(v_respuesta, JsonRequestBehavior.AllowGet);
        }




        public ActionResult Recuperar()
        {
            return View();
        }
    }
}