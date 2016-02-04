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

    public partial class RRH_GradoAcademico
    {
        public int Cod_GradoAcademico { get; set; }
        public int Cod_candidato { get; set; }
        [Required(ErrorMessage = "Ingrese el Titulo Obtenido")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Ingrese el Centro de Estudios")]
        public string CentroEstudios { get; set; }
        [Required(ErrorMessage = "Ingrese el Año de Graduación")]
        public int Anio_graduacion { get; set; }
        public string ruta_certificado { get; set; }
        public string Cod_usu_regi { get; set; }
        public Nullable<System.DateTime> Fec_usu_regi { get; set; }
        public string Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }

        public virtual RRH_Candidato RRH_Candidato { get; set; }
    }
}