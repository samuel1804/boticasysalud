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
    
    public partial class IMP_EVENTO
    {
        public IMP_EVENTO()
        {
            this.IMP_BITACORA_EVENTO = new HashSet<IMP_BITACORA_EVENTO>();
        }
    
        public int Cod_evento { get; set; }
        public byte[] Evento { get; set; }
        public Nullable<int> Cod_tipo_evento { get; set; }
        public int Cod_usu_regi { get; set; }
        public System.DateTime Fec_usu_regi { get; set; }
        public Nullable<int> Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
    
        public virtual ICollection<IMP_BITACORA_EVENTO> IMP_BITACORA_EVENTO { get; set; }
        public virtual IMP_TIPO_EVENTO IMP_TIPO_EVENTO { get; set; }
    }
}
