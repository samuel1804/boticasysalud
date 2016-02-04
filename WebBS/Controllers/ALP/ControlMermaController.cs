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
    public class ControlMermaController : Controller
    {

        private BDBoticasEntities db = new BDBoticasEntities();

        //
        // GET: /ControlMerma/
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

            return View("~/Views/ALP/ControlMerma/Lista.cshtml");
        }

        public ActionResult Nuevo(string num_constancia = null)
        {
            var constancia = db.ALP_CONSTANCIA_PREPARADO.Where(o => o.num_constancia_preparado.Contains(num_constancia)).FirstOrDefault();

            //ViewBag.cantidadMerma = constancia.ALP_CONSTANCIA_PREPARADO_INSUMO_ORDEN.Where(x => x.cant_insumo_diferencia > 0).Count();
            ViewBag.tecnicoLaboratorista = constancia.RRH_EMPLEADO.GetEmpleado();
            ViewBag.tecnicoFarmaceutico = constancia.ALP_ORDEN_PREPARADO.RRH_EMPLEADO.GetEmpleado();
            ViewBag.fechaConstancia = constancia.fec_elaboracion.ToString("dd/MM/yyyy");


            return View("~/Views/ALP/ControlMerma/Nuevo.cshtml", constancia);
        }

        [HttpPost]
        public ActionResult Guardar(string nroConstancia, string[] insumos)
        {

            string nextNroMerma = "";

            try
            {

                var maxMerma = (from p in db.ALP_HOJA_MERMA
                                     orderby p.num_hoja_merma descending
                                     select new { NroMerma = p.num_hoja_merma}).FirstOrDefault();

                string nextMerma = "";

                if (maxMerma == null)
                {
                    nextMerma = "1".PadLeft(8, '0');
                    nextNroMerma = String.Format("{0}-{1}-{2}", "CM", DateTime.Now.ToString("ddMMyyyy"), nextMerma);
                }
                else
                {
                    string[] temp = maxMerma.NroMerma.Split('-');

                    int nroMerma = int.Parse(temp[2]) + 1;

                    nextMerma = nroMerma.ToString().PadLeft(8, '0');

                    nextNroMerma = String.Format("{0}-{1}-{2}", "CM", DateTime.Now.ToString("ddMMyyyy"), nextMerma);
                }

                ALP_HOJA_MERMA hoja_merma = new ALP_HOJA_MERMA()
                {
                    num_hoja_merma = nextNroMerma,
                    num_constancia_preparado = nroConstancia,
                    estado = "01",
                    cod_usu_regi = 2,
                    fec_usu_regi = DateTime.Now.Date,
                    cod_usu_modi = 2,
                    fec_usu_modi = DateTime.Now.Date
                };

                db.ALP_HOJA_MERMA.Add(hoja_merma);

                for (int i = 0; i < insumos.Length; i++)
                {

                    string[] insumoSplit = insumos[i].Split('|');

                    db.ALP_HOJA_MERMA_INSUMO_CONSTANCIA.Add(new ALP_HOJA_MERMA_INSUMO_CONSTANCIA()
                    {
                        num_hoja_merma = nextNroMerma,
                        cod_insumo = insumoSplit[0],
                        cant_insumo_orden = int.Parse(insumoSplit[1]),
                        cant_insumo_constancia = int.Parse(insumoSplit[2]),
                        cant_insumo_merma = int.Parse(insumoSplit[3]),
                        motivo = insumoSplit[4]
                    });

                }

                /*var constancia = db.ALP_CONSTANCIA_PREPARADO.Where(o => o.num_constancia_preparado.Contains(nroConstancia)).FirstOrDefault();
                constancia.estado = "02";

                db.ALP_CONSTANCIA_PREPARADO.Attach(constancia);

                var manager = ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager;

                manager.ChangeObjectState(constancia, EntityState.Modified);*/
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                return Json(JsonResponseFactory.ErrorResponse(ex.Message));
            }

            return Json(JsonResponseFactory.SuccessResponse(nextNroMerma));
        }
	}
}