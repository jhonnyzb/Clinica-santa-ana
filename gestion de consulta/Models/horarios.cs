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
    
    public partial class horarios
    {
        public horarios()
        {
            this.citas = new HashSet<citas>();
        }
    
        public int id { get; set; }
        public Nullable<int> cedula_medico { get; set; }
        public string fecha_horario { get; set; }
        public string horario { get; set; }
        public Nullable<int> estado_horario { get; set; }
    
        public virtual ICollection<citas> citas { get; set; }
    }
}
