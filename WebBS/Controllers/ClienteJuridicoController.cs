using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBS.Models;

namespace WebBS.Controllers
{
    public class ClienteJuridicoController : Controller
    {

        BDBoticasEntities db = new WebBS.Models.BDBoticasEntities();

        //
        // GET: /ClienteJuridico/
        public ActionResult Index(string razonSocial = null, string ruc = null)
        {
            if (razonSocial != null || ruc != null)
            {
                if (razonSocial != null && ruc != null){
                    return View(db.GCC_CLIENTE.Where(b =>

                        (b.GCC_CLIENTE_JURIDICO.Razon_social.Contains(razonSocial))
                       &&
                       b.Num_doc_identidad.Contains(ruc)

                        ));
                }
                else if (razonSocial == null && ruc != null)
                {
                    return View(db.GCC_CLIENTE.Where(b => b.Num_doc_identidad.Contains(ruc)));
                }
                else if (razonSocial != null && ruc == null)
                {
                    return View(db.GCC_CLIENTE.Where(b => b.GCC_CLIENTE_JURIDICO.Razon_social.Contains(razonSocial)));
                }
                else
                {
                    return View(db.GCC_CLIENTE.ToList());
                }
                
            }
            else
            {
                return View(db.GCC_CLIENTE.ToList());
            }
        }

        //
        // GET: /ClienteJuridico/Details/5
        public ActionResult Details(int id)
        {
            GCC_CLIENTE cliente = db.GCC_CLIENTE.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // GET: /ClienteJuridico/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ClienteJuridico/Create
        [HttpPost]
        public ActionResult Create(GCC_CLIENTE cliente)
        {
            try
            {
                cliente.Tipo_doc_identidad = "RUC";
                cliente.GCC_CLIENTE_JURIDICO.Fec_usu_regi = DateTime.Now;
                cliente.GCC_CLIENTE_JURIDICO.Cod_cliente = 1;
                cliente.GCC_CLIENTE_JURIDICO.Cod_usu_regi = 1;
                cliente.GCC_CLIENTE_JURIDICO.GCC_CLIENTE = cliente;
                cliente.Estado = "A";
                cliente.GCC_CLIENTE_JURIDICO.Categoria = "P";

                cliente.Fec_usu_regi = DateTime.Now;
                cliente.Cod_usu_regi = 1;

                if (ModelState.IsValid)
                {
                    db.GCC_CLIENTE.Add(cliente);
                    db.GCC_CLIENTE_JURIDICO.Add(cliente.GCC_CLIENTE_JURIDICO);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(cliente);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ClienteJuridico/Edit/5
        public ActionResult Edit(int id)
        {
            GCC_CLIENTE cliente = db.GCC_CLIENTE.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // POST: /ClienteJuridico/Edit/5
        [HttpPost]
        public ActionResult Edit(GCC_CLIENTE cliente)
        {
            try
            {
                cliente.GCC_CLIENTE_JURIDICO.Fec_usu_modi = DateTime.Now;
                cliente.GCC_CLIENTE_JURIDICO.Fec_usu_regi = cliente.Fec_usu_regi;
                cliente.GCC_CLIENTE_JURIDICO.Cod_cliente = cliente.Cod_cliente;
                cliente.GCC_CLIENTE_JURIDICO.Cod_usu_modi = 1;
                cliente.GCC_CLIENTE_JURIDICO.Cod_usu_regi = cliente.Cod_usu_regi;
                cliente.GCC_CLIENTE_JURIDICO.GCC_CLIENTE = cliente;
                cliente.Estado = "A";
                cliente.GCC_CLIENTE_JURIDICO.Categoria = "P";

                cliente.GCC_CLIENTE_JURIDICO.GCC_CLIENTE.Cod_usu_regi = 1;
                cliente.Cod_usu_regi = 1;
                
                cliente.Tipo_doc_identidad = "RUC";
                cliente.Fec_usu_regi = cliente.Fec_usu_regi;
                cliente.Cod_usu_regi = cliente.Cod_usu_regi;

                if (ModelState.IsValid)
                {
                    db.Entry(cliente).State = EntityState.Modified;
                    db.Entry(cliente.GCC_CLIENTE_JURIDICO).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ClienteJuridico/Delete/5
        public ActionResult Delete(int id)
        {
            GCC_CLIENTE cliente = db.GCC_CLIENTE.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            if (cliente.GCC_CLIENTE_JURIDICO.Categoria != "P")
            {
                return View();
            }

            return View(cliente);
        }

        //
        // POST: /ClienteJuridico/Delete/5
       [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                GCC_CLIENTE cliente = db.GCC_CLIENTE.Find(id);
                cliente.Estado = "D";
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
