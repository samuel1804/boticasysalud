using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBS.Models;

namespace WebBS.Controllers
{
    public class MonitorearDesaduanajeController : Controller
    {
        private BDBoticasEntities db = new BDBoticasEntities();
        // GET: MonitorearDesaduanaje
        [HttpGet]
        public ActionResult Index()
        {
            var lista = db.IMP_TIPO_EVENTO.Where(t => !t.EsAutomatico.Value).ToList();
            return View(lista);
        }
        [HttpPost]
        public ActionResult Index(int? OrdenCompra)
        {
            List<IMP_TIPO_EVENTO> lista = null;
            if (OrdenCompra.HasValue)
            {
                lista = db.IMP_TIPO_EVENTO.Where(t => !t.EsAutomatico.Value).ToList();
                var oc = db.IMP_ORDEN_COMPRA.Where(o => o.Num_orden_compra == OrdenCompra).FirstOrDefault();
                var bistacora = new List<IMP_BITACORA_EVENTO>();
                if (oc != null)
                {
                    var desadunaje = oc.IMP_SOLICITUD_IMPORTACION.FirstOrDefault(s => s.IMP_DESADUANAJE != null && s.IMP_DESADUANAJE.Any()).IMP_DESADUANAJE.FirstOrDefault();
                    bistacora = desadunaje.IMP_BITACORA_EVENTO.ToList();
                    TempData["alerta"] = db.IMP_ALERTA_EVENTO.Where(a => a.Cod_desaduanaje == desadunaje.Cod_desaduanaje).ToList();
                    TempData["desaduanaje"] = desadunaje.Cod_desaduanaje;
                }
                TempData["bitacora"] = bistacora;
            }
            return View(lista);
        }

        public ActionResult GuardarAlerta(int cod_Desaduanaje, int cod_Evento, bool activo)
        {

            var alerta = db.IMP_ALERTA_EVENTO.Where(a => a.Cod_desaduanaje == cod_Desaduanaje && a.Cod_evento == cod_Evento).FirstOrDefault();
            if (!activo && alerta != null)
            {
                db.IMP_ALERTA_EVENTO.Remove(alerta);
            }
            else if (alerta == null)
            {
                alerta = new IMP_ALERTA_EVENTO()
                {
                    Cod_desaduanaje = cod_Desaduanaje,
                    Cod_evento = cod_Evento,
                    Cod_usu_regi = 1,
                    Fec_usu_regi = DateTime.Now
                };

                db.IMP_ALERTA_EVENTO.Add(alerta);
            }
            db.SaveChangesAsync();

            return Json(new { IsSuccess = true });
        }
    }
}