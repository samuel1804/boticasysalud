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
    
    public partial class RYA_PRODUCTO
    {
        public RYA_PRODUCTO()
        {
            this.RYA_LOTES = new HashSet<RYA_LOTES>();
            this.RYA_MOVALM_DET = new HashSet<RYA_MOVALM_DET>();
            this.RYA_STOCK = new HashSet<RYA_STOCK>();
        }
    
        public int Cod_producto { get; set; }
        public string NombreArticulo { get; set; }
        public string UnidadMedida { get; set; }
        public string Presentacion { get; set; }
        public decimal Precio { get; set; }
        public string Estado { get; set; }
        public string Cod_usu_regi { get; set; }
        public Nullable<System.DateTime> Fec_usu_regi { get; set; }
        public string Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
    
        public virtual ICollection<RYA_LOTES> RYA_LOTES { get; set; }
        public virtual ICollection<RYA_MOVALM_DET> RYA_MOVALM_DET { get; set; }
        public virtual ICollection<RYA_STOCK> RYA_STOCK { get; set; }
    }
}