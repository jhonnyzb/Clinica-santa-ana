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

            AccesoDatosPaciente accpaciente = new AccesoDatosPaciente();
            ViewBag.n_citas = accpaciente.NumeroCitas(((int)Session["Ced_usuario"]));
            return View();   
        }



        public ActionResult Registro()
        {
            return View();
        }


        public ActionResult Recuperar()
        {
            return View();
        }


        public ActionResult V_actualizarDatos(int id)
        {
            AccesoDatosPaciente accpaciente = new AccesoDatosPaciente();
            usuarios Usuario = accpaciente.Obtener_usuario(id);
            return PartialView("ActualizarDatos",Usuario);
        }



        [HttpPost]
        public JsonResult Registro(usuarios usuario)
        {
            AccesoDatosPaciente accpaciente = new AccesoDatosPaciente();
            var v_respuesta = accpaciente.Agregar(usuario);
            return Json(v_respuesta, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult ActualizarUsuario(usuarios usuario)
        {
            AccesoDatosPaciente accpaciente = new AccesoDatosPaciente();
            var v_respuesta = accpaciente.ActualizarUsuario(usuario);
            return Json(v_respuesta, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Agendarcita(horarios fecha)
        {
            
            int ced = ((int)Session["Ced_usuario"]);
            AccesoDatosPaciente accpaciente = new AccesoDatosPaciente();
            var resp = accpaciente.Agendar(fecha,ced);
            return Json(resp, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public JsonResult Agendar(horarios fecha)
        {
            AccesoDatosPaciente accpaciente = new AccesoDatosPaciente();
            var query = accpaciente.Horarios(fecha);
            return Json(query, JsonRequestBehavior.AllowGet);
        }





       
    }
}