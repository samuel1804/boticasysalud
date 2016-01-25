using System;
using Pe.ByS.ERP.Domain.Core;

namespace Pe.ByS.ERP.Domain
{
    public class GuiaRemision : EntityAuditable<int>
    {
        public string Serie { get; set; }
        public DateTime FechaGuia { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Detalle { get; set; }
        public DateTime Fecha { get; set; }
    }
}