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
    
    public partial class GCC_PLAN_CREDITO
    {
        public GCC_PLAN_CREDITO()
        {
            this.GCC_POLITICA_CREDITO = new HashSet<GCC_POLITICA_CREDITO>();
        }
    
        public int Cod_plan_credito { get; set; }
        public string Cod_plan { get; set; }
        public string Nombre_plan { get; set; }
        public decimal Rango_inicio { get; set; }
        public decimal Rango_fin { get; set; }
        public string Forma_pago { get; set; }
        public int Dias_credito { get; set; }
        public int Cod_usu_regi { get; set; }
        public System.DateTime Fec_usu_regi { get; set; }
        public Nullable<int> Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
    
        public virtual ICollection<GCC_POLITICA_CREDITO> GCC_POLITICA_CREDITO { get; set; }
    }
}
