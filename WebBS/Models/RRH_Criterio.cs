//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RRH_Criterio
    {
        public RRH_Criterio()
        {
            this.RRH_Criterio_PruebaAutoevaluacion = new HashSet<RRH_Criterio_PruebaAutoevaluacion>();
            this.RRH_PreguntaEvaluacionTecnica = new HashSet<RRH_PreguntaEvaluacionTecnica>();
        }
    
        public int Cod_criterio { get; set; }
        public string Desc_criterio { get; set; }
        public Nullable<System.DateTime> Fec_creacion { get; set; }
        public string Cod_usu_regi { get; set; }
        public Nullable<System.DateTime> Fec_usu_regi { get; set; }
        public string Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
    
        public virtual ICollection<RRH_Criterio_PruebaAutoevaluacion> RRH_Criterio_PruebaAutoevaluacion { get; set; }
        public virtual ICollection<RRH_PreguntaEvaluacionTecnica> RRH_PreguntaEvaluacionTecnica { get; set; }
    }
}
