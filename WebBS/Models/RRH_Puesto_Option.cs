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
    
    public partial class RRH_Puesto_Option
    {
        public Nullable<int> Cod_Puesto_Option { get; set; }
        public int Cod_Puesto { get; set; }
        public int OptionId { get; set; }
    
        public virtual RRH_Option RRH_Option { get; set; }
        public virtual RRH_Puesto RRH_Puesto { get; set; }
    }
}