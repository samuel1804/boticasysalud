using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBS.Models;

namespace WebBS.Controllers
{
    public class CandidatoController : Controller
    {
        private BDBoticasEntities db = new BDBoticasEntities();
       public List<RRH_GradoAcademico> Grados = new List<RRH_GradoAcademico>();
        // GET: /Candidato/
        public ActionResult Index()
        {
            return View(db.RRH_Candidato.ToList());
        }

        // GET: /Candidato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RRH_Candidato rrh_candidato = db.RRH_Candidato.Find(id);
            if (rrh_candidato == null)
            {
                return HttpNotFound();
            }
            return View(rrh_candidato);
        }

        // GET: /Candidato/Create
        public ActionResult Create()
        {
            ViewBag.Cod_ofertalaboral = new SelectList(db.RRH_OfertaLaboral, "Cod_ofertalaboral", "Titulo");
            var Ga=new RRH_GradoAcademico();
            Ga.Especialidad="sa";
            Ga.CentroEstudios="centro es";
            Grados.Add(Ga);
            ViewBag.Grados = Grados;
            //ViewBag.Grados = db.RRH_GradoAcademico.ToList();
            //ViewBag.IdPuesto = new SelectList(db.Puesto, "IdPuesto", "Nombre");
            return View();
        }


        public ActionResult AdicionarGrado()
        {
            if (Request.IsAjaxRequest())
            {
                RRH_GradoAcademico cust = new RRH_GradoAcademico();
                ViewBag.IsUpdate = false;
                return View("_Grado", cust);
            }
            else
                return View();
        }


        
        public ActionResult CreateEditCandidato(RRH_GradoAcademico mCust, string Command)
        {
            // Validate the model being submitted
            if (Request.IsAjaxRequest())
            {
                if (!ModelState.IsValid)
                {

                    return PartialView("_Grado", mCust);

                }

                else if (Command == "Save")
                {


                    RRH_GradoAcademico mobjcust = new RRH_GradoAcademico();
                    mobjcust.CentroEstudios = mCust.CentroEstudios;
                    mobjcust.Especialidad = mCust.Especialidad;
                   
                    Grados.Add(mobjcust);
                    /*
                    bool check = mobjModel.CreateCustomer(mobjcust);
                    if (check)
                    {
                        TempData["Msg"] = "El Cliente ha sido registrado satisfactoriamente";
                        ModelState.Clear();
                        return RedirectToAction("WebGrid", "Home");
                    }*/
                }

                else if (Command == "Update")
                {
                    /*Customer mobjcust = new Customer();
                    mobjcust.Id = mCust.Id;
                    mobjcust.Name = mCust.Name;
                    mobjcust.Mobile = mCust.Mobile;

                    bool check = mobjModel.UpdateCustomer(mobjcust);
                    if (check)
                    {
                        TempData["Msg"] = "El Cliente ha sido actualizado satisfactoriamente";
                        ModelState.Clear();
                        return RedirectToAction("WebGrid", "Home");
                    }*/

                }
            }

           return RedirectToAction("Create");
        }

        // POST: /Candidato/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file,[Bind(Include = "Cod_candidato,Cod_ofertalaboral,Nombre,ApellidoPaterno,ApellidoMaterno,DNI,Telefono,Direccion,Foto,Fec_postulacion,Cod_usu_regi,Fec_usu_regi,Cod_usu_modi,Fec_usu_modi")] RRH_Candidato rrh_candidato)
        {

            if (Request.Form["btnCancelar"] != null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Cod_ofertalaboral = new SelectList(db.RRH_OfertaLaboral, "Cod_ofertalaboral", "Titulo", rrh_candidato.Cod_ofertalaboral);


            if (ModelState.IsValid)
            
            {
                string path=null;
                if (file != null && file.ContentLength > 0)
                {
                    // extract only the filename
                    var fileName = Path.GetFileName(file.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    file.SaveAs(path);
                }
              
                rrh_candidato.Cod_candidato = db.RRH_Candidato.OrderByDescending(t => t.Cod_candidato).FirstOrDefault().Cod_candidato + 1;
                rrh_candidato.Foto = path;
                db.RRH_Candidato.Add(rrh_candidato);
                db.SaveChanges();

                if (Request.Form["btnRegistrar"] != null)
                {
                    return RedirectToAction("Index");
                }
                else if (Request.Form["btnRegistrarMas"] != null)
                {
                    return RedirectToAction("Create");
                }
                else
                {
                    return RedirectToAction("Index");
                }

               
            }

            return View(rrh_candidato);
        }

        // GET: /Candidato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RRH_Candidato rrh_candidato = db.RRH_Candidato.Find(id);
            if (rrh_candidato == null)
            {
                return HttpNotFound();
            }
            return View(rrh_candidato);
        }

        // POST: /Candidato/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cod_candidato,Cod_ofertalaboral,Nombre,ApellidoPaterno,ApellidoMaterno,DNI,Telefono,Direccion,Foto,Fec_postulacion,Cod_usu_regi,Fec_usu_regi,Cod_usu_modi,Fec_usu_modi")] RRH_Candidato rrh_candidato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rrh_candidato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rrh_candidato);
        }

        // GET: /Candidato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RRH_Candidato rrh_candidato = db.RRH_Candidato.Find(id);
            if (rrh_candidato == null)
            {
                return HttpNotFound();
            }
            return View(rrh_candidato);
        }

        // POST: /Candidato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RRH_Candidato rrh_candidato = db.RRH_Candidato.Find(id);
            db.RRH_Candidato.Remove(rrh_candidato);
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
