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
    
    public partial class ALP_HOJA_MERMA
    {
        public ALP_HOJA_MERMA()
        {
            this.ALP_HOJA_MERMA_INSUMO = new HashSet<ALP_HOJA_MERMA_INSUMO>();
        }
    
        public string num_hoja_merma { get; set; }
        public string num_constancia_preparado { get; set; }
        public int cod_usu_regi { get; set; }
        public System.DateTime fec_usu_regi { get; set; }
        public Nullable<int> cod_usu_modi { get; set; }
        public Nullable<System.DateTime> fec_usu_modi { get; set; }
        public System.DateTime fec_merma { get; set; }
        public string estado { get; set; }
        public Nullable<int> cod_empleado { get; set; }
    
        public virtual ALP_CONSTANCIA_PREPARADO ALP_CONSTANCIA_PREPARADO { get; set; }
        public virtual ICollection<ALP_HOJA_MERMA_INSUMO> ALP_HOJA_MERMA_INSUMO { get; set; }
        public virtual RRH_Empleado RRH_Empleado { get; set; }
    }
}
