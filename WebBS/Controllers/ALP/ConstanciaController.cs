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

            foreach (RRH_Sucursal c in db.RRH_Sucursal.ToList())
            {
                SelectListItem i = new SelectListItem();
                i.Text = c.Nom_sucursal.ToString();
                i.Value = c.Cod_sucursal.ToString();
                selectList.Add(i);
            }

            ViewBag.Sucursales = selectList;

            return View("~/Views/ALP/Constancia/Index.cshtml");
        }

        public ActionResult Nuevo(string num_orden = null)
        {

            var empleado = db.RRH_Empleado.Where(x => x.Cod_empleado == 2).FirstOrDefault();

            ViewBag.empleado = empleado.Nom_empleado + " " + empleado.Ap_paterno + " " + empleado.Ap_materno;
            ViewBag.fechaConstancia = DateTime.Today.Date.ToString("dd/MM/yyyy");

            var ordenPreparado = db.ALP_ORDEN_PREPARADO.Where( o => o.num_orden_preparado.Contains(num_orden));
            return View("~/Views/ALP/Constancia/Nuevo.cshtml", ordenPreparado.FirstOrDefault());
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
                    fec_usu_modi = DateTime.Now.Date                    
                };

                db.ALP_CONSTANCIA_PREPARADO.Add(constancia_preparado);

                for (int i = 0; i < insumos.Length; i++)
                {

                    string[] insumoSplit = insumos[i].Split('|');

                    db.ALP_CONSTANCIA_PREPARADO_INSUMO.Add(new ALP_CONSTANCIA_PREPARADO_INSUMO()
                    {
                        num_constancia_preparado = nextNroConstancia,
                        cod_insumo = insumoSplit[0],
                        cant_insumo_orden = int.Parse(insumoSplit[1]),
                        cant_insumo_constancia = int.Parse(insumoSplit[2]),
                        cant_insumo_diferencia = int.Parse(insumoSplit[3])
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

    }
}
