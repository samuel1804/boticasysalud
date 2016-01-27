using System;
using System.Collections.Generic;
using Pe.ByS.ERP.Domain.Core;

namespace Pe.ByS.ERP.Domain
{
    public class ActaRecepcion : EntityAuditable<int>
    {
        public int AlmacenId { get; set; }
        public DateTime FechaActa { get; set; }
        public int OrdenPedidoId { get; set; }
        public string NumGuia { get; set; }
        public DateTime FechaGuia { get; set; }
        public int VerificadorId { get; set; }
        public string Glosa { get; set; }

        public virtual OrdenPedido OrdenPedido { get; set; }
        public virtual Almacen Almacen { get; set; }
        public virtual Empleado Verificador { get; set; }
        public virtual ICollection<DetalleActaRecepcion> DetalleActaRecepcion { get; set; }
    }
}