using System;
using Pe.ByS.ERP.Domain.Core;

namespace Pe.ByS.ERP.Domain
{
    public class Producto : EntityAuditable<string>
    {
        public string Nombre { get; set; }
        public string UnidadMedida { get; set; }
        public string Presentacion { get; set; }
        public decimal Precio { get; set; }
    }
}