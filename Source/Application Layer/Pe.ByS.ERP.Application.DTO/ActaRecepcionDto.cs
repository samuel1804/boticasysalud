using System.Collections.Generic;

namespace Pe.ByS.ERP.Application.DTO
{
    public class ActaRecepcionDto
    {
        public int Id { get; set; }
        public int SucursalId { get; set; }
        public string SucursalNombre { get; set; }
        public int AlmacenId { get; set; }
        public string AlmacenNombre { get; set; }
        public int VerificadorId { get; set; }
        public string VerificadorNombre { get; set; }
        public string Fecha { get; set; }
        public string FechaGuia { get; set; }
        public int OrdenPedidoId { get; set; }
        public string NumeroPedido { get; set; }
        public int GuiaRemisionId { get; set; }
        public string NumeroGuia { get; set; }
        public string Glosa { get; set; }

        public List<KeyValuePair<string, string>> SucursalList { get; set; }
        public List<KeyValuePair<string, string>> VerificadorList { get; set; }
        public List<DetalleActaRecepcionDto> DetalleList { get; set; }
    }
}