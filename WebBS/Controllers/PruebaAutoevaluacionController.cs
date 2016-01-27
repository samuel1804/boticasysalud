using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBS.Models;
using WebBS.DTO;
namespace WebBS.Controllers
{
    public class PruebaAutoevaluacionController : Controller
    {
        private BDBoticasEntities db = new BDBoticasEntities();

        // GET: /PruebaAutoevaluacion/
        public ActionResult Index()
        {
            var rrh_pruebaautoevaluacion = db.RRH_PruebaAutoevaluacion.Include(r => r.RRH_Empleado);
            return View(rrh_pruebaautoevaluacion.ToList());
        }

        // GET: /PruebaAutoevaluacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RRH_PruebaAutoevaluacion rrh_pruebaautoevaluacion = db.RRH_PruebaAutoevaluacion.Find(id);
            if (rrh_pruebaautoevaluacion == null)
            {
                return HttpNotFound();
            }
            return View(rrh_pruebaautoevaluacion);
        }

        // GET: /PruebaAutoevaluacion/Create
        public ActionResult Create()
        {
            ViewBag.Cod_empleado = new SelectList(db.RRH_Empleado, "Cod_empleado", "Nom_empleado");
            ViewBag.Alternativas = db.RRH_AlternativaAutoevaluacion.ToList();
            ViewBag.Criterios = db.RRH_Criterio.ToList();
            return View();
        }

        // POST: /PruebaAutoevaluacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Cod_autoevaluacion,Fec_evaluacion,VersionEvaluacion,Cod_usu_regi,Fec_usu_regi,Cod_usu_modi,Fec_usu_modi,Cod_empleado,PuntajeTotal")] RRH_PruebaAutoevaluacion rrh_pruebaautoevaluacion)
        {
            if (ModelState.IsValid)
            {
                db.RRH_PruebaAutoevaluacion.Add(rrh_pruebaautoevaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cod_empleado = new SelectList(db.RRH_Empleado, "Cod_empleado", "Nom_empleado", rrh_pruebaautoevaluacion.Cod_empleado);
            return View(rrh_pruebaautoevaluacion);
        }

        // GET: /PruebaAutoevaluacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RRH_PruebaAutoevaluacion rrh_pruebaautoevaluacion = db.RRH_PruebaAutoevaluacion.Find(id);
            if (rrh_pruebaautoevaluacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cod_empleado = new SelectList(db.RRH_Empleado, "Cod_empleado", "Nom_empleado", rrh_pruebaautoevaluacion.Cod_empleado);
            return View(rrh_pruebaautoevaluacion);
        }

        // POST: /PruebaAutoevaluacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Cod_autoevaluacion,Fec_evaluacion,VersionEvaluacion,Cod_usu_regi,Fec_usu_regi,Cod_usu_modi,Fec_usu_modi,Cod_empleado,PuntajeTotal")] RRH_PruebaAutoevaluacion rrh_pruebaautoevaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rrh_pruebaautoevaluacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cod_empleado = new SelectList(db.RRH_Empleado, "Cod_empleado", "Nom_empleado", rrh_pruebaautoevaluacion.Cod_empleado);
            return View(rrh_pruebaautoevaluacion);
        }

        // GET: /PruebaAutoevaluacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RRH_PruebaAutoevaluacion rrh_pruebaautoevaluacion = db.RRH_PruebaAutoevaluacion.Find(id);
            if (rrh_pruebaautoevaluacion == null)
            {
                return HttpNotFound();
            }
            return View(rrh_pruebaautoevaluacion);
        }

        // POST: /PruebaAutoevaluacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RRH_PruebaAutoevaluacion rrh_pruebaautoevaluacion = db.RRH_PruebaAutoevaluacion.Find(id);
            db.RRH_PruebaAutoevaluacion.Remove(rrh_pruebaautoevaluacion);
            db.SaveChanges();
            return RedirectToAction("Index");
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
