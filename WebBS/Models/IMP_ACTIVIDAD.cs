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
    
    public partial class IMP_ACTIVIDAD
    {
        public IMP_ACTIVIDAD()
        {
            this.IMP_ACTIVIDAD_PLANIFICADA = new HashSet<IMP_ACTIVIDAD_PLANIFICADA>();
        }
    
        public int Cod_actividad { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> Cod_tipo_actividad { get; set; }
        public int Cod_usu_regi { get; set; }
        public System.DateTime Fec_usu_regi { get; set; }
        public Nullable<int> Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
    
        public virtual IMP_TIPO_ACTIVIDAD IMP_TIPO_ACTIVIDAD { get; set; }
        public virtual ICollection<IMP_ACTIVIDAD_PLANIFICADA> IMP_ACTIVIDAD_PLANIFICADA { get; set; }
    }
}
