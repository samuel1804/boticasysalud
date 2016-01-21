using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBS.Models;

namespace WebBS.Controllers
{
    public class BitacoraActividadPlanificadaController : Controller
    {
        private BDBoticasEntities db = new BDBoticasEntities();

        // GET: BitacoraActividadPlanificada
        public async Task<ActionResult> Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMP_ACTIVIDAD_PLANIFICADA iMP_ACTIVIDAD_PLANIFICADA = await db.IMP_ACTIVIDAD_PLANIFICADA.FindAsync(id);
            if (iMP_ACTIVIDAD_PLANIFICADA == null)
            {
                return HttpNotFound();
            }
            return View(iMP_ACTIVIDAD_PLANIFICADA);
        }

        // GET: BitacoraActividadPlanificada/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMP_ACCION iMP_ACCION = await db.IMP_ACCION.FindAsync(id);
            if (iMP_ACCION == null)
            {
                return HttpNotFound();
            }
            return View(iMP_ACCION);
        }

        // GET: BitacoraActividadPlanificada/Create
        public ActionResult Create(int id)
        {
            ViewBag.Cod_actividad_planificada = id;//= new SelectList(db.IMP_ACTIVIDAD_PLANIFICADA, "Cod_actividad_planificada", "Observacion");
            return View();
        }

        // POST: BitacoraActividadPlanificada/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Cod_actividad_planificada,Fec_accion,Evidencia,Observaciones")] IMP_ACCION iMP_ACCION)
        {
            if (ModelState.IsValid)
            {
                iMP_ACCION.Cod_usu_regi = 1;
                iMP_ACCION.Fec_usu_regi = System.DateTime.Now;
                db.IMP_ACCION.Add(iMP_ACCION);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            return View(iMP_ACCION);
        }

        // GET: BitacoraActividadPlanificada/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMP_ACCION iMP_ACCION = await db.IMP_ACCION.FindAsync(id);
            if (iMP_ACCION == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cod_actividad_planificada = new SelectList(db.IMP_ACTIVIDAD_PLANIFICADA, "Cod_actividad_planificada", "Observacion", iMP_ACCION.Cod_actividad_planificada);
            return View(iMP_ACCION);
        }

        // POST: BitacoraActividadPlanificada/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Cod_accion,Fec_accion,Evidencia,Observaciones,Cod_actividad_planificada,Cod_usu_regi,Fec_usu_regi,Cod_usu_modi,Fec_usu_modi")] IMP_ACCION iMP_ACCION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iMP_ACCION).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Cod_actividad_planificada = new SelectList(db.IMP_ACTIVIDAD_PLANIFICADA, "Cod_actividad_planificada", "Observacion", iMP_ACCION.Cod_actividad_planificada);
            return View(iMP_ACCION);
        }

        // GET: BitacoraActividadPlanificada/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMP_ACCION iMP_ACCION = await db.IMP_ACCION.FindAsync(id);
            if (iMP_ACCION == null)
            {
                return HttpNotFound();
            }
            return View(iMP_ACCION);
        }

        // POST: BitacoraActividadPlanificada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            IMP_ACCION iMP_ACCION = await db.IMP_ACCION.FindAsync(id);
            db.IMP_ACCION.Remove(iMP_ACCION);
            await db.SaveChangesAsync();
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
