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
    
    public partial class RRH_PruebaAutoevaluacion
    {
        public RRH_PruebaAutoevaluacion()
        {
            this.RRH_PruebaAutoevaluacion_Respuesta = new HashSet<RRH_PruebaAutoevaluacion_Respuesta>();
        }
    
        public int Cod_prueba_autoevaluacion { get; set; }
        public Nullable<System.DateTime> Fec_evaluacion { get; set; }
        public string Cod_usu_regi { get; set; }
        public Nullable<System.DateTime> Fec_usu_regi { get; set; }
        public string Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
        public Nullable<int> Cod_empleado { get; set; }
        public Nullable<int> Cod_resp_autoevaluacion { get; set; }
    
        public virtual RRH_Empleado RRH_Empleado { get; set; }
        public virtual ICollection<RRH_PruebaAutoevaluacion_Respuesta> RRH_PruebaAutoevaluacion_Respuesta { get; set; }

        public int PuntajeTotal { get; set; }
    }
}
