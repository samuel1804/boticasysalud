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
    
    public partial class IMP_ADQUISICION
    {
        public IMP_ADQUISICION()
        {
            this.IMP_BL = new HashSet<IMP_BL>();
            this.IMP_FACTURA_COMERCIAL = new HashSet<IMP_FACTURA_COMERCIAL>();
        }
    
        public int Cod_adquisicion { get; set; }
        public Nullable<System.DateTime> Fec_programada_llegada { get; set; }
        public Nullable<System.DateTime> Fec_real_llegada { get; set; }
        public Nullable<int> Cod_solicitud_importacion { get; set; }
        public int Cod_usu_regi { get; set; }
        public System.DateTime Fec_usu_regi { get; set; }
        public Nullable<int> Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
    
        public virtual IMP_SOLICITUD_IMPORTACION IMP_SOLICITUD_IMPORTACION { get; set; }
        public virtual ICollection<IMP_BL> IMP_BL { get; set; }
        public virtual ICollection<IMP_FACTURA_COMERCIAL> IMP_FACTURA_COMERCIAL { get; set; }
    }
}