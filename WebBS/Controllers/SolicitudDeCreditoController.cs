using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBS.Models;
using PagedList;

namespace WebBS.Controllers
{
    public class SolicitudDeCreditoController : Controller
    {

        BDBoticasEntities db = new WebBS.Models.BDBoticasEntities();

        //
        // GET: /SolicitudDeCredito/
        public ActionResult Index(int? page, string nroSolicitudCredito, string ruc, string estado, DateTime? fechaSolicitudInicio, DateTime? fechaSolicitudFin)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            if (nroSolicitudCredito != null || ruc != null || estado != null || fechaSolicitudInicio != null || fechaSolicitudFin != null)
            {
                var solicitudesEncontradas = from s in db.GCC_SOLICITUD_CREDITO
                                             where (

                                             (string.IsNullOrEmpty(nroSolicitudCredito) ? false : s.Num_solicitud.Contains(nroSolicitudCredito)) ||
                                             (string.IsNullOrEmpty(ruc) ? false : s.GCC_CLIENTE_JURIDICO.GCC_CLIENTE.Num_doc_identidad.Contains(ruc)) ||
                                             (fechaSolicitudInicio.HasValue ? true : s.Fec_solicitud >= fechaSolicitudInicio) ||
                                             (fechaSolicitudFin.HasValue ? true : s.Fec_solicitud <= fechaSolicitudFin)

                                             )
                                             select s;
                var data = solicitudesEncontradas.ToList();
                return View(data.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                var solicitudesEncontradas = db.GCC_SOLICITUD_CREDITO.ToList();
                return View(solicitudesEncontradas.ToPagedList(pageNumber, pageSize));
            }
        }

        //
        // GET: /SolicitudDeCredito/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /SolicitudDeCredito/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SolicitudDeCredito/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SolicitudDeCredito/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /SolicitudDeCredito/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SolicitudDeCredito/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /SolicitudDeCredito/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
