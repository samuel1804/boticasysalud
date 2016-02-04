using System.Collections.Generic;

namespace Pe.ByS.ERP.Application.DTO
{
    public class OrdenPedidoDto
    {
        public int Id { get; set; }
        public string NumeroPedido { get; set; }
        public string FechaPedido { get; set; }
        public string FechaEntrega { get; set; }
        public string Estado { get; set; }
        public int SolicitanteId { get; set; }
        public string SolicitanteNombre { get; set; }
        public int SucursalId { get; set; }
        public string Glosa { get; set; }

        public List<KeyValuePair<string, string>> SolicitanteList { get; set; }
        public List<KeyValuePair<string, string>> SucursalList { get; set; }
        public List<DetalleOrdenPedidoDto> DetalleList { get; set; }
    }
}