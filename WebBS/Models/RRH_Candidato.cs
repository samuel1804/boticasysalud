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
    
    public partial class RRH_Candidato
    {
        public RRH_Candidato()
        {
            this.RRH_OfertaLaboral_Candidato = new HashSet<RRH_OfertaLaboral_Candidato>();
        }
    
        public int Cod_candidato { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Foto { get; set; }
        public Nullable<System.DateTime> Fec_postulacion { get; set; }
        public Nullable<int> Cod_cv_cand { get; set; }
        public string Cod_usu_regi { get; set; }
        public Nullable<System.DateTime> Fec_usu_regi { get; set; }
        public string Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
    
        public virtual ICollection<RRH_OfertaLaboral_Candidato> RRH_OfertaLaboral_Candidato { get; set; }
        public virtual RRH_CurriculumVitae RRH_CurriculumVitae { get; set; }
    }
}
