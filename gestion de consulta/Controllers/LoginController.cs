using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestion_de_consulta.Models;
using gestion_de_consulta.AccesoDatos;


namespace gestion_de_consulta.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {

            return View();
        }

        
        [HttpPost]
        public JsonResult Login(usuarios usuario)
        {
            Acceso_Datos acclogin = new Acceso_Datos();
            usuarios l_usuario = acclogin.Logueo(usuario);
            string v_resultado = "no existe";
            if (l_usuario !=null)
            {
                Session["Nom_usuario"] = l_usuario.nombres + " " + l_usuario.apellidos;
                Session["Ced_usuario"] = l_usuario.cedula;
                v_resultado = l_usuario.id_rol.ToString();
               
            }

            return Json(v_resultado, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult Recuperar_(usuarios usuario)
        {
            Acceso_Datos accrecuperar = new Acceso_Datos();
            string respuesta = accrecuperar.Recuperar_contraseña(usuario.correo);

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Cerrar_sesion()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }

    }
}