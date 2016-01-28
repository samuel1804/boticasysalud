using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBS.Models;

namespace WebBS.Controllers
{

    public class InformeCrediticioController : Controller
    {
        BDBoticasEntities db = new WebBS.Models.BDBoticasEntities();
        // GET: InformeCrediticio
        public ActionResult Index()
        {
            return View(db.GCC_INFORME_CREDITICIO.ToList());
        }

        // GET: InformeCrediticio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InformeCrediticio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InformeCrediticio/Create
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

        // GET: InformeCrediticio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InformeCrediticio/Edit/5
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

        // GET: InformeCrediticio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InformeCrediticio/Delete/5
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

        // GET: InformeCrediticio/Delete/5
        public ActionResult GenerarContrato(int id)
        {
            return View(db.GCC_INFORME_CREDITICIO.Where(b=>b.Cod_informe_crediticio==id).Single());
        }

        // POST: InformeCrediticio/Delete/5
        [HttpPost]
        public ActionResult GenerarContrato(GCC_INFORME_CREDITICIO gccInf)
        {
            try
            {

                /*gccInf.Cod_usu_modi = 1;
                gccInf.Fec_usu_modi = DateTime.Now;
                db.Entry(gccInf).State = EntityState.Modified;
                db.SaveChanges();*/

                GCC_EMPLEADO_SOL_CREDITO gccEstSol = new GCC_EMPLEADO_SOL_CREDITO();
                gccEstSol.Cod_solicitud_credito = gccInf.GCC_SOLICITUD_CREDITO.Cod_solicitud_credito;
                gccEstSol.Cod_empleado = 1;
                gccEstSol.Fec_registro = DateTime.Now;
                gccEstSol.Estado = "G";
                gccEstSol.Cod_usu_regi = 1;
                gccEstSol.Fec_usu_regi = DateTime.Now;
                db.GCC_EMPLEADO_SOL_CREDITO.Add(gccEstSol);
                db.SaveChanges();

                GCC_EMPLEADO_INF_CREDITICIO gccEstInf = new GCC_EMPLEADO_INF_CREDITICIO();
                gccEstInf.Cod_informe_crediticio = gccInf.Cod_informe_crediticio;
                gccEstInf.Cod_empleado = 1;
                gccEstInf.Fec_registro = DateTime.Now;
                gccEstInf.Estado = "G";
                gccEstInf.Cod_usu_regi = 1;
                gccEstInf.Fec_usu_regi = DateTime.Now;
                db.GCC_EMPLEADO_INF_CREDITICIO.Add(gccEstInf);
                db.SaveChanges();

                GCC_CONTRATO_CREDITO gccCont = new GCC_CONTRATO_CREDITO();
                gccCont.Cod_solicitud_credito = gccInf.GCC_SOLICITUD_CREDITO.Cod_solicitud_credito;
                gccCont.Fec_inicio = DateTime.Now;
                gccCont.Fec_renovacion = DateTime.Today.Date.AddYears(1);
                gccCont.Cod_usu_regi = 1;
                gccCont.Fec_usu_regi = DateTime.Now;
                db.GCC_CONTRATO_CREDITO.Add(gccCont);
                db.SaveChanges();

                GCC_CUENTA_CLIENTE gccCta = new GCC_CUENTA_CLIENTE();
                gccCta.Cod_contrato_credito = gccCont.Cod_contrato_credito;
                gccCta.Num_cuenta = "00001";
                gccCta.Linea_credito = gccInf.Monto_linea_credito_aprob;
                gccCta.Linea_disponible = gccInf.Monto_linea_credito_aprob;
                gccCta.Estado_cuenta = "A";
                gccCta.Cod_usu_regi = 1;
                gccCta.Fec_usu_regi = DateTime.Now;
                db.GCC_CUENTA_CLIENTE.Add(gccCta);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                System.Console.WriteLine(ex.Message);
                return View();
            }
        }
    }
}
