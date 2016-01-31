using System;
using System.Collections.Generic;
using System.Linq;
using Pe.ByS.ERP.Application.DTO;
using Pe.ByS.ERP.CrossCutting.Common;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Application.Converter
{
    public class OrdenPedidoConverter
    {
        public static OrdenPedidoDto DataInicial(List<Sucursal> sucursalList)
        {
            var list = sucursalList.ConvertAll(p => new KeyValuePair<string, string>(p.Id.ToString(), p.Nombre));
            list.Insert(0, new KeyValuePair<string, string>("", "-- Seleccionar --"));

            return new OrdenPedidoDto
            {
                SucursalList = list,
                SolicitanteList = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("", "-- Seleccionar --"),
                    new KeyValuePair<string, string>("1", "Verificador 1")
                },
                EstadoList = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("", "-- Seleccionar --"),
                    new KeyValuePair<string, string>("1", "Pendiente")
                },
                FechaPedido = DateTime.Now.ConvertToDdmmaaaa()
            };
        }

        public static List<KeyValuePair<string, string>> EstadoOrdenPedidoList()
        {
            return new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("", "-- Seleccionar --"),
                new KeyValuePair<string, string>("1", "Pendiente")
            };
        }

        public static List<KeyValuePair<string, string>> ProductoList(List<Producto> productolList)
        {
            var list = productolList.ConvertAll(p => new KeyValuePair<string, string>(p.Id.ToString(), p.Nombre));
            list.Insert(0, new KeyValuePair<string, string>("", "-- Seleccionar --"));

            return list;
        }

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