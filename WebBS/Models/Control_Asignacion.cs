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
    
    public partial class Control_Asignacion
    {
        public int Id { get; set; }
        public Nullable<int> IdVehiculo { get; set; }
        public Nullable<int> IdChofer { get; set; }
        public Nullable<System.DateTime> FechaReg { get; set; }
        public string Turno { get; set; }
        public string Observacion { get; set; }
        public string Estado { get; set; }
    }
}
