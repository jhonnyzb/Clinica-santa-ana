using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Linq;
using System.Web;
using gestion_de_consulta.Models;


namespace gestion_de_consulta.AccesoDatos
{
    public class Acceso_Datos
    {
        bd_clinicaEntities_ bdclinica = new bd_clinicaEntities_();



        public usuarios Logueo(usuarios usuario)
        {
            usuarios u = bdclinica.usuarios.SingleOrDefault(x=>x.cedula==usuario.cedula && x.clave==usuario.clave);

            return u;
        }

        public string Recuperar_contraseña(string para)
        {
            string mensaje = "Correo no existe";
            usuarios usu = bdclinica.usuarios.SingleOrDefault(x => x.correo == para);
            if (usu != null)
            {
                MailMessage correo = new MailMessage
                {
                    From = new MailAddress("jhonnyzb1@hotmail.com")
                };
                correo.To.Add(para);
                correo.Subject = "Recuperacion contraseña Clinica Santa ana";
                correo.Body = "Señor paciente: " + usu.nombres + " " + usu.apellidos + " su contraseña es: " + usu.clave;
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.live.com";
                smtp.Port = 25;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                string cuenta = "jhonnyzb1@hotmail.com";
                string clave = "jhonnyjjzb2";
                smtp.Credentials = new System.Net.NetworkCredential(cuenta, clave);

                smtp.Send(correo);
                mensaje = "Su contraseña fue enviado al correo registrado";
            }
            return mensaje;

        }


    }
}