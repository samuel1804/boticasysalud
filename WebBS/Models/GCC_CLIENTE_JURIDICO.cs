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
    
    public partial class GCC_CLIENTE_JURIDICO
    {
        public GCC_CLIENTE_JURIDICO()
        {
            this.GCC_SOLICITUD_CREDITO = new HashSet<GCC_SOLICITUD_CREDITO>();
        }
    
        public int Cod_cliente { get; set; }
        public string Razon_social { get; set; }
        public string Categoria { get; set; }
        public int Cod_usu_regi { get; set; }
        public System.DateTime Fec_usu_regi { get; set; }
        public Nullable<int> Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
    
        public virtual GCC_CLIENTE GCC_CLIENTE { get; set; }
        public virtual ICollection<GCC_SOLICITUD_CREDITO> GCC_SOLICITUD_CREDITO { get; set; }
    }
}
