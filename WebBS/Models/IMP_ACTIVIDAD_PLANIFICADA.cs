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
    
    public partial class IMP_ACTIVIDAD_PLANIFICADA
    {
        public IMP_ACTIVIDAD_PLANIFICADA()
        {
            this.IMP_ACCION = new HashSet<IMP_ACCION>();
            this.IMP_ACTIVIDAD_PLANIFICADA1 = new HashSet<IMP_ACTIVIDAD_PLANIFICADA>();
            this.IMP_ALERTA_ACTIVIDAD = new HashSet<IMP_ALERTA_ACTIVIDAD>();
        }
    
        public int Cod_actividad_planificada { get; set; }
        public string Titulo { get; set; }
        public string Observacion { get; set; }
        public System.DateTime Fec_cierre_planificacion { get; set; }
        public Nullable<System.DateTime> Fec_cierre_real { get; set; }
        public string Estado { get; set; }
        public int Prioridad { get; set; }
        public string RutaArchivo { get; set; }
        public int Cod_empleado { get; set; }
        public int Cod_actividad { get; set; }
        public int Cod_solicitud_gestion_permiso { get; set; }
        public Nullable<int> Cod_actividad_planificada_predecesora { get; set; }
        public int Cod_usu_regi { get; set; }
        public System.DateTime Fec_usu_regi { get; set; }
        public Nullable<int> Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
    
        public virtual ICollection<IMP_ACCION> IMP_ACCION { get; set; }
        public virtual IMP_ACTIVIDAD IMP_ACTIVIDAD { get; set; }
        public virtual ICollection<IMP_ACTIVIDAD_PLANIFICADA> IMP_ACTIVIDAD_PLANIFICADA1 { get; set; }
        public virtual IMP_ACTIVIDAD_PLANIFICADA IMP_ACTIVIDAD_PLANIFICADA2 { get; set; }
        public virtual IMP_SOLICITUD_GESTION_PERMISO IMP_SOLICITUD_GESTION_PERMISO { get; set; }
        public virtual RRH_Empleado RRH_Empleado { get; set; }
        public virtual ICollection<IMP_ALERTA_ACTIVIDAD> IMP_ALERTA_ACTIVIDAD { get; set; }
    }
}
