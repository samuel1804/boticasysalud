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
    
    public partial class IMP_DETALLE_ORDEN_COMPRA
    {
        public int Cod_detalle_orden_compra { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<int> Cod_orden_compra { get; set; }
        public Nullable<int> Cod_Producto { get; set; }
        public int Cod_usu_regi { get; set; }
        public System.DateTime Fec_usu_regi { get; set; }
        public Nullable<int> Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
    
        public virtual DIS_Producto DIS_Producto { get; set; }
        public virtual IMP_ORDEN_COMPRA IMP_ORDEN_COMPRA { get; set; }
    }
}