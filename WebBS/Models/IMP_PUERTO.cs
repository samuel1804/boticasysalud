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
    
    public partial class IMP_PUERTO
    {
        public IMP_PUERTO()
        {
            this.IMP_ADQUISICION = new HashSet<IMP_ADQUISICION>();
        }
    
        public int Cod_puerto { get; set; }
        public string Nombre { get; set; }
        public string Cod_distrito { get; set; }
        public string Cod_provincia { get; set; }
        public string Cod_departamento { get; set; }
        public int Cod_usu_regi { get; set; }
        public System.DateTime Fec_usu_regi { get; set; }
        public Nullable<int> Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
    
        public virtual ICollection<IMP_ADQUISICION> IMP_ADQUISICION { get; set; }
        public virtual IMP_DISTRITO IMP_DISTRITO { get; set; }
    }
}
