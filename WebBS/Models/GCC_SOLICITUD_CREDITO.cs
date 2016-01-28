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
    
    public partial class GCC_SOLICITUD_CREDITO
    {
        public GCC_SOLICITUD_CREDITO()
        {
            this.GCC_CONTRATO_CREDITO = new HashSet<GCC_CONTRATO_CREDITO>();
            this.GCC_EMPLEADO_SOL_CREDITO = new HashSet<GCC_EMPLEADO_SOL_CREDITO>();
            this.GCC_INFORME_CREDITICIO = new HashSet<GCC_INFORME_CREDITICIO>();
        }
    
        public int Cod_solicitud_credito { get; set; }
        public int Cod_cliente { get; set; }
        public System.DateTime Fec_solicitud { get; set; }
        public string Num_solicitud { get; set; }
        public string Observacion { get; set; }
        public string Situacion_cliente { get; set; }
        public int Cod_usu_regi { get; set; }
        public System.DateTime Fec_usu_regi { get; set; }
        public Nullable<int> Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
    
        public virtual GCC_CLIENTE_JURIDICO GCC_CLIENTE_JURIDICO { get; set; }
        public virtual ICollection<GCC_CONTRATO_CREDITO> GCC_CONTRATO_CREDITO { get; set; }
        public virtual ICollection<GCC_EMPLEADO_SOL_CREDITO> GCC_EMPLEADO_SOL_CREDITO { get; set; }
        public virtual ICollection<GCC_INFORME_CREDITICIO> GCC_INFORME_CREDITICIO { get; set; }
    }
}
