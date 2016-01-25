using System;
using System.Collections.Generic;
using Pe.ByS.ERP.Domain.Core;

namespace Pe.ByS.ERP.Domain
{
    public class ActaRecepcion : EntityAuditable<int>
    {
        //public int GuiaRemisionId { get; set; }
        public int OrdenPedidoId { get; set; }
        public int AlmacenId { get; set; }
        public DateTime FecActa { get; set; }
        public int VerificadorId { get; set; }
        public string Glosa { get; set; }

        //public virtual GuiaRemision GuiaRemision { get; set; }
        public virtual OrdenPedido OrdenPedido { get; set; }
        public virtual Almacen Almacen { get; set; }
        //public virtual Almacen Verificador { get; set; }
        public virtual ICollection<DetalleActaRecepcion> DetalleActaRecepcion { get; set; }
    }
}