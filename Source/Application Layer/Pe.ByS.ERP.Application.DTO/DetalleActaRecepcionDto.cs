namespace Pe.ByS.ERP.Application.DTO
{
    public class DetalleActaRecepcionDto
    {
        public string ProductoId { get; set; }
        public string Lote { get; set; }
        public int CantidadRecepcionada { get; set; }
        public int Saldo { get; set; }
        public string Observacion { get; set; }
    }
}