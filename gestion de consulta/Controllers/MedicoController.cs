using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestion_de_consulta.AccesoDatos;
using gestion_de_consulta.Models;

namespace gestion_de_consulta.Controllers
{
    public class MedicoController : Controller
    {
    
        // GET: Medico
        public ActionResult Inicio()
        {
            AccesoDatosMedico accdatosmedico = new AccesoDatosMedico();
            ViewBag.n_citas_medico = accdatosmedico.N_citas_Medico((int)Session["Ced_usuario"]);
          
            return View();
        }


        [HttpGet]
        public ActionResult ConsultarCitas(int id)
        {

            AccesoDatosMedico accdatosmedico = new AccesoDatosMedico();
            var CitasM = accdatosmedico.Consultar(id);
            return PartialView("CitasMedico", CitasM);
        }

        [HttpGet]
        public ActionResult ConsultarHistorial()
        {

            AccesoDatosMedico accdatosmedico = new AccesoDatosMedico();
            var Historiales = accdatosmedico.ConsultarHistoriales();
            return PartialView("HistorialesClinicos", Historiales);
        }

        [HttpGet]
        public ActionResult HistorialClinico1(int id)
        {
            Session["ced_paciente"] = id;
            AccesoDatosMedico accdatosmedico = new AccesoDatosMedico();
            var Historiales = accdatosmedico.ConsultarHistorial1(id);
            return PartialView("HistorialClinico1", Historiales);
        }


        [HttpPost]
        public JsonResult CargarMedicamentos()
        {
            AccesoDatosMedico accdatosmedico = new AccesoDatosMedico();
            var query = accdatosmedico.Medicamentos();
            return Json(query, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CargarExamenes()
        {

            AccesoDatosMedico accdatosmedico = new AccesoDatosMedico();
            var query = accdatosmedico.Examenes();
            return Json(query, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GuardarHistorial(historial_clinico historial)
        {
            int CedulaPaciente = (int)Session["ced_paciente"];
            AccesoDatosMedico accdatosmedico = new AccesoDatosMedico();
            string resultado = accdatosmedico.GuardarHistorial(historial, CedulaPaciente);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public JsonResult GuardarMedicamentos(ConsultasGenerales GuardarMedicamento)
        {
            
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}