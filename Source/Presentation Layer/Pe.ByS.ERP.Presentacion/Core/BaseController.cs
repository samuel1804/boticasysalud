using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web.Mvc;
using Common.Logging;
using Microsoft.Reporting.WinForms;
using Pe.ByS.ERP.CrossCutting.Common;
using Pe.ByS.ERP.CrossCutting.Common.JQGrid;
using Pe.ByS.ERP.Domain.Core;
using Pe.ByS.ERP.Services.BusinessLogic.Core;
using SIGCOMT.Comun.Enum;

namespace Pe.ByS.ERP.Presentacion.Core
{
    //[HandleError]
    public class BaseController : Controller
    {
        #region Variables Privadas

        protected static readonly ILog Logger = LogManager.GetLogger(string.Empty);

        #endregion

        #region Constructor

        public BaseController()
        {
        }

        #endregion

        #region Métodos

        #region Paginacion

        protected JsonResult ListarJqGrid<T>(ListJQGridParameter<T> parameter) where T : EntityBase
        {
            try
            {
                GridTable grid = parameter.Grid;

                grid.page = (grid.page == 0) ? 1 : grid.page;
                grid.rows = (grid.rows == 0) ? 100 : grid.rows;

                var where = UtilsComun.ConvertToLambda<T>(grid.filters).And(parameter.FiltrosAdicionales ?? (q => true));

                var parameters = new JQGridParameters<T>
                {
                    ColumnOrder = grid.sidx,
                    CurrentPage = grid.page,
                    OrderType = (TipoOrden) Enum.Parse(typeof (TipoOrden), grid.sord, true),
                    WhereFilter = where,
                    AmountRows = grid.rows
                };

                var generic = Listar(parameter.CountMethod, parameter.ListMethod, parameters,
                    parameter.ObjectIncludeList);
                generic.Value.rows = generic.List.Select(parameter.SelecctionFormat).ToArray();

                return Json(generic.Value);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return MensajeError();
            }
        }

        protected GenericDouble<JQgrid, T> Listar<T>(Func<Expression<Func<T, bool>>, int> countMethod,
            Func<JQGridParameters<T>, IQueryable<T>> listMethod, JQGridParameters<T> parameters,
            List<Expression<Func<T, object>>> includeList) where T : class
        {
            var jqgrid = new JQgrid();
            IList<T> list;

            try
            {
                int totalPages = 0;

                var count = countMethod(parameters.WhereFilter);

                if (count > 0 && parameters.AmountRows > 0)
                {
                    if (count%parameters.AmountRows > 0)
                    {
                        totalPages = count/parameters.AmountRows + 1;
                    }
                    else
                    {
                        totalPages = count/parameters.AmountRows;
                    }

                    totalPages = totalPages == 0 ? 1 : totalPages;
                }

                parameters.CurrentPage = parameters.CurrentPage > totalPages ? totalPages : parameters.CurrentPage;

                parameters.Start = parameters.AmountRows*parameters.CurrentPage - parameters.AmountRows;
                if (parameters.Start < 0)
                {
                    parameters.Start = 0;
                }

                jqgrid.total = totalPages;
                jqgrid.page = parameters.CurrentPage;
                jqgrid.records = count;
                jqgrid.start = parameters.Start;

                var queryList = listMethod(parameters);

                if (includeList != null)
                {
                    queryList = includeList.Aggregate(queryList, (p, include) => p.Include(include));
                }

                list = queryList.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return new GenericDouble<JQgrid, T>(jqgrid, list);
        }

        #endregion Paginacion

        #region Control Error

        protected override void OnException(ExceptionContext filterContext)
        {
            Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];

            Logger.Error(string.Format("Controlador:{0}  Action:{1}  Mensaje:{2}", controllerName, actionName,
                filterContext.Exception.Message));
            filterContext.Result = View("Error");
        }

        protected JsonResult MensajeError(string mensaje = "Ocurrio un error al cargar...")
        {
            Response.StatusCode = 404;
            return Json(new JsonResponse {Message = mensaje}, JsonRequestBehavior.AllowGet);
        }

        protected void LogError(Exception exception)
        {
            Logger.Error(string.Format("Mensaje: {0} Trace: {1}", exception.Message, exception.StackTrace));
        }

        #endregion Control Error

        #region Reportes

        /// <summary>
        /// Renderiza un reporte con sus datos
        /// </summary>
        /// <param name="report">Nombre del reporte</param>
        /// <param name="ds">Conjunto de Datos</param>
        /// <param name="data">Datos</param>
        /// <param name="formato">Formato PDF o Excel</param>
        /// <param name="parametros"></param>
        public void RenderReport(string report, string ds, object data, string formato, ReportParameter[] parametros = null)
        {
            string reportPath = Server.MapPath(string.Format("~/Reports/{0}.rdlc", report));
            var localReport = new LocalReport { ReportPath = reportPath };
            var reportDataSource = new ReportDataSource(ds, data);

            localReport.DataSources.Add(reportDataSource);
            if (parametros != null)
                localReport.SetParameters(parametros);

            string reportType;
            string deviceInfo = string.Empty;

            switch (formato)
            {
                case "PDF":
                    reportType = "PDF";
                    deviceInfo =
                        string.Format(
                            "<DeviceInfo><OutputFormat>{0}</OutputFormat><PageWidth>8.9in</PageWidth><PageHeight>11in</PageHeight><MarginTop>0.2in</MarginTop><MarginLeft>0.2in</MarginLeft><MarginRight>0.2in</MarginRight><MarginBottom>0.2in</MarginBottom></DeviceInfo>",
                            reportType);
                    break;
                case "EXCEL":
                    reportType = "Excel";

                    break;
                default:
                    return;
            }

            string mimeType;
            string encoding;
            string fileNameExtension;
            Warning[] warnings;
            string[] streams;

            byte[] renderedBytes = localReport.Render(reportType, deviceInfo, out mimeType, out encoding,
                                                      out fileNameExtension, out streams, out warnings);

            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition",
                                                   string.Format("attachment; filename={0}.{1}",
                                                                 UtilsComun.GetReporteName(report), fileNameExtension));
            Response.BinaryWrite(renderedBytes);
            Response.End();
        }

        #endregion

        #endregion
    }
}