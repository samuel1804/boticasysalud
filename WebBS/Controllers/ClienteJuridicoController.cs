using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBS.Models;
using PagedList;

namespace WebBS.Controllers
{
    public class ClienteJuridicoController : Controller
    {

        BDBoticasEntities db = new WebBS.Models.BDBoticasEntities();

        //
        // GET: /ClienteJuridico/
        public ActionResult Index(string estado, string razonSocial, string ruc, string sortOrder, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.RUCSortParm = String.IsNullOrEmpty(sortOrder) ? "Num_doc_identidad" : "";
            ViewBag.RazonSocialSortParm = sortOrder == "razonSocial" ? "razonSocial_desc" : "razonSocial";
            
            var clientes = from s in db.GCC_CLIENTE
                           select s;            

            int pageSize = 10;
            int pageNumber = (page ?? 1);                
                
            if (!string.IsNullOrEmpty(ruc))
            {
                clientes = clientes.Where(b => b.Num_doc_identidad.Contains(ruc));
            }

            if (!string.IsNullOrEmpty(razonSocial))
            {
                clientes = clientes.Where(b => b.GCC_CLIENTE_JURIDICO.Razon_social.Contains(razonSocial));
            }
                
            if (!string.IsNullOrEmpty(estado))
            {
                clientes = clientes.Where(b => b.GCC_CLIENTE_JURIDICO.GCC_CLIENTE.Estado==estado);
            }
                
            

            switch (sortOrder)
            {
                case "razonSocial":
                    clientes = clientes.OrderByDescending(s => s.GCC_CLIENTE_JURIDICO.Razon_social);
                    break;
                case "razonSocial_desc":
                    clientes = clientes.OrderBy(s => s.GCC_CLIENTE_JURIDICO.Razon_social);
                    break;
                case "Num_doc_identidad":
                    clientes = clientes.OrderByDescending(s => s.Num_doc_identidad);
                    break;
                default:
                    clientes = clientes.OrderBy(s => s.Num_doc_identidad);
                    break;
            }
            var clientesEncontrados = clientes.ToList();

            return View(clientesEncontrados.ToPagedList(pageNumber, pageSize));
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
                //validacion de ruc
                List<GCC_CLIENTE> clienteEncontrado = db.GCC_CLIENTE.Where(b => b.Num_doc_identidad.Contains(cliente.Num_doc_identidad)).ToList();

                if (clienteEncontrado != null && clienteEncontrado.Count!=0)
                {
                    ModelState.AddModelError("Num_doc_identidad", "RUC ya esta registrado");
                    return View();
                }

                cliente.Tipo_doc_identidad = "RUC";
                cliente.GCC_CLIENTE_JURIDICO.Fec_usu_regi = DateTime.Now;
                cliente.GCC_CLIENTE_JURIDICO.Cod_cliente = 1;
                cliente.GCC_CLIENTE_JURIDICO.Cod_usu_regi = 1;
                cliente.GCC_CLIENTE_JURIDICO.GCC_CLIENTE = cliente;
                cliente.Estado = "A";
                cliente.Correo = cliente.Correo.ToLower();
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
                List<GCC_CLIENTE> clienteEncontrado = db.GCC_CLIENTE.Where(b => b.Num_doc_identidad.Contains(cliente.Num_doc_identidad) && b.
                    Cod_cliente != cliente.Cod_cliente).ToList();

                if (clienteEncontrado != null && clienteEncontrado.Count != 0)
                {
                    ModelState.AddModelError("Num_doc_identidad", "RUC ya esta registrado");
                    return View();
                }

                cliente.GCC_CLIENTE_JURIDICO.Fec_usu_modi = DateTime.Now;
                cliente.GCC_CLIENTE_JURIDICO.Fec_usu_regi = cliente.Fec_usu_regi;
                cliente.GCC_CLIENTE_JURIDICO.Cod_cliente = cliente.Cod_cliente;
                cliente.GCC_CLIENTE_JURIDICO.Cod_usu_modi = 1;
                cliente.GCC_CLIENTE_JURIDICO.Cod_usu_regi = cliente.Cod_usu_regi;
                cliente.GCC_CLIENTE_JURIDICO.GCC_CLIENTE = cliente;
                cliente.Estado = "A";
                cliente.GCC_CLIENTE_JURIDICO.Categoria = "P";
                cliente.Correo = cliente.Correo.ToLower();

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

       public ActionResult Search(string razonSocial, string ruc)
       {
           var clientes = from s in db.GCC_CLIENTE
                          select s;

           if (razonSocial != null || ruc != null)
           {

               if (razonSocial != null && ruc != null)
               {
                   clientes = clientes.Where(b =>
                       (b.GCC_CLIENTE_JURIDICO.Razon_social.Contains(razonSocial))
                      && b.Num_doc_identidad.Contains(ruc)
                      && b.Estado != "D");
               }
               else if (razonSocial == null && ruc != null)
               {
                   clientes = clientes.Where(b => b.Num_doc_identidad.Contains(ruc)
                       && b.Estado != "D");
               }
               else if (razonSocial != null && ruc == null)
               {
                   clientes = clientes.Where(b => b.GCC_CLIENTE_JURIDICO.Razon_social.Contains(razonSocial)
                       && b.Estado != "D");
               }

           }

           var result = clientes.Where(b => b.Estado != "D").ToList();
           return View(result);
        }

    }
}
