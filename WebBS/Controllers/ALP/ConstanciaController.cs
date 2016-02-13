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
    public class ConstanciaController : Controller
    {

        private BDBoticasEntities db = new BDBoticasEntities();

        public ActionResult Index()
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

            return View("~/Views/ALP/Constancia/Index.cshtml");
        }

        public ActionResult Lista()
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

            return View("~/Views/ALP/Constancia/Lista.cshtml");
        }

        [HttpPost]
        public ActionResult BuscarConstanciaConHM(string nroConstancia, string fechaConstancia, string nomPreparado, int sucursal)
        {

            try
            {

                DateTime tmpFechaConstancia = DateTime.Parse(fechaConstancia);

                var constancia = db.ALP_CONSTANCIA_PREPARADO.Where(o => o.estado == "01" &&
                                                              o.ALP_HOJA_MERMA.Count > 0 &&
                                                              o.num_constancia_preparado.Contains(String.IsNullOrEmpty(nroConstancia) ? o.num_constancia_preparado : nroConstancia) &&
                                                              o.ALP_ORDEN_PREPARADO.ALP_RECETA.nom_preparado.Contains(String.IsNullOrEmpty(nomPreparado) ? o.ALP_ORDEN_PREPARADO.ALP_RECETA.nom_preparado : nomPreparado) &&
                                                              o.ALP_ORDEN_PREPARADO.RRH_SUCURSAL.cod_sucursal == (sucursal == -1 ? o.ALP_ORDEN_PREPARADO.RRH_SUCURSAL.cod_sucursal: sucursal) &&
                                                              o.fec_elaboracion.Year == (tmpFechaConstancia.Year > 0 ? tmpFechaConstancia.Year : o.fec_elaboracion.Year) &&
                                                              o.fec_elaboracion.Month == (tmpFechaConstancia.Month > 0 ? tmpFechaConstancia.Month : o.fec_elaboracion.Month) &&
                                                              o.fec_elaboracion.Day == (tmpFechaConstancia.Day > 0 ? tmpFechaConstancia.Day : o.fec_elaboracion.Day)).ToList()
                            .Select(x => new
                            {
                                nroConstancia = x.num_constancia_preparado,
                                nomPreparado = x.ALP_ORDEN_PREPARADO.ALP_RECETA.nom_preparado,
                                fechaConstancia = x.fec_elaboracion.ToString("dd/MM/yyyy"),
                                sucursal = x.ALP_ORDEN_PREPARADO.RRH_SUCURSAL.Descripcion
                            }).ToList();


                return Json(JsonResponseFactory.SuccessResponse(constancia.ToList()));


            }
            catch (Exception ex)
            {
                return Json(JsonResponseFactory.ErrorResponse(ex.Message));
            }

        }

        [HttpPost]
        public ActionResult BuscarConstanciaAprobada(string nroConstancia, string fechaConstancia, string nomPreparado, int sucursal)
        {

            try
            {

                DateTime tmpFechaConstancia = DateTime.Parse(fechaConstancia);

                var lstConstancia = db.ALP_CONSTANCIA_PREPARADO.Where(o => o.estado == "03" &&
                                                              o.ALP_SOLICITUD_TRANSPORTE.Count == 0 &&
                                                              o.num_constancia_preparado.Contains(String.IsNullOrEmpty(nroConstancia) ? o.num_constancia_preparado : nroConstancia) &&
                                                              o.ALP_ORDEN_PREPARADO.ALP_RECETA.nom_preparado.Contains(String.IsNullOrEmpty(nomPreparado) ? o.ALP_ORDEN_PREPARADO.ALP_RECETA.nom_preparado : nomPreparado) &&
                                                              o.ALP_ORDEN_PREPARADO.RRH_SUCURSAL.cod_sucursal== (sucursal == -1 ? o.ALP_ORDEN_PREPARADO.RRH_SUCURSAL.cod_sucursal : sucursal) &&
                                                              o.fec_elaboracion.Year == (tmpFechaConstancia.Year > 0 ? tmpFechaConstancia.Year : o.fec_elaboracion.Year) &&
                                                              o.fec_elaboracion.Month == (tmpFechaConstancia.Month > 0 ? tmpFechaConstancia.Month : o.fec_elaboracion.Month) &&
                                                              o.fec_elaboracion.Day == (tmpFechaConstancia.Day > 0 ? tmpFechaConstancia.Day : o.fec_elaboracion.Day)).ToList()
                            .Select(x => new
                            {
                                nroConstancia = x.num_constancia_preparado,
                                nomPreparado = x.ALP_ORDEN_PREPARADO.ALP_RECETA.nom_preparado,
                                fechaConstancia = x.fec_elaboracion.ToString("dd/MM/yyyy"),
                                sucursal = x.ALP_ORDEN_PREPARADO.RRH_SUCURSAL.Descripcion
                            }).ToList();
               
                return Json(JsonResponseFactory.SuccessResponse(lstConstancia));


            }
            catch (Exception ex)
            {
                return Json(JsonResponseFactory.ErrorResponse(ex.Message));
            }

        }

        [HttpPost]
        public ActionResult BuscarConstanciaSinMerma(string nroConstancia, string fechaConstancia, string nomPreparado, int sucursal)
        {

            try
            {

                DateTime tmpFechaConstancia = DateTime.Parse(fechaConstancia);

                var lstConstancia = db.ALP_CONSTANCIA_PREPARADO.Where(o => o.estado == "01" &&
                                                              o.ALP_HOJA_MERMA.Count() == 0 &&
                                                              o.num_constancia_preparado.Contains(String.IsNullOrEmpty(nroConstancia) ? o.num_constancia_preparado : nroConstancia) &&
                                                              o.ALP_ORDEN_PREPARADO.ALP_RECETA.nom_preparado.Contains(String.IsNullOrEmpty(nomPreparado) ? o.ALP_ORDEN_PREPARADO.ALP_RECETA.nom_preparado : nomPreparado) &&
                                                              o.ALP_ORDEN_PREPARADO.RRH_SUCURSAL.cod_sucursal == (sucursal == -1 ? o.ALP_ORDEN_PREPARADO.RRH_SUCURSAL.cod_sucursal : sucursal) &&
                                                              o.fec_elaboracion.Year == (tmpFechaConstancia.Year > 0 ? tmpFechaConstancia.Year : o.fec_elaboracion.Year) &&
                                                              o.fec_elaboracion.Month == (tmpFechaConstancia.Month > 0 ? tmpFechaConstancia.Month : o.fec_elaboracion.Month) &&
                                                              o.fec_elaboracion.Day == (tmpFechaConstancia.Day > 0 ? tmpFechaConstancia.Day : o.fec_elaboracion.Day)).ToList()
                            .Select(x => new
                            {
                                nroConstancia = x.num_constancia_preparado,
                                nomPreparado = x.ALP_ORDEN_PREPARADO.ALP_RECETA.nom_preparado,
                                fechaConstancia = x.fec_elaboracion.ToString("dd/MM/yyyy"),
                                sucursal = x.ALP_ORDEN_PREPARADO.RRH_SUCURSAL.Descripcion
                            }).ToList();

                return Json(JsonResponseFactory.SuccessResponse(lstConstancia));


            }
            catch (Exception ex)
            {
                return Json(JsonResponseFactory.ErrorResponse(ex.Message));
            }

        }

        public ActionResult Nuevo(string num_orden = null)
        {

            var empleado = db.RRH_EMPLEADO.Where(x => x.cod_empleado == 2).FirstOrDefault();

            ViewBag.empleado = empleado.Nom_empleado + " " + empleado.Ap_paterno + " " + empleado.Ap_materno;
            ViewBag.fechaConstancia = DateTime.Today.Date.ToString("dd/MM/yyyy");

            var ordenPreparado = db.ALP_ORDEN_PREPARADO.Where( o => o.num_orden_preparado.Contains(num_orden));
            return View("~/Views/ALP/Constancia/Nuevo.cshtml", ordenPreparado.FirstOrDefault());
        }

        public ActionResult Modificar(string num_constancia = null)
        {

            var constancia = db.ALP_CONSTANCIA_PREPARADO.Where(o => o.num_constancia_preparado.Contains(num_constancia)).FirstOrDefault();

            ViewBag.tecnicoLaboratorista = constancia.RRH_EMPLEADO.GetEmpleado();
            ViewBag.tecnicoFarmaceutico = constancia.ALP_ORDEN_PREPARADO.RRH_EMPLEADO.GetEmpleado();
            ViewBag.fechaConstancia = constancia.fec_elaboracion.ToString("dd/MM/yyyy");


            return View("~/Views/ALP/Constancia/Modificar.cshtml", constancia);

        }

        [HttpPost]
        public ActionResult Guardar(string nroOrden, string[] insumos)
        {

            string nextNroConstancia = "";

            try
            {
                var maxConstancia = (from p in db.ALP_CONSTANCIA_PREPARADO
                                 orderby p.num_constancia_preparado descending
                                     select new { NroConstancia = p.num_constancia_preparado }).FirstOrDefault();

                string nextConstancia = "";

                if (maxConstancia == null)
                {
                    nextConstancia = "1".PadLeft(8, '0');
                    nextNroConstancia = String.Format("{0}-{1}-{2}", "CP", DateTime.Now.ToString("ddMMyyyy"), nextConstancia);
                }
                else
                {
                    string[] temp = maxConstancia.NroConstancia.Split('-');

                    int nroReceta = int.Parse(temp[2]) + 1;

                    nextConstancia = nroReceta.ToString().PadLeft(8, '0');

                    nextNroConstancia = String.Format("{0}-{1}-{2}", "CP", DateTime.Now.ToString("ddMMyyyy"), nextConstancia);
                }

                ALP_CONSTANCIA_PREPARADO constancia_preparado = new ALP_CONSTANCIA_PREPARADO() { 
                    num_constancia_preparado = nextNroConstancia,
                    num_orden_preparado = nroOrden,
                    fec_elaboracion = DateTime.Now.Date,
                    estado = "01",
                    cod_usu_regi = 2,
                    fec_usu_regi = DateTime.Now.Date,
                    cod_usu_modi = 2,
                    fec_usu_modi = DateTime.Now.Date,        
                    cod_empleado = 2
                };

                db.ALP_CONSTANCIA_PREPARADO.Add(constancia_preparado);

                for (int i = 0; i < insumos.Length; i++)
                {

                    string[] insumoSplit = insumos[i].Split('|');

                    db.ALP_CONSTANCIA_PREPARADO_INSUMO_ORDEN.Add(new ALP_CONSTANCIA_PREPARADO_INSUMO_ORDEN()
                    {
                        num_constancia_preparado = nextNroConstancia,
                        num_orden_preparado = nroOrden,
                        cod_insumo = insumoSplit[0],
                        //cant_insumo_orden = int.Parse(insumoSplit[1]),
                        cant_insumo_constancia = int.Parse(insumoSplit[2]),
                        //cant_insumo_diferencia = int.Parse(insumoSplit[3])
                    });

                }

                var ordenPreparado = db.ALP_ORDEN_PREPARADO.Where(o => o.num_orden_preparado.Contains(nroOrden)).FirstOrDefault();
                ordenPreparado.estado = "02";

                db.ALP_ORDEN_PREPARADO.Attach(ordenPreparado);

                var manager = ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager;

                manager.ChangeObjectState(ordenPreparado, EntityState.Modified);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                return Json(JsonResponseFactory.ErrorResponse(ex.Message));
            }

            return Json(JsonResponseFactory.SuccessResponse(nextNroConstancia));
        }

        [HttpPost]
        public ActionResult Actualizar(string nroConstancia, string motivo, string[] insumos)
        {

            try
            {

                var manager = ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager;

                var constancia = db.ALP_CONSTANCIA_PREPARADO.Where(x => x.num_constancia_preparado == nroConstancia).FirstOrDefault();
                constancia.motivo = motivo;

                db.ALP_CONSTANCIA_PREPARADO.Attach(constancia);
                manager.ChangeObjectState(constancia, EntityState.Modified);


                var constanciaXInsumoDel = db.ALP_CONSTANCIA_PREPARADO_INSUMO_ORDEN.Where(x => x.num_constancia_preparado == nroConstancia).ToList();

                foreach (ALP_CONSTANCIA_PREPARADO_INSUMO_ORDEN item in constanciaXInsumoDel)
                {
                    db.ALP_CONSTANCIA_PREPARADO_INSUMO_ORDEN.Remove(item);
                    manager.ChangeObjectState(item, EntityState.Deleted);
                }

                for (int i = 0; i < insumos.Length; i++)
                {
                    string[] insumoSplit = insumos[i].Split('|');

                    db.ALP_CONSTANCIA_PREPARADO_INSUMO_ORDEN.Add(new ALP_CONSTANCIA_PREPARADO_INSUMO_ORDEN()
                    {
                        num_constancia_preparado = nroConstancia,
                        num_orden_preparado = constancia.num_orden_preparado,
                        cod_insumo = insumoSplit[0],
                        //cant_insumo_orden = int.Parse(insumoSplit[1]),
                        cant_insumo_constancia = int.Parse(insumoSplit[2]),
                        //cant_insumo_diferencia = int.Parse(insumoSplit[3])

                    });
                }

                db.SaveChanges();

            }
            catch (Exception ex)
            {
                return Json(JsonResponseFactory.ErrorResponse(ex.Message));
            }

            return Json(JsonResponseFactory.SuccessResponse(nroConstancia));

        }

    }
}
