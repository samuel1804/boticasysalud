using System;
using System.Linq;
using System.Web.Mvc;
using Pe.ByS.ERP.Application.Converter;
using Pe.ByS.ERP.Application.DTO;
using Pe.ByS.ERP.CrossCutting.Common;
using Pe.ByS.ERP.CrossCutting.Common.Enums;
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
        private readonly ISucursalBL _sucursalBL;
        private readonly IProductoBL _productoBL;

        #endregion

        #region Constructor

        public OrdenPedidoController(IOrdenPedidoBL ordenBL, ISucursalBL sucursalBL, IProductoBL productoBL)
        {
            _ordenBL = ordenBL;
            _sucursalBL = sucursalBL;
            _productoBL = productoBL;
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
                    },
                    FiltrosAdicionales = p => p.Estado == ((int)EstadoPedido.Actualizado).ToString()
                });
            }
            catch (Exception ex)
            {
                LogError(ex);
                return MensajeError();
            }
        }

        [HttpPost]
        public virtual JsonResult ListarPedidos(GridTable grid)
        {
            try
            {
                var estados = OrdenPedidoConverter.EstadoOrdenPedidoList();
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
                            item.NumeroPedido,
                            item.FechaPedido.ConvertToDdmmaaaa(),
                            item.FechaEntrega.ConvertToDdmmaaaa(),
                            string.Format("{0} {1}, {2}", item.Solicitante.ApellidoPaterno,
                                item.Solicitante.ApellidoMaterno, item.Solicitante.Nombre),
                            estados.First(p => p.Key == item.Estado).Value
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

        public ActionResult Index()
        {
            return View("Index", OrdenPedidoConverter.EstadoOrdenPedidoList());
        }

        public ActionResult Edit()
        {
            var sucursalList = _sucursalBL.FindAll(p => true).ToList();
            return View("Edit", OrdenPedidoConverter.DataInicial(sucursalList));
        }

        [HttpPost]
        public virtual JsonResult ArgregarPedido(OrdenPedidoDto pedido)
        {
            var jsonResponse = new JsonResponse { Success = false };
            try
            {
                var ultimoPedido = _ordenBL.FindAll(p => true).OrderByDescending(p => p.Id).FirstOrDefault();
                if (ultimoPedido != null)
                    pedido.NumeroPedido = ultimoPedido.NumeroPedido;
                
                _ordenBL.Add(OrdenPedidoConverter.DtoToDomain(pedido));
                jsonResponse.Data = pedido.NumeroPedido;
                jsonResponse.Success = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                jsonResponse.Message = "Ocurrió un error";
            }
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult ActualizarPedido(OrdenPedidoDto pedido)
        {
            var jsonResponse = new JsonResponse { Success = false };
            try
            {
                var ultimoPedido = _ordenBL.FindAll(p => true).OrderByDescending(p => p.Id).FirstOrDefault();
                if (ultimoPedido != null)
                    pedido.NumeroPedido = ultimoPedido.NumeroPedido;

                _ordenBL.Add(OrdenPedidoConverter.DtoToDomain(pedido));
                jsonResponse.Data = pedido.NumeroPedido;
                jsonResponse.Success = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                jsonResponse.Message = "Ocurrió un error";
            }
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult EliminarPedido(int id)
        {
            var jsonResponse = new JsonResponse {Success = false};
            try
            {
                var pedido = _ordenBL.Get(p => p.Id == id);
                _ordenBL.Delete(pedido);
                jsonResponse.Success = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                jsonResponse.Message = "Ocurrió un error";
            }
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewProducto()
        {
            try
            {
                var list = _productoBL.FindAll(p => true).ToList();
                return PartialView(OrdenPedidoConverter.ProductoList(list));
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