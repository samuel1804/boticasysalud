using Pe.ByS.ERP.Presentacion.Core;

namespace Pe.ByS.ERP.Presentacion.Areas.GestionPermiso.Controllers
{
    public class SolicitudPermisoController : BaseController
    {
        /*#region Propiedades
        /// <summary>
        /// Servicio de manejo de Solicitudes de permisos
        /// </summary>
        public ISolicitudPermisoService solicitudPermisoService { get; set; }

        #endregion
        #region Vistas
        /// /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Index()
        {
            var modelo = new BuscarSolicitudPermisoViewModel(new List<CodigoValorResponse> { 
                new CodigoValorResponse {Codigo="1",Valor="En Proceso"},
                new CodigoValorResponse {Codigo="1",Valor="Terminado"}
            });
            return View(modelo);
        }
        /// /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        [HttpGet]
        public ActionResult Buscar()
        {
            var modelo = new BuscarSolicitudPermisoViewModel(new List<CodigoValorResponse> { 
                new CodigoValorResponse {Codigo="1",Valor="En Proceso"},
                new CodigoValorResponse {Codigo="1",Valor="Terminado"}
            });
            return View(modelo);
        }
        #endregion

        #region Vistas Parciales
        #endregion


        public ActionResult Mantenimiento()
        {
         return PartialView("Mantenimiento", null);
            
        }

        #region Json
        /// /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        [HttpPost]
        public JsonResult Buscar(SolicitudPermisoRequest filtro)
        {
            var solicitudes = solicitudPermisoService.BuscarSolicitudesPermiso(filtro);
            return Json(solicitudes);
        }
        #endregion*/
    }
}