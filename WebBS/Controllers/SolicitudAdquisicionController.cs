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
using WebBS.Implement;

namespace WebBS.Controllers
{
    public class SolicitudAdquisicionController : Controller
    {
        private BDBoticasEntities db = new BDBoticasEntities();

        // GET: SolicitudAdquisicion
        public async Task<ActionResult> Index()
        {
            var iMP_ADQUISICION = db.IMP_ADQUISICION.Include(i => i.IMP_SOLICITUD_IMPORTACION);
            return View(await iMP_ADQUISICION.ToListAsync());
        }


        // GET: SolicitudAdquisicion
        [HttpPost]
        public async Task<ActionResult> Index(int? OrdenCompra, string NumeroSolicitud, string FechaSolicitudDesde, string FechaSolicitudHasta)
        {
            var fechaDesde = string.IsNullOrWhiteSpace(FechaSolicitudDesde) ? DateTime.Now.AddYears(-50) : DateTime.ParseExact(FechaSolicitudDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var fechaHasta = string.IsNullOrWhiteSpace(FechaSolicitudHasta) ? DateTime.Now : DateTime.ParseExact(FechaSolicitudHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var iMP_ADQUISICION = db.IMP_ADQUISICION.Include(i => i.IMP_SOLICITUD_IMPORTACION).Where(s =>
            s.IMP_SOLICITUD_IMPORTACION.IMP_SOLICITUD.Fec_emision >= fechaDesde &&
            s.IMP_SOLICITUD_IMPORTACION.IMP_SOLICITUD.Fec_emision < fechaHasta);

            if (OrdenCompra.HasValue)
            {
                iMP_ADQUISICION = iMP_ADQUISICION.Where(s => s.IMP_SOLICITUD_IMPORTACION.IMP_ORDEN_COMPRA.Num_orden_compra == OrdenCompra);
            }

            if (!string.IsNullOrWhiteSpace(NumeroSolicitud))
            {
                iMP_ADQUISICION = iMP_ADQUISICION.Where(s => s.IMP_SOLICITUD_IMPORTACION.IMP_SOLICITUD.Numero == NumeroSolicitud);
            }
            return View(await iMP_ADQUISICION.ToListAsync());
        }

        // GET: SolicitudAdquisicion/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMP_ADQUISICION iMP_ADQUISICION = await db.IMP_ADQUISICION.FindAsync(id);
            if (iMP_ADQUISICION == null)
            {
                return HttpNotFound();
            }

            var lista = await db.IMP_PROVEEDOR.Where(p => p.Tipo == DatosConstantes.TipoProveedor.AgenteCarga).ToListAsync();

            TempData["ActividadPlanificada"] = lista.Select(a => new IMP_PROVEEDOR()
            {
                Cod_proveedor = a.Cod_proveedor,
                Razon_social = a.Razon_social,
                Ruc = a.Ruc,
                Telefono = a.Telefono
            }).ToList();

            return View(iMP_ADQUISICION);
        }

        // GET: SolicitudAdquisicion/Create
        public ActionResult Create()
        {
            ViewBag.Cod_solicitud_importacion = new SelectList(db.IMP_SOLICITUD_IMPORTACION, "Cod_solicitudimportacion", "Cod_solicitudimportacion");
            return View();
        }

        // POST: SolicitudAdquisicion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Cod_adquisicion,Fec_programada_llegada,Fec_real_llegada,Cod_solicitud_importacion,Cod_usu_regi,Fec_usu_regi,Cod_usu_modi,Fec_usu_modi")] IMP_ADQUISICION iMP_ADQUISICION)
        {
            if (ModelState.IsValid)
            {
                db.IMP_ADQUISICION.Add(iMP_ADQUISICION);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Cod_solicitud_importacion = new SelectList(db.IMP_SOLICITUD_IMPORTACION, "Cod_solicitudimportacion", "Cod_solicitudimportacion", iMP_ADQUISICION.Cod_solicitud_importacion);
            return View(iMP_ADQUISICION);
        }

        // GET: SolicitudAdquisicion/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMP_ADQUISICION iMP_ADQUISICION = await db.IMP_ADQUISICION.FindAsync(id);
            if (iMP_ADQUISICION == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cod_solicitud_importacion = new SelectList(db.IMP_SOLICITUD_IMPORTACION, "Cod_solicitudimportacion", "Cod_solicitudimportacion", iMP_ADQUISICION.Cod_solicitud_importacion);
            return View(iMP_ADQUISICION);
        }

        // POST: SolicitudAdquisicion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Cod_adquisicion,Fec_programada_llegada,Fec_real_llegada,Cod_solicitud_importacion,Cod_usu_regi,Fec_usu_regi,Cod_usu_modi,Fec_usu_modi")] IMP_ADQUISICION iMP_ADQUISICION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iMP_ADQUISICION).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Cod_solicitud_importacion = new SelectList(db.IMP_SOLICITUD_IMPORTACION, "Cod_solicitudimportacion", "Cod_solicitudimportacion", iMP_ADQUISICION.Cod_solicitud_importacion);
            return View(iMP_ADQUISICION);
        }

        // GET: SolicitudAdquisicion/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMP_ADQUISICION iMP_ADQUISICION = await db.IMP_ADQUISICION.FindAsync(id);
            if (iMP_ADQUISICION == null)
            {
                return HttpNotFound();
            }
            return View(iMP_ADQUISICION);
        }

        // POST: SolicitudAdquisicion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            IMP_ADQUISICION iMP_ADQUISICION = await db.IMP_ADQUISICION.FindAsync(id);
            db.IMP_ADQUISICION.Remove(iMP_ADQUISICION);
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

        public async Task<ActionResult> RechazarSolicitud(int codigoSolicitud, string motivo)
        {
            var entidad = await db.IMP_SOLICITUD.FindAsync(codigoSolicitud);
            entidad.Estado = DatosConstantes.EstadoSolicitud.Rechazado;
            entidad.Observaciones = motivo;
            await db.SaveChangesAsync();
            return Json(new { IsSuccess = true });
        }

        public async Task<ActionResult> GuardarAgent(int codigoSolicitud, int codigoProveedor)
        {
            var entidad = await db.IMP_SOLICITUD_IMPORTACION.FindAsync(codigoSolicitud);
            entidad.Cod_proveedor = codigoProveedor;
            entidad.IMP_SOLICITUD.Estado = DatosConstantes.EstadoSolicitud.Proceso;
            await db.SaveChangesAsync();
            return Json(new { IsSuccess = true });
        }
    }
}
