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
    public class BitacoraEventoDesaduanajeController : Controller
    {
        private BDBoticasEntities db = new BDBoticasEntities();

        // GET: BitacoraEventoDesaduanaje
        public async Task<ActionResult> Index(int? id)
        {
            if (!id.HasValue)
            {

                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                return RedirectToAction("Index", "SolicitudDesaduanaje", new { ReturnUrl = controllerName });
            }
            var imp_desaduanaje = await db.IMP_DESADUANAJE.FindAsync(id);
            return View(imp_desaduanaje);
        }

        // GET: BitacoraEventoDesaduanaje/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMP_BITACORA_EVENTO iMP_BITACORA_EVENTO = await db.IMP_BITACORA_EVENTO.FindAsync(id);
            if (iMP_BITACORA_EVENTO == null)
            {
                return HttpNotFound();
            }
            return View(iMP_BITACORA_EVENTO);
        }

        // GET: BitacoraEventoDesaduanaje/Create
        public ActionResult Create()
        {
            ViewBag.Cod_desaduanaje = new SelectList(db.IMP_DESADUANAJE, "Cod_desaduanaje", "Cod_desaduanaje");
            ViewBag.Cod_evento = new SelectList(db.IMP_EVENTO, "Cod_evento", "Cod_evento");
            ViewBag.Cod_pago_importacion = new SelectList(db.IMP_PAGO_IMPORTACION, "Cod_pago_importacion", "Cod_pago_importacion");
            return View();
        }

        // POST: BitacoraEventoDesaduanaje/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Cod_bitacora_evento,Cod_desaduanaje,Descripcion,Fec_evento,Observaciones,Cod_evento,Cod_pago_importacion,Cod_usu_regi,Fec_usu_regi,Cod_usu_modi,Fec_usu_modi")] IMP_BITACORA_EVENTO iMP_BITACORA_EVENTO)
        {
            if (ModelState.IsValid)
            {
                db.IMP_BITACORA_EVENTO.Add(iMP_BITACORA_EVENTO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Cod_desaduanaje = new SelectList(db.IMP_DESADUANAJE, "Cod_desaduanaje", "Cod_desaduanaje", iMP_BITACORA_EVENTO.Cod_desaduanaje);
            ViewBag.Cod_evento = new SelectList(db.IMP_EVENTO, "Cod_evento", "Cod_evento", iMP_BITACORA_EVENTO.Cod_evento);
            ViewBag.Cod_pago_importacion = new SelectList(db.IMP_PAGO_IMPORTACION, "Cod_pago_importacion", "Cod_pago_importacion", iMP_BITACORA_EVENTO.Cod_pago_importacion);
            return View(iMP_BITACORA_EVENTO);
        }

        // GET: BitacoraEventoDesaduanaje/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMP_BITACORA_EVENTO iMP_BITACORA_EVENTO = await db.IMP_BITACORA_EVENTO.FindAsync(id);
            if (iMP_BITACORA_EVENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cod_desaduanaje = new SelectList(db.IMP_DESADUANAJE, "Cod_desaduanaje", "Cod_desaduanaje", iMP_BITACORA_EVENTO.Cod_desaduanaje);
            ViewBag.Cod_evento = new SelectList(db.IMP_EVENTO, "Cod_evento", "Cod_evento", iMP_BITACORA_EVENTO.Cod_evento);
            ViewBag.Cod_pago_importacion = new SelectList(db.IMP_PAGO_IMPORTACION, "Cod_pago_importacion", "Cod_pago_importacion", iMP_BITACORA_EVENTO.Cod_pago_importacion);
            return View(iMP_BITACORA_EVENTO);
        }

        // POST: BitacoraEventoDesaduanaje/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Cod_bitacora_evento,Cod_desaduanaje,Descripcion,Fec_evento,Observaciones,Cod_evento,Cod_pago_importacion,Cod_usu_regi,Fec_usu_regi,Cod_usu_modi,Fec_usu_modi")] IMP_BITACORA_EVENTO iMP_BITACORA_EVENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iMP_BITACORA_EVENTO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Cod_desaduanaje = new SelectList(db.IMP_DESADUANAJE, "Cod_desaduanaje", "Cod_desaduanaje", iMP_BITACORA_EVENTO.Cod_desaduanaje);
            ViewBag.Cod_evento = new SelectList(db.IMP_EVENTO, "Cod_evento", "Cod_evento", iMP_BITACORA_EVENTO.Cod_evento);
            ViewBag.Cod_pago_importacion = new SelectList(db.IMP_PAGO_IMPORTACION, "Cod_pago_importacion", "Cod_pago_importacion", iMP_BITACORA_EVENTO.Cod_pago_importacion);
            return View(iMP_BITACORA_EVENTO);
        }

        // GET: BitacoraEventoDesaduanaje/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMP_BITACORA_EVENTO iMP_BITACORA_EVENTO = await db.IMP_BITACORA_EVENTO.FindAsync(id);
            if (iMP_BITACORA_EVENTO == null)
            {
                return HttpNotFound();
            }
            return View(iMP_BITACORA_EVENTO);
        }

        // POST: BitacoraEventoDesaduanaje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            IMP_BITACORA_EVENTO iMP_BITACORA_EVENTO = await db.IMP_BITACORA_EVENTO.FindAsync(id);
            db.IMP_BITACORA_EVENTO.Remove(iMP_BITACORA_EVENTO);
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
