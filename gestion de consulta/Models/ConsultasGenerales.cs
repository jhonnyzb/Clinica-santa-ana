using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_de_consulta.Models
{
    public class ConsultasGenerales//modelo general para vistas de tablas 
    {

        public string Fecha { get; set; }
        public string Hora { get; set; }
        public int Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }


    }


}