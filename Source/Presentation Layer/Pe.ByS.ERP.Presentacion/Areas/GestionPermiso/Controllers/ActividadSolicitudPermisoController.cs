using Pe.ByS.ERP.Presentacion.Core;

namespace Pe.ByS.ERP.Presentacion.Areas.GestionPermiso.Controllers
{
    public class ActividadSolicitudPermisoController : BaseController
    {
        /*#region Propiedades
        /// <summary>
        /// Servicio de manejo de Solicitudes de permisos
        /// </summary>
        public ISolicitudPermisoService solicitudPermisoService { get; set; }
        public IGeneralService generalService { get; set; }

        #endregion

        #region Vistas
        /// /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Index(int? codigo)
        {
            var modelo = solicitudPermisoService.ObtenerSolicitudPermisoPorId(codigo.Value);
            return View(modelo.Result);
        }

        public ActionResult FormularioActividad(int codigoSolicitud, int? codigoActividad)
        {
            var predecesoras = solicitudPermisoService.ListarActividadesSolicitudPermiso(codigoSolicitud).Result;
            predecesoras = predecesoras.Where(p => p.CodigoActividadPlanificada != codigoActividad).ToList();
            var filtradas = predecesoras.Select(a => a.CodigoActividad);
            var empleados = generalService.BuscarEmpleadoImportacion();
            ActividadSolicitudPermisoResponse actividadPlanificada = null;
            string tipo = null;
            string actividadEdit = null;
            if (codigoActividad.HasValue && codigoActividad.Value != default(int))
            {
                actividadPlanificada = solicitudPermisoService.ObtenerActividadesPlanificadaPorCodigo(codigoActividad.Value).Result;
                tipo = actividadPlanificada.CodigoTipoActividad;
                actividadEdit = actividadPlanificada.CodigoActividad.ToString();
            }
            var actividades = generalService.BuscarActividadPorTipo(tipo).Result;
            actividades = actividades.Where(a => !filtradas.Contains((int)a.Codigo) || a.Codigo == actividadEdit).ToList();
            var modelo = new FormularioActividadPlanificadaViewModel(predecesoras, empleados.Result, actividades);
            modelo.ActividadSolicitudPermisoResponse = actividadPlanificada;
            return PartialView(modelo);
        }

        public ActionResult ConfigurarAlerta()
        {
            return PartialView();
        }
        #endregion
        #region Json
        /// /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        [HttpPost]
        public JsonResult Listar(int codigo)
        {
            var solicitudes = solicitudPermisoService.ListarActividadesSolicitudPermiso(codigo);
            return Json(solicitudes);
        }

        public JsonResult ListarActividad(string tipoActividad, int codigoSolicitud, int? codigoActividadPlanificada)
        {
            var predecesoras = solicitudPermisoService.ListarActividadesSolicitudPermiso(codigoSolicitud).Result;
            predecesoras = predecesoras.Where(p => p.CodigoActividadPlanificada != codigoActividadPlanificada).ToList();
            var filtradas = predecesoras.Select(a => a.CodigoActividad).ToList();
            var actividades = generalService.BuscarActividadPorTipo(tipoActividad);
            actividades.Result = actividades.Result.Where(a => !filtradas.Contains((int)a.Codigo)).ToList();
            return Json(actividades);
        }

        public JsonResult GuardarPlanificacionActividad(ActividadSolicitudPermisoRequest actividad)
        {
            HttpPostedFileBase file = Request.Files.Count > 0 ? Request.Files[0] : null;
            if (file != null && file.ContentLength > 0)
            {
                var dataFile = actividad.CodigoSolicitudPermiso + DateTime.Now.ToString("ddMMyyyyhh") + "_" + Path.GetFileName(file.FileName);
                file.SaveAs(Server.MapPath("~/Files/") + dataFile);
                actividad.Adjunto = dataFile;
            }
            var resultado = solicitudPermisoService.GuardarPlanificacionActividad(actividad);
            return Json(resultado); ;
        }

        public JsonResult EliminarActividadPlanificada(int codigoActividadPlanificada)
        {
            var resultado = solicitudPermisoService.EliminarPlanificacionActividad(codigoActividadPlanificada);
            return Json(resultado); ;
        }

        public JsonResult ListarAlertaActividad(int codigo)
        {
            var lista = solicitudPermisoService.ListarAlertaActividad(codigo);
            return Json(lista);
        }

        public JsonResult GuardarAlertaActividad(AlertaActividadRequest actividad)
        {           
            var resultado = solicitudPermisoService.GuardarAlertaActividad(actividad);
            return Json(resultado); ;
        }

        public JsonResult EliminarAlertaActividad(int codigoAlertaActividad)
        {
            var resultado = solicitudPermisoService.EliminarAlertaActividad(codigoAlertaActividad);
            return Json(resultado); ;
        }
        #endregion*/
    }
}
