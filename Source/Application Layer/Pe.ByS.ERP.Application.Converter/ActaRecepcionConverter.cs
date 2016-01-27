using System;
using System.Collections.Generic;
using System.Linq;
using Pe.ByS.ERP.Application.DTO;
using Pe.ByS.ERP.CrossCutting.Common;
using Pe.ByS.ERP.CrossCutting.Common.Enums;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Application.Converter
{
    public class ActaRecepcionConverter
    {
        public static ActaRecepcionDto DataInicial(List<Sucursal> sucursalList)
        {
            var list = sucursalList.ConvertAll(p => new KeyValuePair<string, string>(p.Id.ToString(), p.Nombre));
            list.Insert(0, new KeyValuePair<string, string>("", "-- Seleccionar --"));

            return new ActaRecepcionDto
            {
                SucursalList = list,
                VerificadorList = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("", "-- Seleccionar --"),
                    new KeyValuePair<string, string>("1", "Verificador 1"),
                    new KeyValuePair<string, string>("2", "Verificador 2"),
                },
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