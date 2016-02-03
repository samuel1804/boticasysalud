using System;
using System.Collections.Generic;
using System.Linq;
using Pe.ByS.ERP.Application.DTO;
using Pe.ByS.ERP.CrossCutting.Common;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Application.Converter
{
    public class ActaRecepcionConverter
    {
        public static ActaRecepcionDto DataInicial(List<Sucursal> sucursalList, List<Empleado> empleadoList)
        {
            return new ActaRecepcionDto
            {
                SucursalList = SucursalConverter.ListToKeyValueList(sucursalList),
                VerificadorList = EmpleadoConverter.ListToKeyValueList(empleadoList),
                Fecha = DateTime.Now.ConvertToDdmmaaaa(),
                FechaGuia = DateTime.Now.ConvertToDdmmaaaa()
            };
        }

        public static ActaRecepcion DtoToDomain(ActaRecepcionDto acta)
        {
            return new ActaRecepcion
            {
                OrdenPedidoId = acta.OrdenPedidoId,
                NumGuia = acta.NumeroGuia,
                Glosa = acta.Glosa,
                AlmacenId = acta.AlmacenId,
                FechaActa = DateTime.Now,
                FechaGuia = Convert.ToDateTime(acta.FechaGuia),
                VerificadorId = acta.VerificadorId,
                DetalleActaRecepcion = acta.DetalleList.Select(p => new DetalleActaRecepcion
                {
                    Cantidad = p.CantidadRecepcionada,
                    ProductoId = p.ProductoId,
                    Lote = p.Lote,
                    UsuarioCreacion = "Administrador",
                    Diferencia = p.Saldo,
                    Observacion = p.Observacion,
                    FechaCreacion = DateTime.Now
                }).ToList(),
                UsuarioCreacion = "Aministrador",
                FechaCreacion = DateTime.Now
            };
        }
    }
}