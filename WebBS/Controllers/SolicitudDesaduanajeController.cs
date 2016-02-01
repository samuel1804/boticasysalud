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
using System.Globalization;

namespace WebBS.Controllers
{
    public class SolicitudDesaduanajeController : Controller
    {
        private BDBoticasEntities db = new BDBoticasEntities();

        // GET: SolicitudDesaduanaje
        public async Task<ActionResult> Index()
        {
            var iMP_DESADUANAJE = db.IMP_DESADUANAJE.Include(i => i.IMP_SOLICITUD_IMPORTACION);
            return View(await iMP_DESADUANAJE.ToListAsync());
        }

        // GET: SolicitudDesaduanaje
        [HttpPost]
        public async Task<ActionResult> Index(int? OrdenCompra, string NumeroSolicitud, string FechaSolicitudDesde, string FechaSolicitudHasta)
        {
            var fechaDesde = string.IsNullOrWhiteSpace(FechaSolicitudDesde) ? DateTime.Now.AddYears(-50) : DateTime.ParseExact(FechaSolicitudDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var fechaHasta = string.IsNullOrWhiteSpace(FechaSolicitudHasta) ? DateTime.Now : DateTime.ParseExact(FechaSolicitudHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            
            var iMP_DESADUANAJE = db.IMP_DESADUANAJE.Include(i => i.IMP_SOLICITUD_IMPORTACION).Where(s =>
            s.IMP_SOLICITUD_IMPORTACION.IMP_SOLICITUD.Fec_emision >= fechaDesde &&
            s.IMP_SOLICITUD_IMPORTACION.IMP_SOLICITUD.Fec_emision < fechaHasta);

            if (OrdenCompra.HasValue)
            {
                iMP_DESADUANAJE = iMP_DESADUANAJE.Where(s => s.IMP_SOLICITUD_IMPORTACION.IMP_ORDEN_COMPRA.Num_orden_compra == OrdenCompra);
            }

            if (!string.IsNullOrWhiteSpace(NumeroSolicitud))
            {
                iMP_DESADUANAJE = iMP_DESADUANAJE.Where(s => s.IMP_SOLICITUD_IMPORTACION.IMP_SOLICITUD.Numero==NumeroSolicitud);
            }

            return View(await iMP_DESADUANAJE.ToListAsync());
        }

        // GET: SolicitudDesaduanaje/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMP_DESADUANAJE iMP_DESADUANAJE = await db.IMP_DESADUANAJE.FindAsync(id);
            if (iMP_DESADUANAJE == null)
            {
                return HttpNotFound();
            }
            return View(iMP_DESADUANAJE);
        }

        // GET: SolicitudDesaduanaje/Create
        public ActionResult Create()
        {
            ViewBag.Cod_solicitud_importacion = new SelectList(db.IMP_SOLICITUD_IMPORTACION, "Cod_solicitudimportacion", "Cod_solicitudimportacion");
            return View();
        }

        // POST: SolicitudDesaduanaje/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Cod_desaduanaje,Cod_solicitud_importacion,Fec_inicio_desaduanaje,Fec_retiro_mercaderia,Cod_usu_regi,Fec_usu_regi,Cod_usu_modi,Fec_usu_modi")] IMP_DESADUANAJE iMP_DESADUANAJE)
        {
            if (ModelState.IsValid)
            {
                db.IMP_DESADUANAJE.Add(iMP_DESADUANAJE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Cod_solicitud_importacion = new SelectList(db.IMP_SOLICITUD_IMPORTACION, "Cod_solicitudimportacion", "Cod_solicitudimportacion", iMP_DESADUANAJE.Cod_solicitud_importacion);
            return View(iMP_DESADUANAJE);
        }

        // GET: SolicitudDesaduanaje/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMP_DESADUANAJE iMP_DESADUANAJE = await db.IMP_DESADUANAJE.FindAsync(id);
            if (iMP_DESADUANAJE == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cod_solicitud_importacion = new SelectList(db.IMP_SOLICITUD_IMPORTACION, "Cod_solicitudimportacion", "Cod_solicitudimportacion", iMP_DESADUANAJE.Cod_solicitud_importacion);
            return View(iMP_DESADUANAJE);
        }

        // POST: SolicitudDesaduanaje/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Cod_desaduanaje,Cod_solicitud_importacion,Fec_inicio_desaduanaje,Fec_retiro_mercaderia,Cod_usu_regi,Fec_usu_regi,Cod_usu_modi,Fec_usu_modi")] IMP_DESADUANAJE iMP_DESADUANAJE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iMP_DESADUANAJE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Cod_solicitud_importacion = new SelectList(db.IMP_SOLICITUD_IMPORTACION, "Cod_solicitudimportacion", "Cod_solicitudimportacion", iMP_DESADUANAJE.Cod_solicitud_importacion);
            return View(iMP_DESADUANAJE);
        }

        // GET: SolicitudDesaduanaje/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMP_DESADUANAJE iMP_DESADUANAJE = await db.IMP_DESADUANAJE.FindAsync(id);
            if (iMP_DESADUANAJE == null)
            {
                return HttpNotFound();
            }
            return View(iMP_DESADUANAJE);
        }

        // POST: SolicitudDesaduanaje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            IMP_DESADUANAJE iMP_DESADUANAJE = await db.IMP_DESADUANAJE.FindAsync(id);
            db.IMP_DESADUANAJE.Remove(iMP_DESADUANAJE);
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
