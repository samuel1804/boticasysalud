using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Pe.ByS.ERP.Application.Converter;
using Pe.ByS.ERP.Application.DTO;
using Pe.ByS.ERP.CrossCutting.Common;
using Pe.ByS.ERP.CrossCutting.Common.JQGrid;
using Pe.ByS.ERP.Presentacion.Controllers;
using Pe.ByS.ERP.Services.BusinessLogic.Core;
using Pe.ByS.ERP.Services.BusinessLogic.Inter;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using Acta = Pe.ByS.ERP.Domain.ActaRecepcion;

namespace Pe.ByS.ERP.Presentacion.Areas.ActaRecepcion.Controllers
{
    public class ActaRecepcionController : BaseControlReportController
    {
        #region Variables Privadas

        private readonly IActaRecepcionBL _actaBL;
        private readonly ISucursalBL _sucursalBL;

        #endregion

        #region Constructor

        public ActaRecepcionController(IActaRecepcionBL actaBL, ISucursalBL sucursalBL)
        {
            _actaBL = actaBL;
            _sucursalBL = sucursalBL;
        }

        #endregion

        [HttpPost]
        public virtual JsonResult Listar(GridTable grid)
        {
            try
            {
                return ListarJqGrid(new ListJQGridParameter<Acta>
                {
                    Grid = grid,
                    BusinessLogicClass = _actaBL,
                    SelecctionFormat = item => new Row
                    {
                        id = item.Id,
                        cell = new[]
                        {
                            Convert.ToString(item.Id),
                            item.OrdenPedido.NumeroPedido,
                            item.FechaActa.ConvertToDdmmaaaa(),
                            item.Glosa,
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
            return View("ListarActa");
        }

        public ActionResult Edit()
        {
            var sucursalList = _sucursalBL.FindAll(p => true).ToList();
            return View("Edit", ActaRecepcionConverter.DataInicial(sucursalList));
        }

        public ActionResult ListadoGuia()
        {
            return View("ListarGuia");
        }

        [HttpPost]
        public virtual JsonResult ObtenerAlmacenes(int id)
        {
            var jsonResponse = new JsonResponse { Success = false };
            try
            {
                var sucursal = _sucursalBL.Get(p => p.Id == id);

                jsonResponse.Data = sucursal.AlmacenList.Select(p => new KeyValuePair<int, string>(p.Id, p.Descripcion));
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
        public virtual JsonResult GenerarActa(ActaRecepcionDto acta)
        {
            var jsonResponse = new JsonResponse { Success = false };
            try
            {
                _actaBL.Add(ActaRecepcionConverter.DtoToDomain(acta));
                jsonResponse.Success = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                jsonResponse.Message = "Ocurrió un error";
            }
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        public ActionResult GetReportSnapshot()
        {
            //var filters = CommonUtils.ToObject<List<WhereFilter>>(ParametrosReport);
            //var data = _anteproyectoAppService.FindPagination(LambdaManager.GetWhereFilter<AnteproyectoPaginationDto>(filters));

            var report = new StiReport();
            report.Load(Server.MapPath("~/Reports/ActaRecepcion.mrt"));
            report.RegBusinessObject("Proyecto", "Proyecto", null);

            return StiMvcViewer.GetReportSnapshotResult(report);
        }
    }
}