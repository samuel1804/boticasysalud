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
    
    public partial class RRH_Option
    {
        public RRH_Option()
        {
            this.RRH_Puesto_Option = new HashSet<RRH_Puesto_Option>();
        }
    
        public int Optionid { get; set; }
        public string OptionDes { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public Nullable<int> OptionMainId { get; set; }
    
        public virtual ICollection<RRH_Puesto_Option> RRH_Puesto_Option { get; set; }
    }
}
