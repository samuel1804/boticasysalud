using System;
using System.Collections.Generic;
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

            foreach (RRH_Sucursal c in db.RRH_Sucursal.ToList())
            {
                SelectListItem i = new SelectListItem();
                i.Text = c.Nom_sucursal.ToString();
                i.Value = c.Cod_sucursal.ToString();
                selectList.Add(i);
            }

            ViewBag.Sucursales = selectList;

            return View("~/Views/ALP/ControlMerma/Lista.cshtml");
        }

        public ActionResult Nuevo(string num_constancia = null)
        {
            var constancia = db.ALP_CONSTANCIA_PREPARADO.Where(o => o.num_constancia_preparado.Contains(num_constancia)).FirstOrDefault();

            //ViewBag.tecnicoLaboratorista = constancia. .ALP_ORDEN_PREPARADO.RRH_Empleado.Nom_empleado + " " + constancia.ALP_ORDEN_PREPARADO.RRH_Empleado.Ap_paterno + " " + constancia.ALP_ORDEN_PREPARADO.RRH_Empleado.Ap_materno;
            ViewBag.tecnicoFarmaceutico = constancia.ALP_ORDEN_PREPARADO.RRH_Empleado.Nom_empleado + " " + constancia.ALP_ORDEN_PREPARADO.RRH_Empleado.Ap_paterno + " " + constancia.ALP_ORDEN_PREPARADO.RRH_Empleado.Ap_materno;
            ViewBag.fechaConstancia = constancia.fec_elaboracion.ToString("dd/MM/yyyy");


            return View("~/Views/ALP/ControlMerma/Nuevo.cshtml", constancia);
        }

        [HttpPost]
        public ActionResult Guardar(string nroConstancia, string[] insumos)
        {
            try
            {

            }
            catch (Exception ex)
            {
                return Json(JsonResponseFactory.ErrorResponse(ex.Message));
            }

            return Json(JsonResponseFactory.SuccessResponse());
        }
	}
}