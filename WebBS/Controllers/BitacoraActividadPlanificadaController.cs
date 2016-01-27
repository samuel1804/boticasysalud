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
using System.IO;
using WebBS.Implement;

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
            if (iMP_ACTIVIDAD_PLANIFICADA.Estado == DatosConstantes.EstadoActividadPlanificada.Cerrado) {

                return RedirectToAction("Index", "ActividadPlanificada");
            }
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
            TempData["ActividadPlanificada"] = await db.IMP_ACTIVIDAD_PLANIFICADA.FindAsync(iMP_ACCION.Cod_actividad_planificada);
            if (iMP_ACCION == null)
            {
                return HttpNotFound();
            }
            return View(iMP_ACCION);
        }

        // GET: BitacoraActividadPlanificada/Create
        public async Task<ActionResult> Create(int id)
        {
            ViewBag.Cod_actividad_planificada = id;//= new SelectList(db.IMP_ACTIVIDAD_PLANIFICADA, "Cod_actividad_planificada", "Observacion");
            TempData["ActividadPlanificada"] = await db.IMP_ACTIVIDAD_PLANIFICADA.FindAsync(id);
            return View();
        }

        // POST: BitacoraActividadPlanificada/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Cod_actividad_planificada,Fec_accion,Observaciones")] IMP_ACCION iMP_ACCION)
        {
            ViewBag.Cod_actividad_planificada = iMP_ACCION.Cod_actividad_planificada;
            if (ModelState.IsValid)
            {
                iMP_ACCION.Evidencia = UploadFile(iMP_ACCION.Cod_actividad_planificada);
                iMP_ACCION.Cod_usu_regi = 1;
                iMP_ACCION.Fec_usu_regi = System.DateTime.Now;
                db.IMP_ACCION.Add(iMP_ACCION);
                var actividad = await db.IMP_ACTIVIDAD_PLANIFICADA.FindAsync(iMP_ACCION.Cod_actividad_planificada);
                TempData["ActividadPlanificada"] = actividad;
                actividad.Estado = DatosConstantes.EstadoActividadPlanificada.Proceso;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { Id = iMP_ACCION.Cod_actividad_planificada });
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
            TempData["ActividadPlanificada"] = await db.IMP_ACTIVIDAD_PLANIFICADA.FindAsync(iMP_ACCION.Cod_actividad_planificada);
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
        public async Task<ActionResult> Edit([Bind(Include = "Cod_accion,Fec_accion,Evidencia,Observaciones,Cod_actividad_planificada")] IMP_ACCION iMP_ACCION)
        {
            if (ModelState.IsValid)
            {

                IMP_ACCION iMP_ACCIONTemp = await db.IMP_ACCION.FindAsync(iMP_ACCION.Cod_accion);

                iMP_ACCIONTemp.Evidencia = UploadFile(iMP_ACCION.Cod_actividad_planificada) ?? iMP_ACCION.Evidencia;
                iMP_ACCIONTemp.Fec_accion = iMP_ACCION.Fec_accion;
                iMP_ACCIONTemp.Observaciones = iMP_ACCION.Observaciones;
                iMP_ACCION.Cod_usu_modi = 1;
                iMP_ACCION.Fec_usu_modi = DateTime.Now;
                //db.Entry(iMP_ACCION).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { Id = iMP_ACCION.Cod_actividad_planificada });
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
            TempData["ActividadPlanificada"] = await db.IMP_ACTIVIDAD_PLANIFICADA.FindAsync(iMP_ACCION.Cod_actividad_planificada);
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
            return RedirectToAction("Index", new { Id = iMP_ACCION.Cod_actividad_planificada });
        }
        // POST: BitacoraActividadPlanificada/Delete/5
        [HttpPost]
        public async Task<JsonResult> CerrarActividad(int id)
        {
            var actividad = await db.IMP_ACTIVIDAD_PLANIFICADA.FindAsync(id);
            actividad.Estado = DatosConstantes.EstadoActividadPlanificada.Cerrado;
            await db.SaveChangesAsync();
            return Json(new { IsSuccess = true });
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private string UploadFile(int actividad)
        {
            string result = null;
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = actividad + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "_" + Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Evidencias"), fileName);
                    file.SaveAs(path);
                    result = "~/Evidencias/" + fileName;
                }
            }
            return result;
        }
    }
}
