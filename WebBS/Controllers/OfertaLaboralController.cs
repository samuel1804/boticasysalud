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
    public class OfertaLaboralController : Controller
    {
        private BDBoticasEntities db = new BDBoticasEntities();

        // GET: /OfertaLaboral/
        public ActionResult Index()
        {
            var ofertalaboral = db.OfertaLaboral.Include(o => o.Perfil).Include(o => o.Sucursal);
            return View(ofertalaboral.ToList());
        }

        // GET: /OfertaLaboral/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfertaLaboral ofertalaboral = db.OfertaLaboral.Find(id);
            if (ofertalaboral == null)
            {
                return HttpNotFound();
            }
            return View(ofertalaboral);
        }

        // GET: /OfertaLaboral/Create
        public ActionResult Create()
        {
            ViewBag.TiempoValidez = 30;
            ViewBag.IdArea = new SelectList(db.Area, "IdArea", "Nombre");
            ViewBag.IdPuesto = new SelectList(db.Puesto, "IdPuesto", "Nombre");

            ViewBag.IdPerfil = new SelectList(db.Perfil, "IdPerfil", "Nombre");
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSurcursal", "Nombre");
            return View();
        }

        // POST: /OfertaLaboral/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IdOfertaLaboral,Titulo,IdPerfil.IdPuesto,IdPerfil,IdSucursal,FuncionesAdicionales,TiempoValidez,FechaCrea,Estado")] OfertaLaboral ofertalaboral)
        {
            if (Request.Form["btnCancelar"] != null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.IdArea = new SelectList(db.Area, "IdArea", "Nombre", ofertalaboral.IdArea);
            ViewBag.IdPuesto = new SelectList(db.Puesto, "IdPuesto", "Nombre", ofertalaboral.IdPuesto);
            ViewBag.IdPerfil = new SelectList(db.Perfil, "IdPerfil", "Nombre", ofertalaboral.IdPerfil);
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSurcursal", "Nombre", ofertalaboral.IdSucursal);


            if (ModelState.IsValid)
            {
                ofertalaboral.IdOfertaLaboral = db.OfertaLaboral.OrderByDescending(t => t.IdOfertaLaboral).FirstOrDefault().IdOfertaLaboral + 1;
                ofertalaboral.Estado = 1;
                ofertalaboral.TiempoValidez = 30;
                db.OfertaLaboral.Add(ofertalaboral);
                db.SaveChanges();

                TempData["notice"] = "Oferta Laboral Registrada";

                return RedirectToAction("Index");
            }
            else {

                GetPerfiles("" + ofertalaboral.IdPerfil);
                GetPuestos("" + ofertalaboral.IdPuesto);
                return View(ofertalaboral);
            }

          
        


            
        }

        // GET: /OfertaLaboral/Edit/5

        [HttpPost]
        public JsonResult GetPerfil(string id = "")
        {
          
        var perfil=new Perfil();
            int ID = 0;
            if (int.TryParse(id, out ID))
            {

               perfil=db.Perfil.Where(a => a.IdPerfil == ID).FirstOrDefault();


            }
            if (Request.IsAjaxRequest())
            {
                return Json(new { Caracteristicas = perfil.Caracteristicas, Descripcion = perfil.Descripcion });
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

        [HttpPost]
        public JsonResult GetPerfiles(string id = "")
        {
            List<Perfil> perfiles = new List<Perfil>();
            perfiles.Add(new Perfil() { IdPerfil = 0, Nombre = "Seleccione" });
            int ID = 0;
            if (int.TryParse(id, out ID))
            {

                perfiles.AddRange(db.Perfil.Where(a => a.IdPuesto == ID).ToList());


            }
            if (Request.IsAjaxRequest())
            {
                return Json(new SelectList(perfiles, "IdPuesto", "Nombre"));
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


        [HttpPost]
        public JsonResult GetPuestos(string id = "")
        {
            List<Puesto> puestos = new List<Puesto>();
            puestos.Add(new Puesto() { IdPuesto = 0, Nombre = "Seleccione" });
            int ID = 0;
            if (int.TryParse(id, out ID))
            {

                puestos.AddRange(db.Puesto.Where(a => a.IdArea == ID).ToList());


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



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfertaLaboral ofertalaboral = db.OfertaLaboral.Find(id);
            if (ofertalaboral == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPerfil = new SelectList(db.Perfil, "IdPerfil", "Nombre", ofertalaboral.IdPerfil);
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSurcursal", "Nombre", ofertalaboral.IdSucursal);
            return View(ofertalaboral);
        }

        // POST: /OfertaLaboral/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IdOfertaLaboral,Titulo,IdPerfil,IdSucursal,FuncionesAdicionales,TiempoValidez,FechaCrea,Estado")] OfertaLaboral ofertalaboral)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ofertalaboral).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPerfil = new SelectList(db.Perfil, "IdPerfil", "Nombre", ofertalaboral.IdPerfil);
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSurcursal", "Nombre", ofertalaboral.IdSucursal);
            return View(ofertalaboral);
        }

        // GET: /OfertaLaboral/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfertaLaboral ofertalaboral = db.OfertaLaboral.Find(id);
            if (ofertalaboral == null)
            {
                return HttpNotFound();
            }
            return View(ofertalaboral);
        }

        // POST: /OfertaLaboral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfertaLaboral ofertalaboral = db.OfertaLaboral.Find(id);
            db.OfertaLaboral.Remove(ofertalaboral);
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
