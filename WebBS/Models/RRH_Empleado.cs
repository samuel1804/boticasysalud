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
    
    public partial class RRH_Empleado
    {
        public RRH_Empleado()
        {
            this.ALP_LIBRO_RECETA = new HashSet<ALP_LIBRO_RECETA>();
            this.ALP_ORDEN_PREPARADO = new HashSet<ALP_ORDEN_PREPARADO>();
            this.GCC_EMPLEADO_INF_CREDITICIO = new HashSet<GCC_EMPLEADO_INF_CREDITICIO>();
            this.GCC_EMPLEADO_SOL_CREDITO = new HashSet<GCC_EMPLEADO_SOL_CREDITO>();
            this.IMP_ACTIVIDAD_PLANIFICADA = new HashSet<IMP_ACTIVIDAD_PLANIFICADA>();
            this.RRH_Empleado1 = new HashSet<RRH_Empleado>();
            this.RRH_Usuario = new HashSet<RRH_Usuario>();
            this.RRH_PruebaEvaluacionTecnica = new HashSet<RRH_PruebaEvaluacionTecnica>();
            this.RRH_PruebaAutoevaluacion = new HashSet<RRH_PruebaAutoevaluacion>();
        }
    
        public int Cod_empleado { get; set; }
        public string Nom_empleado { get; set; }
        public string Ap_paterno { get; set; }
        public string Ap_materno { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Foto { get; set; }
        public Nullable<System.DateTime> Fec_Ingreso { get; set; }
        public string Cod_usu_regi { get; set; }
        public Nullable<System.DateTime> Fec_usu_regi { get; set; }
        public string Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
        public Nullable<bool> Evaluado { get; set; }
        public Nullable<int> Cod_Puesto { get; set; }
        public Nullable<int> Cod_Jefe { get; set; }
        public Nullable<int> Cod_Sucursal { get; set; }
    
        public virtual ICollection<ALP_LIBRO_RECETA> ALP_LIBRO_RECETA { get; set; }
        public virtual ICollection<ALP_ORDEN_PREPARADO> ALP_ORDEN_PREPARADO { get; set; }
        public virtual ICollection<GCC_EMPLEADO_INF_CREDITICIO> GCC_EMPLEADO_INF_CREDITICIO { get; set; }
        public virtual ICollection<GCC_EMPLEADO_SOL_CREDITO> GCC_EMPLEADO_SOL_CREDITO { get; set; }
        public virtual ICollection<IMP_ACTIVIDAD_PLANIFICADA> IMP_ACTIVIDAD_PLANIFICADA { get; set; }
        public virtual ICollection<RRH_Empleado> RRH_Empleado1 { get; set; }
        public virtual RRH_Empleado RRH_Empleado2 { get; set; }
        public virtual RRH_Puesto RRH_Puesto { get; set; }
        public virtual RRH_Sucursal RRH_Sucursal { get; set; }
        public virtual ICollection<RRH_Usuario> RRH_Usuario { get; set; }
        public virtual ICollection<RRH_PruebaEvaluacionTecnica> RRH_PruebaEvaluacionTecnica { get; set; }
        public virtual ICollection<RRH_PruebaAutoevaluacion> RRH_PruebaAutoevaluacion { get; set; }
    }
}
