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
    
    public partial class RYA_PEDIDO_CAB
    {
        public RYA_PEDIDO_CAB()
        {
            this.RYA_ACTARECEP_CAB = new HashSet<RYA_ACTARECEP_CAB>();
        }
    
        public int NumPedido { get; set; }
        public System.DateTime FchPedido { get; set; }
        public int Cod_sucursal { get; set; }
        public int CodSolicitante { get; set; }
        public string Glosa { get; set; }
        public string Cod_usu_regi { get; set; }
        public Nullable<System.DateTime> Fec_usu_regi { get; set; }
        public string Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
    
        public virtual ICollection<RYA_ACTARECEP_CAB> RYA_ACTARECEP_CAB { get; set; }
        public virtual RYA_SUCURSALES RYA_SUCURSALES { get; set; }
        public virtual RYA_PEDIDO_DET RYA_PEDIDO_DET { get; set; }
    }
}
