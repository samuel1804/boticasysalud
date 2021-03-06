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
    
    public partial class IMP_SOLICITUD_IMPORTACION
    {
        public IMP_SOLICITUD_IMPORTACION()
        {
            this.IMP_ADQUISICION = new HashSet<IMP_ADQUISICION>();
            this.IMP_DESADUANAJE = new HashSet<IMP_DESADUANAJE>();
            this.IMP_PAGO_IMPORTACION = new HashSet<IMP_PAGO_IMPORTACION>();
        }
    
        public int Cod_solicitudimportacion { get; set; }
        public Nullable<int> Cod_solicitud { get; set; }
        public Nullable<System.DateTime> Fec_inicio { get; set; }
        public Nullable<System.DateTime> Fec_cierre { get; set; }
        public Nullable<int> Cod_proveedor { get; set; }
        public Nullable<int> Cod_orden_compra { get; set; }
        public Nullable<int> Cod_puerto { get; set; }
        public int Cod_usu_regi { get; set; }
        public System.DateTime Fec_usu_regi { get; set; }
        public Nullable<int> Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
    
        public virtual ICollection<IMP_ADQUISICION> IMP_ADQUISICION { get; set; }
        public virtual ICollection<IMP_DESADUANAJE> IMP_DESADUANAJE { get; set; }
        public virtual IMP_ORDEN_COMPRA IMP_ORDEN_COMPRA { get; set; }
        public virtual ICollection<IMP_PAGO_IMPORTACION> IMP_PAGO_IMPORTACION { get; set; }
        public virtual IMP_PROVEEDOR IMP_PROVEEDOR { get; set; }
        public virtual IMP_PUERTO IMP_PUERTO { get; set; }
        public virtual IMP_SOLICITUD IMP_SOLICITUD { get; set; }
    }
}
