using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBS.Models;
using WebBS.Models.ALP;

namespace WebBS.Controllers.ALP
{
    public class SolicitudController : Controller
    {

        private BDBoticasEntities db = new BDBoticasEntities();

        //
        // GET: /Solicitud/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Nuevo(string num_constancia = null)
        {

            var quimico = db.RRH_EMPLEADO.Where(x => x.Cod_puesto == 3).FirstOrDefault();

            List<SelectListItem> selectList = new List<SelectListItem>();

            SelectListItem t = new SelectListItem();

            foreach (RRH_SUCURSAL c in db.RRH_SUCURSAL.ToList())
            {
                SelectListItem i = new SelectListItem();
                i.Text = c.Descripcion.ToString();
                i.Value = c.cod_sucursal.ToString();
                selectList.Add(i);
            }

            var constancia = db.ALP_CONSTANCIA_PREPARADO.Where(x => x.num_constancia_preparado == num_constancia).FirstOrDefault();

            ViewBag.fechaSolicitud = DateTime.Today.Date.ToString("dd/MM/yyyy");
            ViewBag.SelSucursal = constancia.ALP_ORDEN_PREPARADO.RRH_SUCURSAL.cod_sucursal;
            ViewBag.Sucursales = selectList;
            ViewBag.Quimico = quimico.GetEmpleado();

            return View("~/Views/ALP/Solicitud/Nuevo.cshtml", constancia);
        }

        public ActionResult Modificar(string num_solicitud = null)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            SelectListItem t = new SelectListItem();

            foreach (RRH_SUCURSAL c in db.RRH_SUCURSAL.ToList())
            {
                SelectListItem i = new SelectListItem();
                i.Text = c.Descripcion.ToString();
                i.Value = c.cod_sucursal.ToString();
                selectList.Add(i);
            }

            var solicitud = db.ALP_SOLICITUD_TRANSPORTE.Where(x => x.num_solicitud == num_solicitud).FirstOrDefault();

            ViewBag.quimico = solicitud.RRH_EMPLEADO.GetEmpleado();
            ViewBag.fechaSolicitud = solicitud.fec_solicitud.ToString("dd/MM/yyyy");
            ViewBag.SelSucursal = solicitud.cod_sucursal_destino;
            ViewBag.Sucursales = selectList;

            return View("~/Views/ALP/Solicitud/Modificar.cshtml", solicitud);
        }

        public ActionResult Lista()
        {

            var solicitud = db.ALP_SOLICITUD_TRANSPORTE;

            List<SelectListItem> selectList = new List<SelectListItem>();

            SelectListItem t = new SelectListItem();
            t.Text = "Todos";
            t.Value = "-1";
            selectList.Add(t);

            foreach (RRH_SUCURSAL c in db.RRH_SUCURSAL.ToList())
            {
                SelectListItem i = new SelectListItem();
                i.Text = c.Descripcion.ToString();
                i.Value = c.cod_sucursal.ToString();
                selectList.Add(i);
            }

            ViewBag.Sucursales = selectList;

            return View("~/Views/ALP/Solicitud/Lista.cshtml");
        }

        public ActionResult ListaConstancia()
        {

            List<SelectListItem> selectList = new List<SelectListItem>();

            SelectListItem t = new SelectListItem();
            t.Text = "Todos";
            t.Value = "-1";
            selectList.Add(t);

            foreach (RRH_SUCURSAL c in db.RRH_SUCURSAL.ToList())
            {
                SelectListItem i = new SelectListItem();
                i.Text = c.Descripcion.ToString();
                i.Value = c.cod_sucursal.ToString();
                selectList.Add(i);
            }

            ViewBag.Sucursales = selectList;

            return View("~/Views/ALP/Solicitud/ListaConstancia.cshtml");

        }

        [HttpPost]
        public ActionResult Guardar(string nroConstancia, string codSucursal, string obs)
        {

            string nextNroSolicitud = "";

            try
            {

                var maxSolicitud = (from p in db.ALP_SOLICITUD_TRANSPORTE
                                     orderby p.num_solicitud descending
                                     select new { NroSolicitud = p.num_solicitud }).FirstOrDefault();

                string nextSolicitud = "";

                if (maxSolicitud == null)
                {
                    nextSolicitud = "1".PadLeft(8, '0');
                    nextNroSolicitud = String.Format("{0}-{1}-{2}", "ST", DateTime.Now.ToString("ddMMyyyy"), nextSolicitud);
                }
                else
                {
                    string[] temp = maxSolicitud.NroSolicitud.Split('-');

                    int nroReceta = int.Parse(temp[2]) + 1;

                    nextSolicitud = nroReceta.ToString().PadLeft(8, '0');

                    nextNroSolicitud = String.Format("{0}-{1}-{2}", "ST", DateTime.Now.ToString("ddMMyyyy"), nextSolicitud);
                }

                ALP_SOLICITUD_TRANSPORTE solicitud = new ALP_SOLICITUD_TRANSPORTE()
                {
                    num_solicitud = nextNroSolicitud,
                    num_constancia_preparado = nroConstancia,
                    motivo = obs,
                    cod_quimico_laboratorista = 3,
                    fec_solicitud = DateTime.Now.Date,
                    cod_usu_regi = 3,
                    fec_usu_regi = DateTime.Now.Date,
                    cod_usu_modi = 3,
                    fec_usu_modi = DateTime.Now.Date,
                    cod_sucursal_destino = int.Parse(codSucursal),
                    estado = "01"
                };

                db.ALP_SOLICITUD_TRANSPORTE.Add(solicitud);

                db.SaveChanges();

            }
            catch (Exception ex)
            {
                return Json(JsonResponseFactory.ErrorResponse(ex.Message));
            }

            return Json(JsonResponseFactory.SuccessResponse(nextNroSolicitud));

        }

        [HttpPost]
        public ActionResult Actualizar(string nroSolicitud, string codSucursal, string obs)
        {

            try
            {

                var manager = ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager;

                ALP_SOLICITUD_TRANSPORTE solicitud = db.ALP_SOLICITUD_TRANSPORTE.Where(x=> x.num_solicitud == nroSolicitud).FirstOrDefault();
                solicitud.cod_sucursal_destino = int.Parse(codSucursal);
                solicitud.motivo = obs;

                db.ALP_SOLICITUD_TRANSPORTE.Attach(solicitud);
                manager.ChangeObjectState(solicitud, EntityState.Modified);

                db.SaveChanges();

            }
            catch (Exception ex)
            {
                return Json(JsonResponseFactory.ErrorResponse(ex.Message));
            }

            return Json(JsonResponseFactory.SuccessResponse(nroSolicitud));

        }

        [HttpPost]
        public ActionResult BuscarSolicitud(string nroSolicitud, string fechaSolicitud, string nomPreparado, int sucursal)
        {

            try
            {

                DateTime defaultDate = new DateTime(1970, 1, 1);

                DateTime tmpFechaSolicitud = String.IsNullOrEmpty(fechaSolicitud) ? defaultDate : DateTime.Parse(fechaSolicitud);

                var solicitud = db.ALP_SOLICITUD_TRANSPORTE.Where(o => o.estado == "01" &&
                                                              o.num_solicitud.Contains(String.IsNullOrEmpty(nroSolicitud) ? o.num_solicitud : nroSolicitud) &&
                                                              o.ALP_CONSTANCIA_PREPARADO.ALP_ORDEN_PREPARADO.ALP_RECETA.nom_preparado.Contains(String.IsNullOrEmpty(nomPreparado) ? o.ALP_CONSTANCIA_PREPARADO.ALP_ORDEN_PREPARADO.ALP_RECETA.nom_preparado : nomPreparado) &&
                                                              o.ALP_CONSTANCIA_PREPARADO.ALP_ORDEN_PREPARADO.RRH_SUCURSAL.cod_sucursal == (sucursal == -1 ? o.ALP_CONSTANCIA_PREPARADO.ALP_ORDEN_PREPARADO.RRH_SUCURSAL.cod_sucursal : sucursal)).ToList()
                                                              .Where(o => o.fec_solicitud == (tmpFechaSolicitud == defaultDate ? o.fec_solicitud : tmpFechaSolicitud))
                            .Select(x => new
                            {
                                nroSolicitud = x.num_solicitud,
                                nomPreparado = x.ALP_CONSTANCIA_PREPARADO.ALP_ORDEN_PREPARADO.ALP_RECETA.nom_preparado,
                                fechaSolicitud = x.fec_solicitud.ToString("dd/MM/yyyy"),
                                quimico = x.RRH_EMPLEADO.GetEmpleado(),
                                sucursal = x.ALP_CONSTANCIA_PREPARADO.ALP_ORDEN_PREPARADO.RRH_SUCURSAL.Descripcion
                            }).ToList().OrderByDescending(x => x.fechaSolicitud);


                return Json(JsonResponseFactory.SuccessResponse(solicitud.ToList()));


            }
            catch (Exception ex)
            {
                return Json(JsonResponseFactory.ErrorResponse(ex.Message));
            }

        }
	}
}