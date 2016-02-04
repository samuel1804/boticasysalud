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
    public class LibroController : Controller
    {

        private BDBoticasEntities db = new BDBoticasEntities();

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

            return View("~/Views/ALP/Libro/Lista.cshtml");
        }

        public ActionResult Nuevo(string num_constancia = null)
        {

            var quimico = db.RRH_EMPLEADO.Where(x => x.Cod_puesto == 3).FirstOrDefault();

            var constancia = db.ALP_CONSTANCIA_PREPARADO.Where(x => x.num_constancia_preparado == num_constancia).FirstOrDefault();

            ViewBag.lstRecetaInsumo = constancia.ALP_CONSTANCIA_PREPARADO_INSUMO_ORDEN.Where(x => x.ALP_ORDEN_PREPARADO_INSUMO.ALP_INSUMO.psicotropico == false).Select(x=> new { nro = x.cod_insumo }).ToList();
            ViewBag.lstRecetaPsicotropico = constancia.ALP_CONSTANCIA_PREPARADO_INSUMO_ORDEN.Where(x => x.ALP_ORDEN_PREPARADO_INSUMO.ALP_INSUMO.psicotropico == true).ToList();

            ViewBag.psicotropico = constancia.ALP_CONSTANCIA_PREPARADO_INSUMO_ORDEN.Where(x => x.ALP_ORDEN_PREPARADO_INSUMO.ALP_INSUMO.psicotropico == true).Count();

            ViewBag.laboratorista = constancia.RRH_EMPLEADO.GetEmpleado();
            ViewBag.fechaElaboracion = constancia.fec_elaboracion.ToString("dd/MM/yyyy");
            ViewBag.fechaVencimiento = constancia.fec_elaboracion.AddDays(100).ToString("dd/MM/yyyy");
            ViewBag.quimico = quimico.GetEmpleado();

            return View("~/Views/ALP/Libro/Nuevo.cshtml", constancia);
        }

        [HttpPost]
        public ActionResult Guardar(string nroConstancia)
        {

            string nextNroLibro = "";
            string nextNroLibroPsico = "";

            try
            {
                var maxLibro = (from p in db.ALP_LIBRO_RECETA
                                 orderby p.cod_libro_receta descending
                                     select new { NroLibro = p.cod_libro_receta }).FirstOrDefault();

                string nextLibro = "";

                if (maxLibro == null)
                {
                    nextLibro = "1".PadLeft(8, '0');
                    nextNroLibro = String.Format("{0}-{1}-{2}", "LR", DateTime.Now.ToString("ddMMyyyy"), nextLibro);
                }
                else
                {
                    string[] temp = maxLibro.NroLibro.Split('-');

                    int nroReceta = int.Parse(temp[2]) + 1;

                    nextLibro = nroReceta.ToString().PadLeft(8, '0');

                    nextNroLibro = String.Format("{0}-{1}-{2}", "LR", DateTime.Now.ToString("ddMMyyyy"), nextLibro);
                }

                var constancia = db.ALP_CONSTANCIA_PREPARADO.Where(o => o.num_constancia_preparado == nroConstancia).FirstOrDefault();

                var psicotropico = constancia.ALP_CONSTANCIA_PREPARADO_INSUMO_ORDEN.Where(x => x.ALP_ORDEN_PREPARADO_INSUMO.ALP_INSUMO.psicotropico == true).Count();

                ALP_LIBRO_RECETA libro = new ALP_LIBRO_RECETA() { 
                    cod_libro_receta = nextNroLibro,
                    num_constancia_preparado = nroConstancia,
                    cod_quimico_laboratorista = 3,
                    fec_preparado = constancia.fec_elaboracion,
                    fec_vencimiento = constancia.fec_elaboracion.AddYears(1).Date,
                    nom_medico = constancia.ALP_ORDEN_PREPARADO.ALP_RECETA.nom_medico,
                    num_colegiatura_medico = constancia.ALP_ORDEN_PREPARADO.ALP_RECETA.num_colegiatura_medico,
                    cod_usu_regi = 3,
                    fec_usu_regi = DateTime.Now.Date,
                    cod_usu_modi = 3,
                    fec_usu_modi = DateTime.Now.Date
                };

                db.ALP_LIBRO_RECETA.Add(libro);

                var lstReceta = constancia.ALP_CONSTANCIA_PREPARADO_INSUMO_ORDEN.Where(x => x.ALP_ORDEN_PREPARADO_INSUMO.ALP_INSUMO.psicotropico == false).ToList();

                foreach(ALP_CONSTANCIA_PREPARADO_INSUMO_ORDEN item in lstReceta)
                {
                    db.ALP_LIBRO_RECETA_INSUMO.Add(new ALP_LIBRO_RECETA_INSUMO() {
                        cod_libro_receta = nextNroLibro,
                        cod_insumo = item.cod_insumo,
                        cant_insumo_constancia = item.cant_insumo_constancia,
                        cod_usu_regi = 3,
                        fec_usu_regi = DateTime.Now.Date,
                        cod_usu_modi = 3,
                        fec_usu_modi = DateTime.Now.Date
                    });
                }

                if (psicotropico > 0)
                {

                    var maxLibroPsico = (from p in db.ALP_LIBRO_RECETA_PSICOTROPICO
                                 orderby p.cod_libro_receta_psicotropico descending
                                         select new { NroLibroPsico = p.cod_libro_receta_psicotropico }).FirstOrDefault();

                    string nextLibroPsico = "";

                    if (maxLibroPsico == null)
                    {
                        nextLibroPsico = "1".PadLeft(8, '0');
                        nextNroLibroPsico = String.Format("{0}-{1}-{2}", "LP", DateTime.Now.ToString("ddMMyyyy"), nextLibroPsico);
                    }
                    else
                    {
                        string[] temp = maxLibroPsico.NroLibroPsico.Split('-');

                        int nroLibroPsico = int.Parse(temp[2]) + 1;

                        nextLibroPsico = nroLibroPsico.ToString().PadLeft(8, '0');

                        nextNroLibroPsico = String.Format("{0}-{1}-{2}", "LP", DateTime.Now.ToString("ddMMyyyy"), nextLibroPsico);
                    }

                    ALP_LIBRO_RECETA_PSICOTROPICO libroPsico = new ALP_LIBRO_RECETA_PSICOTROPICO()
                    {
                        cod_libro_receta_psicotropico = nextNroLibroPsico,
                        num_constancia_preparado = nroConstancia,
                        cod_quimico_laboratorista = 3,
                        nom_paciente = constancia.ALP_ORDEN_PREPARADO.ALP_RECETA.nom_paciente,
                        num_docu_paciente = constancia.ALP_ORDEN_PREPARADO.ALP_RECETA.num_docu_paciente,
                        fec_preparado = constancia.fec_elaboracion,
                        fec_vencimiento = constancia.fec_elaboracion.AddYears(1).Date,
                        nom_medico = constancia.ALP_ORDEN_PREPARADO.ALP_RECETA.nom_medico,
                        num_colegiatura_medico = constancia.ALP_ORDEN_PREPARADO.ALP_RECETA.num_colegiatura_medico,
                        cod_usu_regi = 3,
                        fec_usu_regi = DateTime.Now.Date,
                        cod_usu_modi = 3,
                        fec_usu_modi = DateTime.Now.Date
                    };

                    db.ALP_LIBRO_RECETA_PSICOTROPICO.Add(libroPsico);

                    var lstRecetaPsico = constancia.ALP_CONSTANCIA_PREPARADO_INSUMO_ORDEN.Where(x => x.ALP_ORDEN_PREPARADO_INSUMO.ALP_INSUMO.psicotropico == true).ToList();

                    foreach (ALP_CONSTANCIA_PREPARADO_INSUMO_ORDEN item in lstRecetaPsico)
                    {
                        db.ALP_LIBRO_RECETA_PSICOTROPICO_INSUMO.Add(new ALP_LIBRO_RECETA_PSICOTROPICO_INSUMO()
                        {
                            cod_libro_receta_psicotropico = nextNroLibroPsico,
                            cod_insumo = item.cod_insumo,
                            cant_insumo_constancia = item.cant_insumo_constancia,
                            cod_usu_regi = 3,
                            fec_usu_regi = DateTime.Now.Date,
                            cod_usu_modi = 3,
                            fec_usu_modi = DateTime.Now.Date
                        });
                    }

                }

                constancia.estado = "03";

                db.ALP_CONSTANCIA_PREPARADO.Attach(constancia);

                var manager = ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager;

                manager.ChangeObjectState(constancia, EntityState.Modified);
                db.SaveChanges();


            }
            catch (Exception ex)
            {
                return Json(JsonResponseFactory.ErrorResponse(ex.Message));
            }

            return Json(JsonResponseFactory.SuccessResponse(nextNroLibro + "|" + nextNroLibroPsico));

        }

	}
}