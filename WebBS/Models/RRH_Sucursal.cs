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
    
    public partial class RRH_Sucursal
    {
        public RRH_Sucursal()
        {
            this.ALP_ORDEN_PREPARADO = new HashSet<ALP_ORDEN_PREPARADO>();
            this.DIS_Pedido = new HashSet<DIS_Pedido>();
            this.RRH_OfertaLaboral = new HashSet<RRH_OfertaLaboral>();
        }
    
        public int Cod_sucursal { get; set; }
        public string Nom_sucursal { get; set; }
        public string Direccion { get; set; }
        public int Estado { get; set; }
        public string Cod_usu_regi { get; set; }
        public Nullable<System.DateTime> Fec_usu_regi { get; set; }
        public string Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
    
        public virtual ICollection<ALP_ORDEN_PREPARADO> ALP_ORDEN_PREPARADO { get; set; }
        public virtual ICollection<DIS_Pedido> DIS_Pedido { get; set; }
        public virtual ICollection<RRH_OfertaLaboral> RRH_OfertaLaboral { get; set; }
    }
}