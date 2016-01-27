using System;
using System.Collections.Generic;
using Pe.ByS.ERP.Domain.Core;

namespace Pe.ByS.ERP.Domain
{
    public class OrdenPedido : EntityAuditable<int>
    {
        public string NumeroPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public string Estado { get; set; }
        public int SolicitanteId { get; set; }
        public int SucursalId { get; set; }
        public string Glosa { get; set; }

        public virtual Empleado Solicitante { get; set; }
        public virtual Sucursal Sucursal { get; set; }
        public virtual ICollection<DetalleOrdenPedido> DetalleOrdenPedidoList { get; set; }
    }
}