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
    
    public partial class RRH_PreguntaEvaluacionTecnica
    {
        public RRH_PreguntaEvaluacionTecnica()
        {
            this.RRH_PruebaEvaluacionTecnica = new HashSet<RRH_PruebaEvaluacionTecnica>();
        }
    
        public int Cod_preg_eva_tec { get; set; }
        public string Titulo { get; set; }
        public string Pregunta { get; set; }
        public Nullable<System.DateTime> Fec_creacion { get; set; }
        public Nullable<int> Cod_criterio { get; set; }
        public string Cod_usu_regi { get; set; }
        public Nullable<System.DateTime> Fec_usu_regi { get; set; }
        public string Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
        public Nullable<int> Cod_alternativa_evaluaciontec { get; set; }
    
        public virtual RRH_AlternativaEvaluacionTecnica RRH_AlternativaEvaluacionTecnica { get; set; }
        public virtual RRH_Criterio RRH_Criterio { get; set; }
        public virtual ICollection<RRH_PruebaEvaluacionTecnica> RRH_PruebaEvaluacionTecnica { get; set; }
    }
}
