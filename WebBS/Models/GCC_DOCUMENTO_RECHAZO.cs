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
    
    public partial class GCC_DOCUMENTO_RECHAZO
    {
        public int Cod_documento_rechazo { get; set; }
        public int Cod_informe_crediticio { get; set; }
        public System.DateTime Fec_doc_rechazo { get; set; }
        public string Detalle_rechazo { get; set; }
        public int Cod_usu_regi { get; set; }
        public System.DateTime Fec_usu_regi { get; set; }
        public Nullable<int> Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
    
        public virtual GCC_INFORME_CREDITICIO GCC_INFORME_CREDITICIO { get; set; }
    }
}
