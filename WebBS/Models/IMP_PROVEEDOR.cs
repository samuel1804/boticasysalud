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
    
    public partial class IMP_PROVEEDOR
    {
        public IMP_PROVEEDOR()
        {
            this.IMP_ORDEN_COMPRA = new HashSet<IMP_ORDEN_COMPRA>();
            this.IMP_SOLICITUD_IMPORTACION = new HashSet<IMP_SOLICITUD_IMPORTACION>();
        }
    
        public int Cod_proveedor { get; set; }
        public string Ruc { get; set; }
        public string Razon_social { get; set; }
        public int Cod_usu_regi { get; set; }
        public System.DateTime Fec_usu_regi { get; set; }
        public Nullable<int> Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
    
        public virtual ICollection<IMP_ORDEN_COMPRA> IMP_ORDEN_COMPRA { get; set; }
        public virtual ICollection<IMP_SOLICITUD_IMPORTACION> IMP_SOLICITUD_IMPORTACION { get; set; }
    }
}
