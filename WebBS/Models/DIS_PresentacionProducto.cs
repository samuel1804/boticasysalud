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
    
    public partial class DIS_PresentacionProducto
    {
        public DIS_PresentacionProducto()
        {
            this.DIS_Producto = new HashSet<DIS_Producto>();
        }
    
        public int Cod_presentacion_producto { get; set; }
        public string Des_presentacion_producto { get; set; }
        public Nullable<int> cod_usu_regi { get; set; }
        public Nullable<int> cod_usu_modi { get; set; }
        public Nullable<System.DateTime> fec_usu_regi { get; set; }
        public Nullable<System.DateTime> fec_usu_modi { get; set; }
    
        public virtual ICollection<DIS_Producto> DIS_Producto { get; set; }
    }
}