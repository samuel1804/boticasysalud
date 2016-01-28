using System.Web.Mvc;
using Pe.ByS.ERP.Presentacion.Core;
using Stimulsoft.Report.Mvc;

namespace Pe.ByS.ERP.Presentacion.Controllers
{
    public class BaseControlReportController : BaseController
    {
        #region Members

        public string ParametrosReport
        {
            get
            {
                return TempData["Parametros"].ToString();
            }
        }

        #endregion

        #region Actions

        [HttpPost]
        public ActionResult StimulsoftControl(ViewerOptions options)
        {
            TempData["Parametros"] = options.Parameters ?? string.Empty;

            return PartialView(options);
        }

        //public ActionResult ViewerEvent(string parameters)
        //{
        //    return StiMvcViewer.ViewerEventResult();
        //}

        [HttpPost]
        public ActionResult ViewerEvent()
        {
            return StiMvcViewer.ViewerEventResult();
        }

        [HttpPost]
        public ActionResult PrintReport()
        {
            return StiMvcViewer.PrintReportResult();
        }

        [HttpPost]
        public ActionResult ExportReport()
        {
            return StiMvcViewer.ExportReportResult();
        }

        [HttpPost]
        public ActionResult Interaction()
        {
            return StiMvcViewer.InteractionResult();
        }

        #endregion
    }
}