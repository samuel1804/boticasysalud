namespace Pe.ByS.ERP.Application.DTO
{
    public class DetalleOrdenPedidoDto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public string ProductoNombre { get; set; }
        public string UnidadMedida { get; set; }
        public int OrdenPedidoId { get; set; }
        public string NumeroPedido { get; set; }
    }
}