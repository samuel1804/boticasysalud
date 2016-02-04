﻿using System;
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
    public class PruebaAutoevaluacionController : Controller
    {
        private BDBoticasEntities db = new BDBoticasEntities();
        
        // GET: /PruebaAutoevaluacion/
        public ActionResult Index()
        {
            var rrh_pruebaautoevaluacion = db.RRH_PruebaAutoevaluacion.Include(r => r.RRH_Empleado);
            return View(rrh_pruebaautoevaluacion.ToList());
        }

        // GET: /PruebaAutoevaluacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RRH_PruebaAutoevaluacion rrh_pruebaautoevaluacion = db.RRH_PruebaAutoevaluacion.OrderByDescending(t => t.Cod_prueba_autoevaluacion).Where(a => a.Cod_empleado == id).FirstOrDefault();
            rrh_pruebaautoevaluacion.PuntajeTotal = (from a in db.RRH_PruebaAutoevaluacion_Respuesta
                                                     join b in db.RRH_RespuestaAutoevaluacion on a.Cod_resp_autoevaluacion equals b.Cod_resp_autoevaluacion
                                                     where a.Cod_prueba_autoevaluacion==rrh_pruebaautoevaluacion.Cod_prueba_autoevaluacion
                                                     select b).Sum(t => t.Puntaje);
            
            //rrh_pruebaautoevaluacion.PuntajeTotal =  db.RRH_AlternativaEvaluacionTecnica.Where(t=>t.d)
            ViewBag.Fortalezas = (from a in db.RRH_PruebaAutoevaluacion_Respuesta
                                  join b in db.RRH_RespuestaAutoevaluacion on a.Cod_resp_autoevaluacion equals b.Cod_resp_autoevaluacion
                                  join c in db.RRH_Criterio on b.Cod_criterio equals c.Cod_criterio
                                  where a.Cod_prueba_autoevaluacion == rrh_pruebaautoevaluacion.Cod_prueba_autoevaluacion && b.Puntaje>=3
                                  select new AlternativaAutoevaluacionDTO
                                  {
                                      Desc_criterio=c.Desc_criterio,
                                      Respuesta=b.Respuesta
                                  });


            ViewBag.Debilidades = (from a in db.RRH_PruebaAutoevaluacion_Respuesta
                                  join b in db.RRH_RespuestaAutoevaluacion on a.Cod_resp_autoevaluacion equals b.Cod_resp_autoevaluacion
                                  join c in db.RRH_Criterio on b.Cod_criterio equals c.Cod_criterio
                                  where a.Cod_prueba_autoevaluacion == rrh_pruebaautoevaluacion.Cod_prueba_autoevaluacion && b.Puntaje <3
                                  select new AlternativaAutoevaluacionDTO
                                  {
                                      Desc_criterio = c.Desc_criterio,
                                      Respuesta = b.Respuesta
                                  });


            if (rrh_pruebaautoevaluacion == null)
            {
                return HttpNotFound();
            }
            return View(rrh_pruebaautoevaluacion);
        }

        // GET: /PruebaAutoevaluacion/Create
        public ActionResult Create()
        {
            if(Session["Criterios"]==null){
            Session["Criterios"]=db.RRH_Criterio.ToList();
            }
            List<RRH_Criterio> Criterios=(List<RRH_Criterio>)Session["Criterios"];
            RRH_Criterio Criterio=Criterios.Where(t=>t.completado==false).FirstOrDefault();

            if (Session["Respuestas"] == null)
            {
                Session["Respuestas"] = new List<RRH_PruebaAutoevaluacion_Respuesta>();
            }


            if (Criterios.Where(t => t.completado == false).Count() == 1) {
                ViewBag.ultimo = true;
            }


            //ViewBag.Cod_empleado = new SelectList(db.RRH_Empleado, "Cod_empleado", "Nom_empleado");
            //List<RRH_RespuestaAutoevaluacion> resp = db.RRH_RespuestaAutoevaluacion.Where(t=>t.Cod_criterio==Criterio.Cod_criterio).ToList();
            ViewBag.respuestas = db.RRH_RespuestaAutoevaluacion.Where(t => t.Cod_criterio == Criterio.Cod_criterio).ToList();
           
            return View(Criterio);
        }

        // POST: /PruebaAutoevaluacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Cod_autoevaluacion,Fec_evaluacion,VersionEvaluacion,Cod_usu_regi,Fec_usu_regi,Cod_usu_modi,Fec_usu_modi,Cod_empleado,PuntajeTotal")] RRH_PruebaAutoevaluacion rrh_pruebaautoevaluacion)
        {
            if (ModelState.IsValid)
            {
                db.RRH_PruebaAutoevaluacion.Add(rrh_pruebaautoevaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cod_empleado = new SelectList(db.RRH_Empleado, "Cod_empleado", "Nom_empleado", rrh_pruebaautoevaluacion.Cod_empleado);
            return View(rrh_pruebaautoevaluacion);
        }



        [HttpPost]
        public JsonResult SaveOrder(List<AlternativaAutoevaluacionDTO> OrderDetails)
        {
            
            int status = 0;
            if (ModelState.IsValid)
            {

                //RRH_Usuario usuario = (RRH_Usuario)Session["Usuario"];
                //RRH_PruebaAutoevaluacion pa=new RRH_PruebaAutoevaluacion();
                //pa.Cod_prueba_autoevaluacion = db.RRH_PruebaAutoevaluacion.OrderByDescending(t => t.Cod_prueba_autoevaluacion).FirstOrDefault() == null ? 1 : db.RRH_PruebaAutoevaluacion.OrderByDescending(t => t.Cod_prueba_autoevaluacion).FirstOrDefault().Cod_prueba_autoevaluacion + 1;
                //pa.Cod_empleado = usuario.Cod_Empleado;




                var Prueba = new RRH_PruebaAutoevaluacion_Respuesta()
                    {
                        //Cod_PruebaAutoevaluacion_Respuesta=db.RRH_PruebaAutoevaluacion_Respuesta.OrderByDescending(t => t.Cod_PruebaAutoevaluacion_Respuesta).FirstOrDefault() == null ? 1 : db.RRH_PruebaAutoevaluacion_Respuesta.OrderByDescending(t => t.Cod_PruebaAutoevaluacion_Respuesta).FirstOrDefault().Cod_PruebaAutoevaluacion_Respuesta + 1,
                        //Cod_prueba_autoevaluacion = pa.Cod_prueba_autoevaluacion, 
                        Cod_resp_autoevaluacion = OrderDetails[0].Cod_resp_autoevaluacion,
                        RRH_RespuestaAutoevaluacion = new RRH_RespuestaAutoevaluacion() { 
                        Puntaje=(int)OrderDetails[0].Puntaje
                        }
                    };


                   // pa.RRH_PruebaAutoevaluacion_Respuesta.Add(Prueba);
                 

               
                    List<RRH_Criterio> Criterios = (List<RRH_Criterio>)Session["Criterios"];
                    Criterios.Where(t => t.completado == false).FirstOrDefault().completado=true;
                    Session["Criterios"] = Criterios;
                
                    List<RRH_PruebaAutoevaluacion_Respuesta> respuestas = (List<RRH_PruebaAutoevaluacion_Respuesta>)Session["Respuestas"];
                    respuestas.Add(Prueba);
                    Session["Respuestas"] = respuestas;



                //Guardar Datos
                    if (Criterios.Where(t => t.completado == false).Count() == 0)
                    {
                        var pa = new RRH_PruebaAutoevaluacion();
                        pa.Cod_empleado = ((RRH_Usuario)Session["Usuario"]).Cod_Empleado;
                        pa.Cod_prueba_autoevaluacion = db.RRH_PruebaAutoevaluacion.OrderByDescending(t => t.Cod_prueba_autoevaluacion).FirstOrDefault() == null ? 1 : db.RRH_PruebaAutoevaluacion.OrderByDescending(t => t.Cod_prueba_autoevaluacion).FirstOrDefault().Cod_prueba_autoevaluacion + 1;
                        pa.Fec_evaluacion = DateTime.Now;
                        pa.PuntajeTotal = respuestas.Sum(t => t.RRH_RespuestaAutoevaluacion.Puntaje);
                        db.RRH_PruebaAutoevaluacion.Add(pa);
                        db.SaveChanges();

                        foreach (var item in respuestas)
                        {
                            var resp = new RRH_PruebaAutoevaluacion_Respuesta()
                            {
                                Cod_prueba_autoevaluacion = pa.Cod_prueba_autoevaluacion,
                                Cod_PruebaAutoevaluacion_Respuesta = db.RRH_PruebaAutoevaluacion_Respuesta.OrderByDescending(t => t.Cod_PruebaAutoevaluacion_Respuesta).FirstOrDefault() == null ? 1 : db.RRH_PruebaAutoevaluacion_Respuesta.OrderByDescending(t => t.Cod_PruebaAutoevaluacion_Respuesta).FirstOrDefault().Cod_PruebaAutoevaluacion_Respuesta + 1,
                                Cod_resp_autoevaluacion = item.Cod_resp_autoevaluacion

                            };
                            db.RRH_PruebaAutoevaluacion_Respuesta.Add(resp);
                            db.SaveChanges();
                        }

                        status = pa.Cod_prueba_autoevaluacion;
                        return new JsonResult { Data = new { status = status } };
                    }
                    else {


                        status = 1;
                        return new JsonResult { Data = new { status = status } };
                        
                    }
            }
            else
            {
                status = 3;
                return new JsonResult { Data = new { status = status } };
            }
            
        }

        // GET: /PruebaAutoevaluacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RRH_PruebaAutoevaluacion rrh_pruebaautoevaluacion = db.RRH_PruebaAutoevaluacion.Find(id);
            if (rrh_pruebaautoevaluacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cod_empleado = new SelectList(db.RRH_Empleado, "Cod_empleado", "Nom_empleado", rrh_pruebaautoevaluacion.Cod_empleado);
            return View(rrh_pruebaautoevaluacion);
        }

        // POST: /PruebaAutoevaluacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Cod_autoevaluacion,Fec_evaluacion,VersionEvaluacion,Cod_usu_regi,Fec_usu_regi,Cod_usu_modi,Fec_usu_modi,Cod_empleado,PuntajeTotal")] RRH_PruebaAutoevaluacion rrh_pruebaautoevaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rrh_pruebaautoevaluacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cod_empleado = new SelectList(db.RRH_Empleado, "Cod_empleado", "Nom_empleado", rrh_pruebaautoevaluacion.Cod_empleado);
            return View(rrh_pruebaautoevaluacion);
        }

        // GET: /PruebaAutoevaluacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RRH_PruebaAutoevaluacion rrh_pruebaautoevaluacion = db.RRH_PruebaAutoevaluacion.Find(id);
            if (rrh_pruebaautoevaluacion == null)
            {
                return HttpNotFound();
            }
            return View(rrh_pruebaautoevaluacion);
        }

        // POST: /PruebaAutoevaluacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RRH_PruebaAutoevaluacion rrh_pruebaautoevaluacion = db.RRH_PruebaAutoevaluacion.Find(id);
            db.RRH_PruebaAutoevaluacion.Remove(rrh_pruebaautoevaluacion);
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