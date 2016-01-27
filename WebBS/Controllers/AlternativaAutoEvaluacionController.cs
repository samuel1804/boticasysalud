using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBS.Models;
using WebBS.DTO;

namespace WebBS.Controllers
{
    public class AlternativaAutoEvaluacionController : Controller
    {
        private BDBoticasEntities db = new BDBoticasEntities();

        // GET: /AlternativaAutoEvaluacion/
        public ActionResult Index()
        {
            return View(db.RRH_AlternativaAutoevaluacion.ToList());
        }

        // GET: /AlternativaAutoEvaluacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RRH_AlternativaAutoevaluacion rrh_alternativaautoevaluacion = db.RRH_AlternativaAutoevaluacion.Find(id);
            if (rrh_alternativaautoevaluacion == null)
            {
                return HttpNotFound();
            }
            return View(rrh_alternativaautoevaluacion);
        }

        // GET: /AlternativaAutoEvaluacion/Create
        public ActionResult Create()
        {
            ViewBag.Cod_criterio = new SelectList(db.RRH_Criterio, "Cod_criterio", "Desc_criterio");
            ViewBag.Alternativas = from a in db.RRH_AlternativaAutoevaluacion
                                   join c in db.RRH_Criterio on a.Cod_criterio equals c.Cod_criterio
                                   select new AlternativaAutoevaluacionDTO{
                                   Cod_alternativa_autoevaluacion=a.Cod_alternativa_autoevaluacion,
                                   Cod_criterio=a.Cod_criterio,
                                   Desc_criterio=c.Desc_criterio,
                                   Respuesta=a.Respuesta,
                                   Valor=a.Valor,
                                   cod_operacion=0
                                   };
            return View();
        }

        // POST: /AlternativaAutoEvaluacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Cod_alternativa_autoevaluacion,Respuesta,Valor,Fec_creacion,Cod_usu_regi,Fec_usu_regi,Cod_usu_modi,Fec_usu_modi,Cod_criterio")] RRH_AlternativaAutoevaluacion rrh_alternativaautoevaluacion)
        {
            if (ModelState.IsValid)
            {
                db.RRH_AlternativaAutoevaluacion.Add(rrh_alternativaautoevaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rrh_alternativaautoevaluacion);
        }*/


        [HttpPost]
        public JsonResult SaveOrder(List<AlternativaAutoevaluacionDTO> OrderDetails)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                foreach (var i in OrderDetails)
                    {
                        if (i.cod_operacion == 1 && i.Cod_alternativa_autoevaluacion == null) { 
                            //Insertar
                        i.Cod_alternativa_autoevaluacion = db.RRH_AlternativaAutoevaluacion.OrderByDescending(t => t.Cod_alternativa_autoevaluacion).FirstOrDefault() == null ? 1 : db.RRH_AlternativaAutoevaluacion.OrderByDescending(t => t.Cod_alternativa_autoevaluacion).FirstOrDefault().Cod_alternativa_autoevaluacion+1;
                        var Alternativa = new RRH_AlternativaAutoevaluacion()
                        {
                            Cod_alternativa_autoevaluacion = i.Cod_alternativa_autoevaluacion,
                            Cod_criterio = i.Cod_criterio,
                            Respuesta = i.Respuesta,
                            Valor = i.Valor
                        };


                        db.RRH_AlternativaAutoevaluacion.Add(Alternativa);
                        db.SaveChanges();
                }else if(i.cod_operacion==2 && i.Cod_alternativa_autoevaluacion!=null){
                    var itemToRemove = db.RRH_AlternativaAutoevaluacion.SingleOrDefault(x => x.Cod_alternativa_autoevaluacion == i.Cod_alternativa_autoevaluacion); //returns a single item.

                    if (itemToRemove != null)
                    {
                        db.RRH_AlternativaAutoevaluacion.Remove(itemToRemove);
                        db.SaveChanges();
                    }
                }


                    }
                    
                    
                    status = true;
                
            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }

        // GET: /AlternativaAutoEvaluacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RRH_AlternativaAutoevaluacion rrh_alternativaautoevaluacion = db.RRH_AlternativaAutoevaluacion.Find(id);
            if (rrh_alternativaautoevaluacion == null)
            {
                return HttpNotFound();
            }
            return View(rrh_alternativaautoevaluacion);
        }

        // POST: /AlternativaAutoEvaluacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Cod_alternativa_autoevaluacion,Respuesta,Valor,Fec_creacion,Cod_usu_regi,Fec_usu_regi,Cod_usu_modi,Fec_usu_modi,Cod_criterio")] RRH_AlternativaAutoevaluacion rrh_alternativaautoevaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rrh_alternativaautoevaluacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rrh_alternativaautoevaluacion);
        }

        // GET: /AlternativaAutoEvaluacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RRH_AlternativaAutoevaluacion rrh_alternativaautoevaluacion = db.RRH_AlternativaAutoevaluacion.Find(id);
            if (rrh_alternativaautoevaluacion == null)
            {
                return HttpNotFound();
            }
            return View(rrh_alternativaautoevaluacion);
        }

        // POST: /AlternativaAutoEvaluacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RRH_AlternativaAutoevaluacion rrh_alternativaautoevaluacion = db.RRH_AlternativaAutoevaluacion.Find(id);
            db.RRH_AlternativaAutoevaluacion.Remove(rrh_alternativaautoevaluacion);
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
