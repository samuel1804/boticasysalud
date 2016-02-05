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
using System.IO;

namespace WebBS.Controllers
{
    public class SolicitudDesaduanajeController : Controller
    {
        private BDBoticasEntities db = new BDBoticasEntities();

        // GET: SolicitudDesaduanaje
        public async Task<ActionResult> Index()
        {
            TempData["ReturnController"] = Request.Params["ReturnUrl"] ?? "SolicitudDesaduanaje";
            TempData["ReturnAction"] = Request.Params["ReturnUrl"] == null ? "Details" : "Index";

            var iMP_DESADUANAJE = db.IMP_DESADUANAJE.Include(i => i.IMP_SOLICITUD_IMPORTACION);
            return View(await iMP_DESADUANAJE.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult> Index(int? OrdenCompra, string NumeroSolicitud, string FechaSolicitudDesde, string FechaSolicitudHasta, string ReturnUrl)
        {
            TempData["ReturnController"] = ReturnUrl ?? "SolicitudDesaduanaje";
            TempData["ReturnAction"] = ReturnUrl == null ? "Details" : "Index";

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
                iMP_DESADUANAJE = iMP_DESADUANAJE.Where(s => s.IMP_SOLICITUD_IMPORTACION.IMP_SOLICITUD.Numero == NumeroSolicitud);
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

            var lista = await db.IMP_PROVEEDOR.Where(p => p.Tipo == DatosConstantes.TipoProveedor.AgenteAduana).ToListAsync();
            var listaAlmacenAduanas = await db.IMP_ALMACEN_ADUANAS.ToListAsync();
            TempData["ListaAlmacenAduanas"] = listaAlmacenAduanas.Select(p => new IMP_ALMACEN_ADUANAS()
            {
                //Cod_puerto = p.Cod_puerto,
                //Nombre = p.IMP_DISTRITO.IMP_PROVINCIA.IMP_DEPARTAMENTO.Nombre + " - " + p.Nombre
                Cod_almacen_aduanas = p.Cod_almacen_aduanas,
                Nombre = p.Nombre
            });
            TempData["Proveedor"] = lista.Select(a => new IMP_PROVEEDOR()
            {
                Cod_proveedor = a.Cod_proveedor,
                Razon_social = a.Razon_social,
                Ruc = a.Ruc,
                Telefono = a.Telefono
            }).ToList();

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


        [HttpPost]

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
            var prov = await db.IMP_PROVEEDOR.FindAsync(codigoProveedor);
            db.IMP_BITACORA_EVENTO.Add(new IMP_BITACORA_EVENTO {
                Cod_desaduanaje = entidad.IMP_DESADUANAJE.FirstOrDefault().Cod_desaduanaje,
                Cod_evento = 100,
                Fec_evento = DateTime.Now,
                Cod_usu_regi = 1,
                Fec_usu_regi = DateTime.Now,
                Descripcion = "Evento registrado de modo automático",
                Observaciones = "Agente :" + prov.Razon_social
            });

            await db.SaveChangesAsync();
            return Json(new { IsSuccess = true });
        }


        public async Task<ActionResult> CerrarSolicitud(int codigoSolicitud, int codigoPuerto, string fechaRetiro, bool finalizar)
        {
            //var entidad = await db.IMP_ADQUISICION.FindAsync(codigoSolicitud);

            var entidad = await db.IMP_DESADUANAJE.FindAsync(codigoSolicitud);


            if (!string.IsNullOrWhiteSpace(fechaRetiro))
            {
                entidad.Fec_retiro_mercaderia = DateTime.ParseExact(fechaRetiro, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            if (codigoPuerto > 0)
            {
                entidad.Cod_almacen_aduanas = codigoPuerto;
            }
            if (finalizar)
            {
                entidad.IMP_SOLICITUD_IMPORTACION.IMP_SOLICITUD.Estado = DatosConstantes.EstadoSolicitud.Cerrado;
                db.IMP_BITACORA_EVENTO.Add(new IMP_BITACORA_EVENTO
                {
                    Cod_desaduanaje = entidad.Cod_desaduanaje,
                    Cod_evento = 101,
                    Fec_evento = DateTime.Now,
                    Cod_usu_regi = 1,
                    Fec_usu_regi = DateTime.Now,
                    Descripcion = "Evento registrado de modo automático",
                    Observaciones = "No aplica"
                });
            }

            if (entidad.IMP_DAM.Any())
            {
                entidad.IMP_DAM.FirstOrDefault().Archivo = UploadFile(entidad.Cod_desaduanaje);

            }
            else
            {
                var archivo = UploadFile(entidad.Cod_desaduanaje);
                if (archivo != null)
                {
                    db.IMP_DAM.Add(new IMP_DAM()
                    {
                        Archivo = archivo,
                        Cod_desaduanaje = entidad.Cod_desaduanaje,
                        Cod_usu_regi = 1,
                        Fec_usu_regi = DateTime.Now
                    });
                }
            }


            entidad.Fec_usu_modi = DateTime.Now;
            entidad.Cod_usu_modi = 1;


            await db.SaveChangesAsync();
            return Json(new { IsSuccess = true });
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
