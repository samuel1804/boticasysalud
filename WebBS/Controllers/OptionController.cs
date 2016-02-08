using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBS.Models;

namespace WebBS.Controllers
{
    public class OptionController : Controller
    {
        private BDBoticasEntities db = new BDBoticasEntities();

        // GET: /Option/
        public ActionResult Index()
        {
            RRH_Usuario usuario = (RRH_Usuario)Session["Usuario"];

            List<RRH_Option> options = (from p in db.RRH_Puesto_Option
                             join e in db.RRH_Option on p.Optionid equals e.Optionid
                             where p.Cod_Puesto == usuario.RRH_Empleado.Cod_puesto select e).ToList();
                return View(options);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
