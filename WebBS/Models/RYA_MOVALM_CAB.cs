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
    
    public partial class RYA_MOVALM_CAB
    {
        public int Cod_sucursal { get; set; }
        public int Cod_Almacen { get; set; }
        public string Cod_Tran { get; set; }
        public int TipoDoc { get; set; }
        public int NumDoc { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string TipoMov { get; set; }
        public Nullable<int> CodCliente { get; set; }
        public string DocRef { get; set; }
        public Nullable<System.DateTime> FchRef { get; set; }
        public string Glosa { get; set; }
        public string Cod_usu_regi { get; set; }
        public Nullable<System.DateTime> Fec_usu_regi { get; set; }
        public string Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
    
        public virtual RYA_ALMACENES RYA_ALMACENES { get; set; }
        public virtual RYA_SUCURSALES RYA_SUCURSALES { get; set; }
        public virtual RYA_TRANSA_ALMA RYA_TRANSA_ALMA { get; set; }
        public virtual RYA_MOVALM_DET RYA_MOVALM_DET { get; set; }
    }
}
