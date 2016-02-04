using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBS.Models;

namespace WebBS.Controllers
{
    public class LoginController : Controller
    {
        //
        private BDBoticasEntities db = new BDBoticasEntities();

        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Autenticar(RRH_Usuario rrh_usuario){

            if (ModelState.IsValid)
            {
                string username = rrh_usuario.UserName;
                string Contrasena = rrh_usuario.Contrasena;

                var model = db.RRH_Usuario.Where(p=>p.UserName == username && p.Contrasena == Contrasena).FirstOrDefault();
                if (model != null)
                {
                    Session.Clear();
                    Session["Usuario"] = model;
                    return RedirectToAction("Index", "Home");
                }
                else {
                    ViewBag.Message = "Usuario o Contraseña inválido";
                    return View("Index");
                }
                //Do something here and redirect
                
            }
            else
            {
                //It is invalid - display errors
                
                return View("Index");
            }

          
        }

	}
}