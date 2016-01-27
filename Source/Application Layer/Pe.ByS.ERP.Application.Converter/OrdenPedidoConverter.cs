using System.Collections.Generic;
using System.Linq;
using Pe.ByS.ERP.Application.DTO;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Application.Converter
{
    public class OrdenPedidoConverter
    {
        public static List<DetalleOrdenPedidoDto> DomainToDtoDetalleOrdenPedido(OrdenPedido pedido)
        {
            return pedido.DetalleOrdenPedidoList.Select(p => new DetalleOrdenPedidoDto
            {
                Id = p.Id,
                ProductoId = p.ProductoId,
                Cantidad = p.Cantidad,
                ProductoNombre = p.Producto.Nombre,
                UnidadMedida = p.UnidadMedida,
                OrdenPedidoId = p.OrdenPedidoId,
                NumeroPedido = p.OrdenPedido.NumeroPedido
            }).ToList();
        }
    }
}