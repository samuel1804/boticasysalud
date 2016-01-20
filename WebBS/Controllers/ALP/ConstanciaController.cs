using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBS.Models;

namespace WebBS.Controllers.ALP
{
    public class ConstanciaController : Controller
    {

        private BDBoticasEntities db = new BDBoticasEntities();

        public ActionResult Index()
        {

            var ordenPreparado = db.ALP_ORDEN_PREPARADO;

            return View("~/Views/ALP/Constancia/Index.cshtml", ordenPreparado);
        }

        public ActionResult Nuevo(string num_orden = null)
        {
            var ordenPreparado = db.ALP_ORDEN_PREPARADO.Where( o => o.num_orden_preparado.Contains(num_orden));
            return View("~/Views/ALP/Constancia/Nuevo.cshtml", ordenPreparado);
        }

    }
}
