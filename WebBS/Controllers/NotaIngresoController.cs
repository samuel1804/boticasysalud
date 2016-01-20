using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using WebBS.Models;

namespace WebBS.Controllers
{
    public class NotaIngresoController : Controller
    {
        private BDBoticasEntities db = new BDBoticasEntities();
        //
        // GET: /NotaIngreso/
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        //public JsonResult FillIndex()
        //{
        //    return Json(db.NotaIngreso.ToList(), JsonRequestBehavior.AllowGet);
        //}
	}
}