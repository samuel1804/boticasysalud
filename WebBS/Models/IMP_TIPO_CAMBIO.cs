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
    
    public partial class IMP_TIPO_CAMBIO
    {
        public IMP_TIPO_CAMBIO()
        {
            this.IMP_PAGO_IMPORTACION = new HashSet<IMP_PAGO_IMPORTACION>();
        }
    
        public int Cod_tipo_cambio { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<decimal> Valor_compra { get; set; }
        public Nullable<decimal> Valor_venta { get; set; }
        public Nullable<int> Cod_tipo_moneda { get; set; }
        public int Cod_usu_regi { get; set; }
        public System.DateTime Fec_usu_regi { get; set; }
        public Nullable<int> Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
    
        public virtual ICollection<IMP_PAGO_IMPORTACION> IMP_PAGO_IMPORTACION { get; set; }
        public virtual IMP_TIPO_MONEDA IMP_TIPO_MONEDA { get; set; }
    }
}
