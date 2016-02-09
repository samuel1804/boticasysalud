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
using System.Net.Mail;

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
            TempData["Desaduanaje"] = db.IMP_DESADUANAJE.Find(iMP_BITACORA_EVENTO.Cod_desaduanaje);
            ViewBag.Id_desaduanaje = id;

            return View(iMP_BITACORA_EVENTO);
        }

        // GET: BitacoraEventoDesaduanaje/Create
        public ActionResult Create(int id)
        {

            TempData["Desaduanaje"] = db.IMP_DESADUANAJE.Find(id);
            ViewBag.Id_desaduanaje = id;

            var lista = db.IMP_TIPO_EVENTO.Where(t => !t.EsAutomatico.Value).ToList();
            lista.Insert(0, new IMP_TIPO_EVENTO() { Nombre = "Seleccione" });
            ViewBag.Cod_Tipo_Evento = new SelectList(lista, "Cod_tipo_evento", "Nombre");
            //ViewBag.Cod_pago_importacion = new SelectList(db.IMP_PAGO_IMPORTACION, "Cod_pago_importacion", "Cod_pago_importacion");
            return View();
        }

        public ActionResult ListarEvento(int id)
        {
            var lista = db.IMP_EVENTO.Where(e => e.Cod_tipo_evento == id).ToList();
            lista = lista.Select(i => new IMP_EVENTO
            {
                Cod_evento = i.Cod_evento,
                Nombre = i.Nombre
            }).ToList();
            return Json(new { Result = lista, IsSuccess = true });
        }

        // POST: BitacoraEventoDesaduanaje/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "Cod_bitacora_evento,Cod_desaduanaje,Descripcion,Fec_evento,Observaciones,Cod_evento,Cod_pago_importacion,Cod_usu_regi,Fec_usu_regi,Cod_usu_modi,Fec_usu_modi")] IMP_BITACORA_EVENTO iMP_BITACORA_EVENTO)
        {
            if (ModelState.IsValid)
            {
                db.IMP_BITACORA_EVENTO.Add(iMP_BITACORA_EVENTO);
                await db.SaveChangesAsync();
                try
                {
                    EnviarCorreo(iMP_BITACORA_EVENTO.Cod_evento, iMP_BITACORA_EVENTO.Cod_desaduanaje);
                }
                catch (Exception e) {
                }
                return RedirectToAction("Index", new { id = iMP_BITACORA_EVENTO.Cod_desaduanaje });
            }

            TempData["Desaduanaje"] = db.IMP_DESADUANAJE.Find(iMP_BITACORA_EVENTO.Cod_desaduanaje);
            ViewBag.Id_desaduanaje = iMP_BITACORA_EVENTO.Cod_desaduanaje;

            var lista = db.IMP_TIPO_EVENTO.Where(t => !t.EsAutomatico.Value).ToList();
            lista.Insert(0, new IMP_TIPO_EVENTO() { Nombre = "Seleccione" });
            ViewBag.Cod_Tipo_Evento = new SelectList(lista, "Cod_tipo_evento", "Nombre");
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


            TempData["Desaduanaje"] = db.IMP_DESADUANAJE.Find(iMP_BITACORA_EVENTO.Cod_desaduanaje);
            ViewBag.Id_desaduanaje = id;

            var lista = db.IMP_TIPO_EVENTO.Where(t => !t.EsAutomatico.Value).ToList();
            lista.Insert(0, new IMP_TIPO_EVENTO() { Nombre = "Seleccione" });
            ViewBag.Cod_Tipo_Evento = new SelectList(lista, "Cod_tipo_evento", "Nombre");
            var lista2 = db.IMP_EVENTO.Where(e => e.Cod_tipo_evento == iMP_BITACORA_EVENTO.IMP_EVENTO.Cod_tipo_evento).ToList();
            lista2.Insert(0, new IMP_EVENTO() { Nombre = "Seleccione" });
            ViewBag.Cod_evento = new SelectList(lista2, "Cod_evento", "Nombre", iMP_BITACORA_EVENTO.Cod_evento);

            return View(iMP_BITACORA_EVENTO);
        }

        // POST: BitacoraEventoDesaduanaje/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = "Cod_bitacora_evento,Cod_desaduanaje,Descripcion,Fec_evento,Observaciones,Cod_evento,Cod_pago_importacion,Cod_usu_regi,Fec_usu_regi,Cod_usu_modi,Fec_usu_modi")] IMP_BITACORA_EVENTO iMP_BITACORA_EVENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iMP_BITACORA_EVENTO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { id = iMP_BITACORA_EVENTO.Cod_desaduanaje });
            }

            TempData["Desaduanaje"] = db.IMP_DESADUANAJE.Find(iMP_BITACORA_EVENTO.Cod_desaduanaje);
            ViewBag.Id_desaduanaje = iMP_BITACORA_EVENTO.Cod_desaduanaje;

            var lista = db.IMP_TIPO_EVENTO.Where(t => !t.EsAutomatico.Value).ToList();
            lista.Insert(0, new IMP_TIPO_EVENTO() { Nombre = "Seleccione" });
            ViewBag.Cod_Tipo_Evento = new SelectList(lista, "Cod_tipo_evento", "Nombre");
            var lista2 = db.IMP_EVENTO.Where(e => e.Cod_tipo_evento == iMP_BITACORA_EVENTO.IMP_EVENTO.Cod_tipo_evento).ToList();
            lista2.Insert(0, new IMP_EVENTO() { Nombre = "Seleccione" });
            ViewBag.Cod_evento = new SelectList(lista2, "Cod_evento", "Nombre", iMP_BITACORA_EVENTO.Cod_evento);
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
            TempData["Desaduanaje"] = db.IMP_DESADUANAJE.Find(iMP_BITACORA_EVENTO.Cod_desaduanaje);
            ViewBag.Id_desaduanaje = id;

            return View(iMP_BITACORA_EVENTO);
        }

        // POST: BitacoraEventoDesaduanaje/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            IMP_BITACORA_EVENTO iMP_BITACORA_EVENTO = await db.IMP_BITACORA_EVENTO.FindAsync(id);
            db.IMP_BITACORA_EVENTO.Remove(iMP_BITACORA_EVENTO);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", new { id = iMP_BITACORA_EVENTO.Cod_desaduanaje });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void EnviarCorreo(int cod_Evento, int cod_Desaduanaje)
        {
            try
            {
                var alerta = db.IMP_ALERTA_EVENTO.Where(a => a.Cod_desaduanaje == cod_Desaduanaje && a.Cod_evento == cod_Evento).FirstOrDefault();

                if (alerta != null)
                {
                    var evento = db.IMP_EVENTO.Find(cod_Evento);
                    MailMessage mail = new MailMessage("emelgarejo", "emelgarejo");
                    NetworkCredential basicCredential =
        new NetworkCredential("emelgarejo", "");
                    SmtpClient client = new SmtpClient();
                    client.Port = 25;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = basicCredential;
                    client.Host = "";
                    mail.Subject = "Alerta de evento activado";
                    mail.Body = "Se ha registrado el evento :" + evento.IMP_TIPO_EVENTO.Nombre + " - " + evento.Nombre;
                    client.Send(mail);
                }

            }
            catch (Exception e)
            {

            }
        }
    }
}
