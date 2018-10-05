using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestion_de_consulta.Models;

namespace gestion_de_consulta.AccesoDatos
{
    public class AccesoDatosPaciente
    {
        bd_clinicaEntities bdclinica = new bd_clinicaEntities();

        public string Agregar(usuarios usuario)
        {
            var v_cedula = bdclinica.usuarios.Any(c => c.cedula == usuario.cedula);
            if (v_cedula)
            {
                return "ya existe";
            }
            else {
                bdclinica.usuarios.Add(usuario);
                bdclinica.SaveChanges();
                return "Save"; }
        }



    }
}