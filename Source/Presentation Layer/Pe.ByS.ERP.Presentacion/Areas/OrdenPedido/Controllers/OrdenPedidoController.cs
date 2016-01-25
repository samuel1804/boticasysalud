using System;
using System.Web.Mvc;
using Pe.ByS.ERP.Application.Converter;
using Pe.ByS.ERP.CrossCutting.Common;
using Pe.ByS.ERP.CrossCutting.Common.JQGrid;
using Pe.ByS.ERP.Presentacion.Core;
using Pe.ByS.ERP.Services.BusinessLogic.Core;
using Pe.ByS.ERP.Services.BusinessLogic.Inter;

namespace Pe.ByS.ERP.Presentacion.Areas.OrdenPedido.Controllers
{
    public class OrdenPedidoController : BaseController
    {
        #region Variables Privadas

        private readonly IOrdenPedidoBL _ordenBL;

        #endregion

        #region Constructor

        public OrdenPedidoController(IOrdenPedidoBL ordenBL)
        {
            _ordenBL = ordenBL;
        }

        #endregion

        [HttpPost]
        public virtual JsonResult Listar(GridTable grid)
        {
            try
            {
                return ListarJqGrid(new ListJQGridParameter<Domain.OrdenPedido>
                {
                    Grid = grid,
                    BusinessLogicClass = _ordenBL,
                    SelecctionFormat = item => new Row
                    {
                        id = item.Id,
                        cell = new[]
                        {
                            Convert.ToString(item.Id),
                            item.FechaPedido.ConvertToDdmmaaaa(),
                            item.NumeroPedido
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                LogError(ex);
                return MensajeError();
            }
        }

        public ActionResult ListOrdenPedido()
        {
            try
            {
                return PartialView("ListaSeleccion");
            }
            catch (Exception ex)
            {
                LogError(ex);
                return MensajeError();
            }
        }

        [HttpPost]
        public ActionResult GetDetallePedido(string numPedido)
        {
            var jsonResponse = new JsonResponse { Success = false };
            try
            {
                var pedido = _ordenBL.Get(p => p.NumeroPedido == numPedido);

                jsonResponse.Data = OrdenPedidoConverter.DomainToDtoDetalleOrdenPedido(pedido);
                jsonResponse.Success = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                jsonResponse.Message = "Ocurrió un error";
            }
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }
    }
}