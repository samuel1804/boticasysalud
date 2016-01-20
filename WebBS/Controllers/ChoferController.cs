//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using WebBS.Models;

//namespace WebBS.Controllers
//{
//    public class ChoferController : Controller
//    {
//        private BDBoticasEntities db = new BDBoticasEntities();

//        // GET: /Chofer/
//        public ActionResult Index()
//        {
//            return View(db.Chofer.ToList());
//        }

//        // GET: /Chofer/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Chofer chofer = db.Chofer.Find(id);
//            if (chofer == null)
//            {
//                return HttpNotFound();
//            }
//            return View(chofer);
//        }

//        // GET: /Chofer/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: /Chofer/Create
//        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
//        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include="IdChofer,NroDoc,Nombres,Apellidos,NroTelefono,NroLicencia,CateLicencia")] Chofer chofer)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Chofer.Add(chofer);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(chofer);
//        }

//        // GET: /Chofer/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Chofer chofer = db.Chofer.Find(id);
//            if (chofer == null)
//            {
//                return HttpNotFound();
//            }
//            return View(chofer);
//        }

//        // POST: /Chofer/Edit/5
//        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
//        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include="IdChofer,NroDoc,Nombres,Apellidos,NroTelefono,NroLicencia,CateLicencia")] Chofer chofer)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(chofer).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(chofer);
//        }

//        // GET: /Chofer/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Chofer chofer = db.Chofer.Find(id);
//            if (chofer == null)
//            {
//                return HttpNotFound();
//            }
//            return View(chofer);
//        }

//        // POST: /Chofer/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Chofer chofer = db.Chofer.Find(id);
//            db.Chofer.Remove(chofer);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
