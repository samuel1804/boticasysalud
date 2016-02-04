using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBS.Models;
using WebBS.Models.ALP;

namespace WebBS.Controllers.ALP
{
    public class OrdenPreparadoController : Controller
    {

        private BDBoticasEntities db = new BDBoticasEntities();

        [HttpPost]
        public ActionResult BuscarOrden(string nroOrden, string fechaOrden, string nomPreparado, int sucursal)
        {

            try
            {

                DateTime tmpFechaOrden = DateTime.Parse(fechaOrden);

                var orden = db.ALP_ORDEN_PREPARADO.Where(o => o.estado == "01" &&
                                                              o.num_orden_preparado.Contains(String.IsNullOrEmpty(nroOrden) ? o.num_orden_preparado : nroOrden) &&
                                                              o.ALP_RECETA.nom_preparado.Contains(String.IsNullOrEmpty(nomPreparado) ? o.ALP_RECETA.nom_preparado : nomPreparado) &&
                                                              o.RRH_SUCURSAL.cod_sucursal == (sucursal == -1 ? o.RRH_SUCURSAL.cod_sucursal : sucursal) &&
                                                              o.fec_orden.Year == (tmpFechaOrden.Year > 0 ? tmpFechaOrden.Year : o.fec_orden.Year) &&
                                                              o.fec_orden.Month == (tmpFechaOrden.Month > 0 ? tmpFechaOrden.Month : o.fec_orden.Month) &&
                                                              o.fec_orden.Day == (tmpFechaOrden.Day > 0 ? tmpFechaOrden.Day : o.fec_orden.Day)).ToList()
                            .Select(x=> new { nroOrden = x.num_orden_preparado, 
                                              nomPreparado = x.ALP_RECETA.nom_preparado, 
                                              fechaOrden = x.fec_orden.ToString("dd/MM/yyyy"),
                                              sucursal = x.RRH_SUCURSAL.Descripcion
                            }).ToList();


                return Json(JsonResponseFactory.SuccessResponse(orden.ToList()));

            
            }
            catch (Exception ex)
            {
                return Json(JsonResponseFactory.ErrorResponse(ex.Message));
            }

        }
	}
}