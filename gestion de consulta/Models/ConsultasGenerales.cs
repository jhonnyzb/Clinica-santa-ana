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
        public string Antecedentes_Familiares { get; set; }
        public string Antecedentes_Personales { get; set; }
        public string Cirugias { get; set; }
        public string Enfermedades_Cronicas { get; set; }
        public string Motivo_Consulta { get; set; }
        public string Diagnostico { get; set; }
        public string Medicamentos { get; set; }
        public string Examenes { get; set; }
        public string Codigo_Medicamento { get; set; }
        public int Cantidad { get; set; }

    }


}