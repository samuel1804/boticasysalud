using Pe.ByS.ERP.Domain.Core;

namespace Pe.ByS.ERP.Domain
{
    public class DetalleOrdenPedido : EntityAuditable<int>
    {
        public int Cantidad { get; set; }
        public string ProductoId { get; set; }
        public int OrdenPedidoId { get; set; }
        public string Lote { get; set; }
        public string UnidadMedida { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual OrdenPedido OrdenPedido { get; set; }
    }
}