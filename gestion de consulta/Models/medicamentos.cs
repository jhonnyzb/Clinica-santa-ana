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
    
    public partial class medicamentos
    {
        public medicamentos()
        {
            this.medicamentos_historia = new HashSet<medicamentos_historia>();
        }
    
        public string codigo_medicamento { get; set; }
        public string descripcion { get; set; }
        public string nombre { get; set; }
        public Nullable<int> stock { get; set; }
        public Nullable<int> valor_costo_medicamento { get; set; }
        public Nullable<int> precio_publico { get; set; }
    
        public virtual ICollection<medicamentos_historia> medicamentos_historia { get; set; }
    }
}
