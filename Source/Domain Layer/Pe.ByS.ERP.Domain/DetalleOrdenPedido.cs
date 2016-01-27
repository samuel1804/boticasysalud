using Pe.ByS.ERP.Domain.Core;

namespace Pe.ByS.ERP.Domain
{
    public class DetalleOrdenPedido : EntityAuditable<int>
    {
        public int ProductoId { get; set; }
        public int OrdenPedidoId { get; set; }
        public string UnidadMedida { get; set; }
        public int Cantidad { get; set; }
        public int CantidadAprobada { get; set; }
        public int CantidadAtendida { get; set; }
        public string Observacion { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual OrdenPedido OrdenPedido { get; set; }
    }
}