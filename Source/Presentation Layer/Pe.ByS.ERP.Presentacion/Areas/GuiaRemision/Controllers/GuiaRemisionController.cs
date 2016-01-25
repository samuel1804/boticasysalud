using System;
using System.Web.Mvc;
using Pe.ByS.ERP.CrossCutting.Common;
using Pe.ByS.ERP.CrossCutting.Common.JQGrid;
using Pe.ByS.ERP.Presentacion.Core;
using Pe.ByS.ERP.Services.BusinessLogic.Core;
using Pe.ByS.ERP.Services.BusinessLogic.Inter;

namespace Pe.ByS.ERP.Presentacion.Areas.GuiaRemision.Controllers
{
    public class GuiaRemisionController : BaseController
    {
        #region Variables Privadas

        private readonly IGuiaRemisionBL _guiaBL;

        #endregion

        #region Constructor

        public GuiaRemisionController(IGuiaRemisionBL guiaBL)
        {
            _guiaBL = guiaBL;
        }

        #endregion

        [HttpPost]
        public virtual JsonResult Listar(GridTable grid)
        {
            try
            {
                return ListarJqGrid(new ListJQGridParameter<Domain.GuiaRemision>
                {
                    Grid = grid,
                    BusinessLogicClass = _guiaBL,
                    SelecctionFormat = item => new Row
                    {
                        id = item.Id,
                        cell = new[]
                        {
                            Convert.ToString(item.Id),
                            item.FechaGuia.ConvertToDdmmaaaa(),
                            item.Serie
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

        public ActionResult ListGuiaRemision()
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
    }
}