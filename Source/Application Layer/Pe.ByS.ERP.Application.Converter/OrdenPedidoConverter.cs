using System;
using System.Collections.Generic;
using System.Linq;
using Pe.ByS.ERP.Application.DTO;
using Pe.ByS.ERP.CrossCutting.Common;
using Pe.ByS.ERP.CrossCutting.Common.Enums;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Application.Converter
{
    public class OrdenPedidoConverter
    {
        public static OrdenPedidoDto DataInicial(List<Sucursal> sucursalList, List<Empleado> empleadoList)
        {
            return new OrdenPedidoDto
            {
                SucursalList = SucursalConverter.ListToKeyValueList(sucursalList),
                SolicitanteList = EmpleadoConverter.ListToKeyValueList(empleadoList),
                Estado = EstadoOrdenPedidoList().First(p => p.Key == ((int) EstadoPedido.Pendiente).ToString()).Value,
                FechaPedido = DateTime.Now.ConvertToDdmmaaaa()
            };
        }

        public static OrdenPedido DtoToDomain(OrdenPedidoDto pedido)
        {
            if (!string.IsNullOrEmpty(pedido.NumeroPedido))
            {
                var num = pedido.NumeroPedido.Substring(2);
                pedido.NumeroPedido = string.Format("OP{0:000000}", Convert.ToInt32(num) + 1);
            }

            return new OrdenPedido
            {
                NumeroPedido = pedido.NumeroPedido,
                FechaEntrega = Convert.ToDateTime(pedido.FechaEntrega),
                FechaPedido = Convert.ToDateTime(pedido.FechaPedido),
                SucursalId = pedido.SucursalId,
                SolicitanteId = pedido.SolicitanteId,
                Glosa = pedido.Glosa,
                DetalleOrdenPedidoList = pedido.DetalleList.Select(p => new DetalleOrdenPedido
                {
                    Cantidad = p.Cantidad,
                    ProductoId = p.ProductoId,
                    UnidadMedida = p.UnidadMedida,
                    Observacion = p.Observacion,
                    UsuarioCreacion = "Aministrador",
                    FechaCreacion = DateTime.Now
                }).ToList(),
                UsuarioCreacion = "Aministrador",
                FechaCreacion = DateTime.Now,
                Estado = ((int) EstadoPedido.Pendiente).ToString()
            };
        }

        public static OrdenPedidoDto DomainToDto(OrdenPedido pedido, List<Sucursal> sucursalList, List<Empleado> empleadoList)
        {
            return new OrdenPedidoDto
            {
                SucursalList = SucursalConverter.ListToKeyValueList(sucursalList),
                SolicitanteList = EmpleadoConverter.ListToKeyValueList(empleadoList),
                NumeroPedido = pedido.NumeroPedido,
                FechaEntrega = pedido.FechaEntrega.ConvertToDdmmaaaa(),
                FechaPedido = pedido.FechaPedido.ConvertToDdmmaaaa(),
                SucursalId = pedido.SucursalId,
                SolicitanteId = pedido.SolicitanteId,
                Glosa = pedido.Glosa,
                DetalleList = pedido.DetalleOrdenPedidoList.Select(p => new DetalleOrdenPedidoDto
                {
                    Cantidad = p.Cantidad,
                    ProductoId = p.ProductoId,
                    ProductoNombre = p.Producto.Nombre,
                    UnidadMedida = p.UnidadMedida,
                    Observacion = p.Observacion
                }).ToList(),
                Estado = EstadoOrdenPedidoList().First(p => p.Key == pedido.Estado).Value
            };
        }

        public static List<KeyValuePair<string, string>> EstadoOrdenPedidoList()
        {
            return new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("", "-- Seleccionar --"),
                new KeyValuePair<string, string>(((int) EstadoPedido.Pendiente).ToString(), "Pendiente"),
                new KeyValuePair<string, string>(((int) EstadoPedido.Actualizado).ToString(), "Actualizado")
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