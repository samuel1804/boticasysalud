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
    
    public partial class IMP_BITACORA_EVENTO
    {
        public int Cod_bitacora_evento { get; set; }
        public int Cod_desaduanaje { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime Fec_evento { get; set; }
        public string Observaciones { get; set; }
        public int Cod_evento { get; set; }
        public Nullable<int> Cod_pago_importacion { get; set; }
        public int Cod_usu_regi { get; set; }
        public System.DateTime Fec_usu_regi { get; set; }
        public Nullable<int> Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
    
        public virtual IMP_DESADUANAJE IMP_DESADUANAJE { get; set; }
        public virtual IMP_EVENTO IMP_EVENTO { get; set; }
        public virtual IMP_PAGO_IMPORTACION IMP_PAGO_IMPORTACION { get; set; }
    }
}
