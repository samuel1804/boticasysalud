namespace Pe.ByS.ERP.Application.DTO
{
    public class DetalleActaRecepcionReubicarDto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public int AlmacenId { get; set; }
        public string AlmacenNombre { get; set; }
        public string Lote { get; set; }
        public int CantidadRecepcionada { get; set; }
        public string UnidadMedida { get; set; }
        public string Modulo { get; set; }
        public int Columna { get; set; }
        public int Fila { get; set; }
    }
}