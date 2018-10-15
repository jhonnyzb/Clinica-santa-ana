using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestion_de_consulta.AccesoDatos;

namespace gestion_de_consulta.Controllers
{
    public class MedicoController : Controller
    {
        // GET: Medico
        public ActionResult Inicio()
        {
            AccesoDatosMedico accdatosmedico = new AccesoDatosMedico();
            ViewBag.n_citas_medico = accdatosmedico.N_citas_Medico(((int)Session["Ced_usuario"]));
          
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


    }
}