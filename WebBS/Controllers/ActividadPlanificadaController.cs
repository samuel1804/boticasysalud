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
    public class ActividadPlanificadaController : Controller
    {
        private BDBoticasEntities db = new BDBoticasEntities();

        // GET: ActividadPlanificada
        public async Task<ActionResult> Index()
        {
            var iMP_ACTIVIDAD_PLANIFICADA = db.IMP_ACTIVIDAD_PLANIFICADA.Include(i => i.IMP_ACTIVIDAD).Include(i => i.IMP_SOLICITUD_GESTION_PERMISO).Include(i => i.RRH_Empleado);
            return View(await iMP_ACTIVIDAD_PLANIFICADA.ToListAsync());
        }

        // GET: ActividadPlanificada/Details/5
        public async Task<ActionResult> Details(int? id)
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

        // GET: ActividadPlanificada/Create
        public ActionResult Create()
        {
            ViewBag.Cod_actividad = new SelectList(db.IMP_ACTIVIDAD, "Cod_actividad", "Nombre");
            ViewBag.Cod_solicitud_gestion_permiso = new SelectList(db.IMP_SOLICITUD_GESTION_PERMISO, "Cod_solicitud_gestion_permiso", "Cod_solicitud_gestion_permiso");
            ViewBag.Cod_empleado = new SelectList(db.RRH_Empleado, "Cod_empleado", "Nom_empleado");
            return View();
        }

        // POST: ActividadPlanificada/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Cod_actividad_planificada,Descripcion,Fec_planificacion,Fec_cierre_planificacion,Estado,Prioridad,Adjunto,Cod_empleado,Cod_actividad,Cod_solicitud_gestion_permiso,Cod_usu_regi,Fec_usu_regi,Cod_usu_modi,Fec_usu_modi")] IMP_ACTIVIDAD_PLANIFICADA iMP_ACTIVIDAD_PLANIFICADA)
        {
            if (ModelState.IsValid)
            {
                db.IMP_ACTIVIDAD_PLANIFICADA.Add(iMP_ACTIVIDAD_PLANIFICADA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Cod_actividad = new SelectList(db.IMP_ACTIVIDAD, "Cod_actividad", "Nombre", iMP_ACTIVIDAD_PLANIFICADA.Cod_actividad);
            ViewBag.Cod_solicitud_gestion_permiso = new SelectList(db.IMP_SOLICITUD_GESTION_PERMISO, "Cod_solicitud_gestion_permiso", "Cod_solicitud_gestion_permiso", iMP_ACTIVIDAD_PLANIFICADA.Cod_solicitud_gestion_permiso);
            ViewBag.Cod_empleado = new SelectList(db.RRH_Empleado, "Cod_empleado", "Nom_empleado", iMP_ACTIVIDAD_PLANIFICADA.Cod_empleado);
            return View(iMP_ACTIVIDAD_PLANIFICADA);
        }

        // GET: ActividadPlanificada/Edit/5
        public async Task<ActionResult> Edit(int? id)
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
            ViewBag.Cod_actividad = new SelectList(db.IMP_ACTIVIDAD, "Cod_actividad", "Nombre", iMP_ACTIVIDAD_PLANIFICADA.Cod_actividad);
            ViewBag.Cod_solicitud_gestion_permiso = new SelectList(db.IMP_SOLICITUD_GESTION_PERMISO, "Cod_solicitud_gestion_permiso", "Cod_solicitud_gestion_permiso", iMP_ACTIVIDAD_PLANIFICADA.Cod_solicitud_gestion_permiso);
            ViewBag.Cod_empleado = new SelectList(db.RRH_Empleado, "Cod_empleado", "Nom_empleado", iMP_ACTIVIDAD_PLANIFICADA.Cod_empleado);
            return View(iMP_ACTIVIDAD_PLANIFICADA);
        }

        // POST: ActividadPlanificada/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Cod_actividad_planificada,Descripcion,Fec_planificacion,Fec_cierre_planificacion,Estado,Prioridad,Adjunto,Cod_empleado,Cod_actividad,Cod_solicitud_gestion_permiso,Cod_usu_regi,Fec_usu_regi,Cod_usu_modi,Fec_usu_modi")] IMP_ACTIVIDAD_PLANIFICADA iMP_ACTIVIDAD_PLANIFICADA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iMP_ACTIVIDAD_PLANIFICADA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Cod_actividad = new SelectList(db.IMP_ACTIVIDAD, "Cod_actividad", "Nombre", iMP_ACTIVIDAD_PLANIFICADA.Cod_actividad);
            ViewBag.Cod_solicitud_gestion_permiso = new SelectList(db.IMP_SOLICITUD_GESTION_PERMISO, "Cod_solicitud_gestion_permiso", "Cod_solicitud_gestion_permiso", iMP_ACTIVIDAD_PLANIFICADA.Cod_solicitud_gestion_permiso);
            ViewBag.Cod_empleado = new SelectList(db.RRH_Empleado, "Cod_empleado", "Nom_empleado", iMP_ACTIVIDAD_PLANIFICADA.Cod_empleado);
            return View(iMP_ACTIVIDAD_PLANIFICADA);
        }

        // GET: ActividadPlanificada/Delete/5
        public async Task<ActionResult> Delete(int? id)
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

        // POST: ActividadPlanificada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            IMP_ACTIVIDAD_PLANIFICADA iMP_ACTIVIDAD_PLANIFICADA = await db.IMP_ACTIVIDAD_PLANIFICADA.FindAsync(id);
            db.IMP_ACTIVIDAD_PLANIFICADA.Remove(iMP_ACTIVIDAD_PLANIFICADA);
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
