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
    
    public partial class DIS_Pedido_Detalle
    {
        public int Cod_detalle { get; set; }
        public Nullable<int> Cod_pedido { get; set; }
        public Nullable<int> Cod_producto { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<decimal> Peso { get; set; }
        public string Unidad_medida { get; set; }
        public string Lote { get; set; }
        public string Observacion { get; set; }
        public Nullable<int> cod_usu_regi { get; set; }
        public Nullable<int> cod_usu_modi { get; set; }
        public Nullable<System.DateTime> fec_usu_regi { get; set; }
        public Nullable<System.DateTime> fec_usu_modi { get; set; }
    
        public virtual DIS_Pedido DIS_Pedido { get; set; }
        public virtual DIS_Producto DIS_Producto { get; set; }
    }
}
