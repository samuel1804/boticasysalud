namespace Pe.ByS.ERP.Application.DTO
{
    public class DetalleActaRecepcionDto
    {
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public string Lote { get; set; }
        public int CantidadRecepcionada { get; set; }
        public int Saldo { get; set; }
        public string UnidadMedida { get; set; }
        public string Observacion { get; set; }
    }
}