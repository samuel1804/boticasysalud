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
    using System.ComponentModel.DataAnnotations;
    
    public partial class Perfil
    {
        public Perfil()
        {
            this.OfertaLaboral = new HashSet<OfertaLaboral>();
        }
        [Required(ErrorMessage = "Seleccione un Area")]
        public int IdArea { get; set; }
        public int IdPerfil { get; set; }
        [Required(ErrorMessage = "Seleccione un Puesto")]
        public int IdPuesto { get; set; }
        [Required (ErrorMessage="Ingrese el Nombre del Perfil")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese una Descripcion del Perfil")]
        public string Descripcion { get; set; }
        public string Competencias { get; set; }
        public string Caracteristicas { get; set; }

        public Nullable<decimal> SueldoIni { get; set; }
        public Nullable<decimal> SueldoFin { get; set; }
        public int Estado { get; set; }


        public virtual Puesto Puesto { get; set; }
        public virtual ICollection<OfertaLaboral> OfertaLaboral { get; set; }
    }
}