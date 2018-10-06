using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestion_de_consulta.Models;


namespace gestion_de_consulta.AccesoDatos
{
    public class Acceso_Datos
    {
        bd_clinicaEntities bdclinica = new bd_clinicaEntities();



        public usuarios Logueo(usuarios usuario)
        {
            usuarios u = bdclinica.usuarios.SingleOrDefault(x=>x.cedula==usuario.cedula && x.clave==usuario.clave);

            return u;
        }



    }
}