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
    
    public partial class RYA_ACTARECEP_DET
    {
        public int NumActa { get; set; }
        public int item { get; set; }
        public int COD_PRODUCTO { get; set; }
        public string Lote { get; set; }
        public string UnidadMedida { get; set; }
        public int Cant { get; set; }
        public string Verificacion { get; set; }
        public Nullable<int> Diferencia { get; set; }
        public string Observacion { get; set; }
    
        public virtual RYA_ACTARECEP_CAB RYA_ACTARECEP_CAB { get; set; }
    }
}