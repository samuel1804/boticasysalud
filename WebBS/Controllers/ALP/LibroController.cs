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

            foreach (RRH_Sucursal c in db.RRH_Sucursal.ToList())
            {
                SelectListItem i = new SelectListItem();
                i.Text = c.Nom_sucursal.ToString();
                i.Value = c.Cod_sucursal.ToString();
                selectList.Add(i);
            }

            ViewBag.Sucursales = selectList;

            return View("~/Views/ALP/Libro/Lista.cshtml");
        }

        public ActionResult Nuevo(string num_constancia = null)
        {

            var quimico = db.RRH_Empleado.Where(x => x.Cod_puesto == 3).FirstOrDefault();

            var constancia = db.ALP_CONSTANCIA_PREPARADO.Where(x => x.num_constancia_preparado == num_constancia).FirstOrDefault();

            ViewBag.laboratorista = constancia.RRH_Empleado.GetEmpleado();
            ViewBag.fechaConstancia = constancia.fec_elaboracion.ToString("dd/MM/yyyy");
            ViewBag.quimico = quimico.GetEmpleado();

            return View("~/Views/ALP/Libro/Nuevo.cshtml", constancia);
        }

        [HttpPost]
        public ActionResult Guardar(string nroConstancia)
        {

            string nextNroLibro = "";

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

                ALP_LIBRO_RECETA libro = new ALP_LIBRO_RECETA() { 
                    cod_libro_receta = nextNroLibro,
                    num_constancia_preparado = nroConstancia,
                    cod_quimico_laboratorista = 3,
                    fec_preparado = DateTime.Now.Date,
                    cod_usu_regi = 3,
                    fec_usu_regi = DateTime.Now.Date,
                    cod_usu_modi = 3,
                    fec_usu_modi = DateTime.Now.Date
                };

                db.ALP_LIBRO_RECETA.Add(libro);

                var constancia = db.ALP_CONSTANCIA_PREPARADO.Where(o => o.num_constancia_preparado == nroConstancia).FirstOrDefault();
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

            return Json(JsonResponseFactory.SuccessResponse(nextNroLibro));

        }

	}
}