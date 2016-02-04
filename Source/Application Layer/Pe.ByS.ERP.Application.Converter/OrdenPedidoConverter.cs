using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Caching;
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

        public static List<int> DtoToDomain(OrdenPedido pedidoDomain, OrdenPedidoDto pedidoDto)
        {
            pedidoDomain.FechaEntrega = Convert.ToDateTime(pedidoDto.FechaEntrega);
            pedidoDomain.FechaPedido = Convert.ToDateTime(pedidoDto.FechaPedido);
            pedidoDomain.SucursalId = pedidoDto.SucursalId;
            pedidoDomain.SolicitanteId = pedidoDto.SolicitanteId;
            pedidoDomain.Glosa = pedidoDto.Glosa;

            var detalleEliminar = new List<int>();
            foreach (var item in pedidoDomain.DetalleOrdenPedidoList)
            {
                var itemDto = pedidoDto.DetalleList.FirstOrDefault(p => p.ProductoId == item.ProductoId);
                if (itemDto != null)
                {
                    item.Cantidad = itemDto.Cantidad;
                    item.Observacion = itemDto.Observacion;
                    item.UsuarioModificacion = "Aministrador";
                    item.FechaModificacion = DateTime.Now;
                    pedidoDto.DetalleList.Remove(itemDto);
                }
                else
                {
                    detalleEliminar.Add(item.ProductoId);
                }
            }

            foreach (var item in pedidoDto.DetalleList)
            {
                pedidoDomain.DetalleOrdenPedidoList.Add(new DetalleOrdenPedido
                {
                    Cantidad = item.Cantidad,
                    ProductoId = item.ProductoId,
                    UnidadMedida = item.UnidadMedida,
                    Observacion = item.Observacion,
                    UsuarioCreacion = "Aministrador",
                    FechaCreacion = DateTime.Now
                });
            }

            pedidoDomain.UsuarioModificacion = "Aministrador";
            pedidoDomain.FechaModificacion = DateTime.Now;

            return detalleEliminar;
        }

        public static OrdenPedidoDto DomainToDto(OrdenPedido pedido, List<Sucursal> sucursalList, List<Empleado> empleadoList)
        {
            return new OrdenPedidoDto
            {
                Id = pedido.Id,
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