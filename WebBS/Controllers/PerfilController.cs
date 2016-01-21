/*using System;
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
    public class PerfilController : Controller
    {
        private BDBoticasEntities db = new BDBoticasEntities();

        // GET: /Perfil/
        public ActionResult Index()
        {
            var perfil = db.RRH_Perfil.Include(p => p.RRH_Puesto);
            return View(perfil.ToList());
        }

        // GET: /Perfil/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RRH_Perfil perfil = db.RRH_Perfil.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // GET: /Perfil/Create
        public ActionResult Create()
        {
            ViewBag.IdArea = new SelectList(db.RRH_Area, "IdArea", "Nombre");
            ViewBag.IdPuesto = new SelectList(db.RRH_Puesto, "IdPuesto", "Nombre");
            return View();
        }

        // POST: /Perfil/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdArea,IdPerfil,IdPuesto,Nombre,Descripcion,Competencias,Caracteristicas,SueldoIni,SueldoFin,Estado")] RRH_Perfil perfil)
        {
                 if (Request.Form["btnCancelar"] != null)
                {
                    return RedirectToAction("Index");
                }

                 ViewBag.IdArea = new SelectList(db.RRH_Area, "IdArea", "Nombre", perfil.IdArea);
                 ViewBag.IdPuesto = new SelectList(db.RRH_Puesto, "IdPuesto", "Nombre", perfil.IdPuesto);
              

            if (ModelState.IsValid)
            {   
                perfil.Cod_perfil = db.RRH_Perfil.OrderByDescending(t => t.Cod_perfil).FirstOrDefault().Cod_perfil + 1;
                perfil.Estado = 1;
                db.RRH_Perfil.Add(perfil);
                db.SaveChanges();

                TempData["notice"] = "Perfil Registrado";
              



                if (Request.Form["btnRegistrar"] != null)
                {
                    return RedirectToAction("Index");
                }
                else if (Request.Form["btnRegistrarMas"] != null)
                {
                    return RedirectToAction("Create");
                }
                else if (Request.Form["btnImprimir"] != null)
                {
                    return RedirectToAction("Create");
                }
                else {
                    return RedirectToAction("Index");
                }

            }
            else
            {

                GetPuestos(""+perfil.IdArea);
           
                return View(perfil);
            }
        }

    
        [HttpPost]
        public JsonResult  GetPuestos(string id = "")
        {
            List<RRH_Puesto> puestos = new List<RRH_Puesto>();
            puestos.Add(new RRH_Puesto() { Cod_puesto = 0, Nom_puesto = "Seleccione" });
            int ID = 0;
            if (int.TryParse(id, out ID))
            {

                puestos.AddRange(db.RRH_Puesto.Where(a => a.Cod_area == ID).ToList());
                  
             
            }
            if (Request.IsAjaxRequest())
            {
                return Json(new SelectList(puestos, "IdPuesto", "Nombre"));
            }
            else
            {
                return new JsonResult
                {
                    Data = "Not valid request",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }






        // GET: /Perfil/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RRH_Perfil perfil = db.RRH_Perfil.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPuesto = new SelectList(db.RRH_Puesto, "IdPuesto", "Nombre", perfil.Cod_puesto);
            return View(perfil);    
        }

        // POST: /Perfil/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPerfil,IdPuesto,Nombre,Descripcion,Competencias,Caracteristicas,SueldoIni,SueldoFin,Estado")] RRH_Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPuesto = new SelectList(db.RRH_Puesto, "IdPuesto", "Nombre", perfil.Cod_puesto);
            return View(perfil);
        }

        // GET: /Perfil/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RRH_Perfil perfil = db.RRH_Perfil.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // POST: /Perfil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RRH_Perfil perfil = db.RRH_Perfil.Find(id);
            db.RRH_Perfil.Remove(perfil);
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
*/