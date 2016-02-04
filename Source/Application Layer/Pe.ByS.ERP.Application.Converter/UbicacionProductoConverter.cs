using System;
using System.Collections.Generic;
using System.Linq;
using Pe.ByS.ERP.Application.DTO;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Application.Converter
{
    public class UbicacionProductoConverter
    {
        public static List<DetalleActaRecepcionReubicarDto> DomainToDtoList(ActaRecepcion acta)
        {
            return acta.DetalleActaRecepcion.Select(p => new DetalleActaRecepcionReubicarDto
            {
                Id = p.Id,
                ProductoId = p.ProductoId,
                Lote = p.Lote,
                ProductoNombre = p.Producto.Nombre,
                UnidadMedida = p.Producto.UnidadMedida,
                CantidadRecepcionada = p.Cantidad,
                AlmacenId = acta.AlmacenId,
                AlmacenNombre = acta.Almacen.Descripcion
            }).ToList();
        }

        public static UbicacionProducto DtoToDomain(DetalleActaRecepcionReubicarDto detalle)
        {
            return new UbicacionProducto
            {
                ProductoId = detalle.ProductoId,
                Lote = detalle.Lote,
                AlmacenId = detalle.AlmacenId,
                Cantidad = detalle.CantidadRecepcionada,
                Columna = detalle.Columna,
                Fila = detalle.Fila,
                Modulo = detalle.Modulo,
                UsuarioCreacion = "Aministrador",
                FechaCreacion = DateTime.Now
            };
        }

        public static List<UbicacionProducto> DtoToDomainList(List<DetalleActaRecepcionReubicarDto> detalle)
        {
            return detalle.Select(DtoToDomain).ToList();
        }
    }
}