//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gestion_de_consulta.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class medicamentos_historia
    {
        public int id { get; set; }
        public string codigo_medicamento { get; set; }
        public Nullable<int> cedula_paciente { get; set; }
        public string fecha_medicamento { get; set; }
    }
}
