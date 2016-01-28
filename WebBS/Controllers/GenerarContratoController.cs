using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBS.Controllers
{
    public class GenerarContratoController : Controller
    {
        // GET: GenerarContrato
        public ActionResult Index()
        {
            return View();
        }

        // GET: GenerarContrato/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GenerarContrato/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenerarContrato/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GenerarContrato/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GenerarContrato/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GenerarContrato/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GenerarContrato/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
