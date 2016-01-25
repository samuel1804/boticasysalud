namespace Pe.ByS.ERP.Application.DTO
{
    public class DetalleOrdenPedidoDto
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public string ProductoId { get; set; }
        public string ArticuloNombre { get; set; }
        public string ArticuloUnidad { get; set; }
        public int OrdenPedidoId { get; set; }
        public string NumeroPedido { get; set; }
    }
}