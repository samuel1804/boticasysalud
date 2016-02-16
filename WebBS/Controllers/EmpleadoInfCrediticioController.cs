using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBS.Models;

namespace WebBS.Controllers
{
    public class EmpleadoInfCrediticioController : Controller
    {
        private BDBoticasEntities db = new BDBoticasEntities();

        // GET: EmpleadoInfCrediticio
        public ActionResult Index(string codSolicitudCredito, string ruc, DateTime? fechaSolicitudInicio, DateTime? fechaSolicitudFin)
        {

            //var gCC_EMPLEADO_INF_CREDITICIO = db.GCC_EMPLEADO_INF_CREDITICIO.Include(g => g.Estado == "R");

            var gCC_EMPLEADO_INF_CREDITICIO = from s in db.GCC_INFORME_CREDITICIO
                        select s;


            if ((!string.IsNullOrEmpty(codSolicitudCredito)) || (ruc != null && ruc != "") || fechaSolicitudInicio != null || fechaSolicitudFin != null)
            {
                if (fechaSolicitudInicio != null)
                {
                    gCC_EMPLEADO_INF_CREDITICIO = gCC_EMPLEADO_INF_CREDITICIO.Where(b => b.GCC_SOLICITUD_CREDITO.Fec_solicitud >= fechaSolicitudInicio);
                }
                if (fechaSolicitudFin != null)
                {
                    gCC_EMPLEADO_INF_CREDITICIO = gCC_EMPLEADO_INF_CREDITICIO.Where(b => b.GCC_SOLICITUD_CREDITO.Fec_solicitud <= fechaSolicitudFin);
                }
                if (!string.IsNullOrEmpty(ruc))
                {
                    gCC_EMPLEADO_INF_CREDITICIO = gCC_EMPLEADO_INF_CREDITICIO.Where(b => b.GCC_SOLICITUD_CREDITO.GCC_CLIENTE_JURIDICO.GCC_CLIENTE.Num_doc_identidad.Contains(ruc));
                }
                if (!string.IsNullOrEmpty(codSolicitudCredito))
                {
                    gCC_EMPLEADO_INF_CREDITICIO = gCC_EMPLEADO_INF_CREDITICIO.Where(b => b.GCC_SOLICITUD_CREDITO.Num_solicitud == codSolicitudCredito);
                }

            }

            var list = gCC_EMPLEADO_INF_CREDITICIO.ToList();
            List<GCC_EMPLEADO_INF_CREDITICIO> filteredList = new List<GCC_EMPLEADO_INF_CREDITICIO>();
            foreach (var item in list)
                    {

                        String ultimoEstado = item.GCC_EMPLEADO_INF_CREDITICIO.Last().Estado;

                        if (ultimoEstado == "R")
                        {
                            filteredList.Add(item.GCC_EMPLEADO_INF_CREDITICIO.Last());

                        }

                    }



            return View(filteredList.ToList());
        }

        public FileContentResult DownloadFile(int? id)
        {
            byte[] fileContent = null;

            string fileType = "";

            string file_Name = "";


            GCC_INFORME_CREDITICIO informe = db.GCC_INFORME_CREDITICIO.Find(id);
            fileContent = informe.Reporte_infocorp;
            file_Name = informe.GCC_SOLICITUD_CREDITO.Num_solicitud + "-"+informe.GCC_SOLICITUD_CREDITO.GCC_CLIENTE_JURIDICO.Razon_social+".pdf";
            fileType = "application/pdf";
            return File(fileContent, fileType, file_Name);
        }

        // GET: EmpleadoInfCrediticio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GCC_EMPLEADO_INF_CREDITICIO gCC_EMPLEADO_INF_CREDITICIO = db.GCC_EMPLEADO_INF_CREDITICIO.Find(id);
            if (gCC_EMPLEADO_INF_CREDITICIO == null)
            {
                return HttpNotFound();
            }
            return View(gCC_EMPLEADO_INF_CREDITICIO);
        }

        // GET: EmpleadoInfCrediticio/Create
        public ActionResult Create()
        {
            ViewBag.Cod_informe_crediticio = new SelectList(db.GCC_INFORME_CREDITICIO, "Cod_informe_crediticio", "Nivel_riesgo");
            ViewBag.Cod_empleado = new SelectList(db.RRH_Empleado, "Cod_empleado", "Nom_empleado");
            return View();
        }

        // POST: EmpleadoInfCrediticio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cod_registro,Cod_informe_crediticio,Cod_empleado,Fec_registro,Estado,Cod_usu_regi,Fec_usu_regi,Cod_usu_modi,Fec_usu_modi")] GCC_EMPLEADO_INF_CREDITICIO gCC_EMPLEADO_INF_CREDITICIO)
        {
            if (ModelState.IsValid)
            {
                db.GCC_EMPLEADO_INF_CREDITICIO.Add(gCC_EMPLEADO_INF_CREDITICIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cod_informe_crediticio = new SelectList(db.GCC_INFORME_CREDITICIO, "Cod_informe_crediticio", "Nivel_riesgo", gCC_EMPLEADO_INF_CREDITICIO.Cod_informe_crediticio);
            ViewBag.Cod_empleado = new SelectList(db.RRH_Empleado, "Cod_empleado", "Nom_empleado", gCC_EMPLEADO_INF_CREDITICIO.Cod_empleado);
            return View(gCC_EMPLEADO_INF_CREDITICIO);
        }

        // GET: EmpleadoInfCrediticio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GCC_EMPLEADO_INF_CREDITICIO gCC_EMPLEADO_INF_CREDITICIO = db.GCC_EMPLEADO_INF_CREDITICIO.Find(id);
            if (gCC_EMPLEADO_INF_CREDITICIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cod_informe_crediticio = new SelectList(db.GCC_INFORME_CREDITICIO, "Cod_informe_crediticio", "Nivel_riesgo", gCC_EMPLEADO_INF_CREDITICIO.Cod_informe_crediticio);
            ViewBag.Cod_empleado = new SelectList(db.RRH_Empleado, "Cod_empleado", "Nom_empleado", gCC_EMPLEADO_INF_CREDITICIO.Cod_empleado);
            return View(gCC_EMPLEADO_INF_CREDITICIO);
        }

        // POST: EmpleadoInfCrediticio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GCC_EMPLEADO_INF_CREDITICIO gCC_EMPLEADO_INF_CREDITICIO)
        {
            try
            {
                GCC_EMPLEADO_INF_CREDITICIO objEmpleadoInfCred = db.GCC_EMPLEADO_INF_CREDITICIO.Find(gCC_EMPLEADO_INF_CREDITICIO.Cod_registro);
                var inicio = objEmpleadoInfCred.GCC_INFORME_CREDITICIO.GCC_POLITICA_CREDITO.GCC_PLAN_CREDITO.Rango_inicio;
                var fin = objEmpleadoInfCred.GCC_INFORME_CREDITICIO.GCC_POLITICA_CREDITO.GCC_PLAN_CREDITO.Rango_fin;
                if (gCC_EMPLEADO_INF_CREDITICIO.GCC_INFORME_CREDITICIO.Monto_linea_credito_aprob >= inicio && gCC_EMPLEADO_INF_CREDITICIO.GCC_INFORME_CREDITICIO.Monto_linea_credito_aprob <= fin)
                {
                    GCC_EMPLEADO_SOL_CREDITO gccEstSol = new GCC_EMPLEADO_SOL_CREDITO();
                    gccEstSol.Cod_solicitud_credito = objEmpleadoInfCred.GCC_INFORME_CREDITICIO.Cod_solicitud_credito;
                    gccEstSol.Cod_empleado = 1;
                    gccEstSol.Fec_registro = DateTime.Now;
                    gccEstSol.Estado = "A";
                    gccEstSol.Cod_usu_regi = 1;
                    gccEstSol.Fec_usu_regi = DateTime.Now;
                    db.GCC_EMPLEADO_SOL_CREDITO.Add(gccEstSol);
                    db.SaveChanges();

                    GCC_EMPLEADO_INF_CREDITICIO gccEstInf = new GCC_EMPLEADO_INF_CREDITICIO();
                    gccEstInf.Cod_informe_crediticio = objEmpleadoInfCred.Cod_informe_crediticio;
                    gccEstInf.Cod_empleado = 1;
                    gccEstInf.Fec_registro = DateTime.Now;
                    gccEstInf.Estado = "A";
                    gccEstInf.Cod_usu_regi = 1;
                    gccEstInf.Fec_usu_regi = DateTime.Now;
                    db.GCC_EMPLEADO_INF_CREDITICIO.Add(gccEstInf);
                    db.SaveChanges();

                    objEmpleadoInfCred.GCC_INFORME_CREDITICIO.Monto_linea_credito_aprob = gCC_EMPLEADO_INF_CREDITICIO.GCC_INFORME_CREDITICIO.Monto_linea_credito_aprob;
                    GCC_INFORME_CREDITICIO objInformeCrediticio = objEmpleadoInfCred.GCC_INFORME_CREDITICIO;
                    objInformeCrediticio.Fec_usu_modi = DateTime.Now;
                    objInformeCrediticio.Cod_usu_modi = 1;

                    if (ModelState.IsValid)
                    {

                        db.Entry(objInformeCrediticio).State = EntityState.Modified;
                        db.SaveChanges();
                        TempData["message"] = "Actualizado Satisfactoriamente";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["message"] = "No puede registrar un monto fuera del Rango de Linea de Credito, favor de revisar";
                    return View(objEmpleadoInfCred);

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


            /* ViewBag.Cod_informe_crediticio = new SelectList(db.GCC_INFORME_CREDITICIO, "Cod_informe_crediticio", "Nivel_riesgo", gCC_EMPLEADO_INF_CREDITICIO.Cod_informe_crediticio);
             ViewBag.Cod_empleado = new SelectList(db.RRH_Empleado, "Cod_empleado", "Nom_empleado", gCC_EMPLEADO_INF_CREDITICIO.Cod_empleado);*/
            return RedirectToAction("Index");
        }

        // GET: EmpleadoInfCrediticio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GCC_EMPLEADO_INF_CREDITICIO gCC_EMPLEADO_INF_CREDITICIO = db.GCC_EMPLEADO_INF_CREDITICIO.Find(id);
            if (gCC_EMPLEADO_INF_CREDITICIO == null)
            {
                return HttpNotFound();
            }
            return View(gCC_EMPLEADO_INF_CREDITICIO);
        }

        // POST: EmpleadoInfCrediticio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GCC_EMPLEADO_INF_CREDITICIO gCC_EMPLEADO_INF_CREDITICIO = db.GCC_EMPLEADO_INF_CREDITICIO.Find(id);
            db.GCC_EMPLEADO_INF_CREDITICIO.Remove(gCC_EMPLEADO_INF_CREDITICIO);
            db.SaveChanges();
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