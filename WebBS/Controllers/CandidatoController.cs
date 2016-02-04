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


        public JsonResult GetFechas(string id) {
            if (!id.Equals(""))
            {
                int codoferta = Int32.Parse(id);
                var fechaini = (DateTime)db.RRH_OfertaLaboral.Where(t => t.Cod_ofertalaboral == codoferta).FirstOrDefault().Fec_creacion;
                return Json(fechaini);
            }
            else {
                return null;
            }
        }
        public ActionResult Create()
        {
            ViewBag.Cod_ofertalaboral = new SelectList(db.RRH_OfertaLaboral, "Cod_ofertalaboral", "Titulo");
            Session["Grados"] = null;
            Session["Experiencia"] = null;
            Session["Referencias"] = null;

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

        public ActionResult AdicionarExperiencia()
        {

            if (Request.IsAjaxRequest())
            {
                RRH_ExperienciaLaboral cust = new RRH_ExperienciaLaboral();
                ViewBag.IsUpdate = false;
                return View("_Experiencia", cust);
            }
            else
                return View();
        }

        public ActionResult AdicionarReferencias()
        {

            if (Request.IsAjaxRequest())
            {
                RRH_ReferenciaLaboral cust = new RRH_ReferenciaLaboral();
                ViewBag.IsUpdate = false;
                return View("_Referencias", cust);
            }
            else
                return View();
        }


        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            string path = null;
            if (file != null && file.ContentLength > 0)
            {
                // extract only the filename
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                file.SaveAs(path);
            }

            return View();
        }


      [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEditCandidato(RRH_GradoAcademico mCust, string Command)
        {
            // Validate the model being submitted
            if (Request.IsAjaxRequest())
            {

                if (!ModelState.IsValid)
                {
                    ViewBag.IsUpdate = false;
                    return View("_Grado", mCust);
                    //return PartialView("_Grado", mCust);

                }

                else
                {
                    if (Session["Grados"] == null)
                    {
                        Session["Grados"] = new List<RRH_GradoAcademico>();
                    }
                    List<RRH_GradoAcademico> Grados = (List<RRH_GradoAcademico>)Session["Grados"];
                    RRH_GradoAcademico mobjcust = new RRH_GradoAcademico();
                    mobjcust.CentroEstudios = mCust.CentroEstudios;
                    mobjcust.Titulo = mCust.Titulo;
                    mobjcust.Anio_graduacion = mCust.Anio_graduacion;

                    Grados.Add(mobjcust);
                    Session["Grados"] = Grados;

                    TempData["Msg"] = "Los Datos han sido registrados satisfactoriamente";
                    ModelState.Clear();
                    return PartialView("_GridGrado");

                    /*
                    bool check = mo bjModel.CreateCustomer(mobjcust);
                    if (check)
                    {
                        TempData["Msg"] = "El Cliente ha sido registrado satisfactoriamente";
                        ModelState.Clear();
                        return RedirectToAction("WebGrid", "Home");
                    }*/
                }

                /*else if (Command == "Update")
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
                    }

                }*/
            }
            else {
                return null;
            }
          //return  RedirectToAction("Create");
            
        }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult EliminarReferencia(string i)
      {
          return View();
      }


      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult CreateEditReferencias(RRH_ReferenciaLaboral mCust, string Command)
      {
          // Validate the model being submitted
         // if (Request.IsAjaxRequest())
          //{
              if (!ModelState.IsValid)
              {

                  ViewBag.IsUpdate = false;
                  return View("_Referencias", mCust);

              }

              else 
              {
                  if (Session["Referencias"] == null)
                  {
                      Session["Referencias"] = new List<RRH_ReferenciaLaboral>();
                  }
                  List<RRH_ReferenciaLaboral> Grados = (List<RRH_ReferenciaLaboral>)Session["Referencias"];
                  RRH_ReferenciaLaboral mobjcust = new RRH_ReferenciaLaboral();
                  mobjcust.Nom_Persona = mCust.Nom_Persona;
                  mobjcust.Nom_empresa = mCust.Nom_empresa;
                  mobjcust.Puesto = mCust.Puesto;
                  mobjcust.Telefono = mCust.Telefono;
                  mobjcust.Email = mCust.Email;
                  Grados.Add(mobjcust);
                  Session["Referencias"] = Grados;

                  TempData["Msg"] = "Los Datos han sido registrados satisfactoriamente";
                  ModelState.Clear();

                  return PartialView("_GridReferencias");
                  /*
                  bool check = mo bjModel.CreateCustomer(mobjcust);
                  if (check)
                  {
                      TempData["Msg"] = "El Cliente ha sido registrado satisfactoriamente";
                      ModelState.Clear();
                      return RedirectToAction("WebGrid", "Home");
                  }*/
              }

              /*else if (Command == "Update")
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
                  }

              }
          }*/
          //return  RedirectToAction("Create");
         
      }

        public ActionResult CreateEditExperiencia(RRH_ExperienciaLaboral mCust, string Command)
        {
            // Validate the model being submitted
           // if (Request.IsAjaxRequest())
           // {
                if (!ModelState.IsValid)
                {

                    ViewBag.IsUpdate = false;
                    return View("_Experiencia", mCust);

                }

                else  
                {
                    if (Session["Experiencia"] == null)
                    {
                        Session["Experiencia"] = new List<RRH_ExperienciaLaboral>();
                    }
                    List<RRH_ExperienciaLaboral> Grados = (List<RRH_ExperienciaLaboral>)Session["Experiencia"];
                    RRH_ExperienciaLaboral mobjcust = new RRH_ExperienciaLaboral();
                    mobjcust.LugarTrabajo = mCust.LugarTrabajo;
                    mobjcust.Nom_puesto = mCust.Nom_puesto;
                    mobjcust.Nom_area = mCust.Nom_area;
                    mobjcust.Desc_Reponsabilidades = mCust.Desc_Reponsabilidades;
                    mobjcust.Fec_Inicio_elaboral = mCust.Fec_Inicio_elaboral;
                    mobjcust.Fec_Fin_elaboral = mCust.Fec_Fin_elaboral;


                    Grados.Add(mobjcust);
                    Session["Experiencia"] = Grados;

                    TempData["Msg"] = "Los Datos han sido registrados satisfactoriamente";
                    ModelState.Clear();
                    return PartialView("_GridExperiencia");

                    /*
                    bool check = mo bjModel.CreateCustomer(mobjcust);
                    if (check)
                    {
                        TempData["Msg"] = "El Cliente ha sido registrado satisfactoriamente";
                        ModelState.Clear();
                        return RedirectToAction("WebGrid", "Home");
                    }*/
                }

                /*else if (Command == "Update")
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
                    }

                }
            }*/
            //return  RedirectToAction("Create");
           
        }


        public ActionResult _GridGrado() {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEditCustomer(RRH_GradoAcademico mCust, string Command)
        {
            // Validate the model being submitted

            if (!ModelState.IsValid)
            {

                return PartialView("_Grado", mCust);

            }

            else if (Command == "Save")
            {
                /*Customer mobjcust = new Customer();
                mobjcust.Id = mCust.Id;
                mobjcust.Name = mCust.Name;
                mobjcust.Mobile = mCust.Mobile;


                bool check = mobjModel.CreateCustomer(mobjcust);
                if (check)
                {*/
                    TempData["Msg"] = "El Cliente ha sido registrado satisfactoriamente";
                    ModelState.Clear();
                    return RedirectToAction("Create", "Candidato");
                //}
            }

            else if (Command == "Update")
            {
                /*Customer mobjcust = new Customer();
                mobjcust.Id = mCust.Id;
                mobjcust.Name = mCust.Name;
                mobjcust.Mobile = mCust.Mobile;

                bool check = mobjModel.UpdateCustomer(mobjcust);
                if (check)
                {*/
                    TempData["Msg"] = "El Cliente ha sido actualizado satisfactoriamente";
                    ModelState.Clear();
                    return RedirectToAction("Create", "Candidato");
               // }

            }

            return RedirectToAction("GridGrado");
        }


        // POST: /Candidato/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase image,[Bind(Include = "Cod_candidato,Cod_ofertalaboral,Nombre,ApellidoPaterno,ApellidoMaterno,DNI,Telefono,Direccion,Foto,Fec_postulacion,Cod_usu_regi,Fec_usu_regi,Cod_usu_modi,Fec_usu_modi")] RRH_Candidato rrh_candidato)
        {

            if (Request.Form["btnCancelar"] != null)
            {
                return RedirectToAction("Index");
            }

           // ViewBag.Cod_ofertalaboral = new SelectList(db.RRH_OfertaLaboral, "Cod_ofertalaboral", "Titulo", rrh_candidato.Cod_ofertalaboral);


            if (ModelState.IsValid)
            
            {
                string path=null;
                if (image != null && image.ContentLength > 0)
                {
                    // extract only the filename
                    var fileName = Path.GetFileName(image.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    image.SaveAs(path);
                }

                rrh_candidato.Cod_candidato = db.RRH_Candidato.OrderByDescending(t => t.Cod_candidato).FirstOrDefault() == null ? 1 : db.RRH_Candidato.OrderByDescending(t => t.Cod_candidato).FirstOrDefault().Cod_candidato + 1;
                rrh_candidato.Foto = path;
                db.RRH_Candidato.Add(rrh_candidato);
                db.SaveChanges();

                List<RRH_ReferenciaLaboral> referencias = (List<RRH_ReferenciaLaboral>)Session["Referencias"];
                List<RRH_ExperienciaLaboral> experiencia = (List<RRH_ExperienciaLaboral>)Session["Experiencia"];
                List<RRH_GradoAcademico> grados = (List<RRH_GradoAcademico>)Session["Grados"];
                if (referencias != null)
                {
                    foreach (var item in referencias)
                    {
                        var refer = new RRH_ReferenciaLaboral()
                        {
                            Cod_candidato = rrh_candidato.Cod_candidato,
                            Cod_ReferenciaLaboral = db.RRH_ReferenciaLaboral.OrderByDescending(t => t.Cod_ReferenciaLaboral).FirstOrDefault() == null ? 1 : db.RRH_ReferenciaLaboral.OrderByDescending(t => t.Cod_ReferenciaLaboral).FirstOrDefault().Cod_ReferenciaLaboral + 1,
                            Email = item.Email,
                            Nom_empresa = item.Nom_empresa,
                            Nom_Persona = item.Nom_Persona,
                            Puesto = item.Puesto,
                            Telefono = item.Telefono
                        };
                        db.RRH_ReferenciaLaboral.Add(refer);
                        db.SaveChanges();
                    }
                }
                if (experiencia != null)
                {
                    foreach (var item in experiencia)
                    {
                        var exp = new RRH_ExperienciaLaboral()
                        {
                            Cod_ExperienciaLaboral = db.RRH_ExperienciaLaboral.OrderByDescending(t => t.Cod_ExperienciaLaboral).FirstOrDefault() == null ? 1 : db.RRH_ExperienciaLaboral.OrderByDescending(t => t.Cod_ExperienciaLaboral).FirstOrDefault().Cod_ExperienciaLaboral + 1,
                            Cod_candidato = rrh_candidato.Cod_candidato,
                            Desc_Reponsabilidades = item.Desc_Reponsabilidades,
                            Fec_Inicio_elaboral = item.Fec_Inicio_elaboral,
                            Fec_Fin_elaboral = item.Fec_Fin_elaboral,
                            LugarTrabajo = item.LugarTrabajo,
                            Nom_area = item.Nom_area,
                            Nom_puesto = item.Nom_puesto,

                        };
                        db.RRH_ExperienciaLaboral.Add(exp);
                        db.SaveChanges();
                    }
                }
                if (grados != null) { 
                foreach (var item in grados) {
                    var grad = new RRH_GradoAcademico() { 
                    CentroEstudios=item.CentroEstudios,
                    Cod_candidato=rrh_candidato.Cod_candidato,
                    Cod_GradoAcademico = db.RRH_GradoAcademico.OrderByDescending(t => t.Cod_GradoAcademico).FirstOrDefault() == null ? 1 : db.RRH_GradoAcademico.OrderByDescending(t => t.Cod_GradoAcademico).FirstOrDefault().Cod_GradoAcademico + 1,
                    Anio_graduacion=item.Anio_graduacion,
                    ruta_certificado=item.ruta_certificado,
                    Titulo=item.Titulo
                    };
                    db.RRH_GradoAcademico.Add(grad);
                    db.SaveChanges();
                }
            }


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
