using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBS.Models;
using PagedList;
using System.Collections;
using System.Data.Entity;

namespace WebBS.Controllers
{
    public class SolicitudDeCreditoController : Controller
    {

        BDBoticasEntities db = new WebBS.Models.BDBoticasEntities();

        //
        // GET: /SolicitudDeCredito/
        public ActionResult Index(int? page, string nroSolicitudCredito, string ruc, string estado, DateTime? fechaSolicitudInicio, DateTime? fechaSolicitudFin)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            if (nroSolicitudCredito != null || ruc != null || estado != null || fechaSolicitudInicio != null || fechaSolicitudFin != null)
            {

                var query = from s in db.GCC_SOLICITUD_CREDITO
                            select s;

                if (fechaSolicitudInicio != null){
                    query = query.Where(s => s.Fec_solicitud >= fechaSolicitudInicio);
                }

                if (fechaSolicitudFin != null)
                {
                    query = query.Where(s => s.Fec_solicitud <= fechaSolicitudFin);
                }

                if (!string.IsNullOrEmpty(nroSolicitudCredito))
                {
                    query = query.Where(s => s.Num_solicitud.Contains(nroSolicitudCredito));
                }

                if (!string.IsNullOrEmpty(ruc))
                {
                    query = query.Where(s => s.GCC_CLIENTE_JURIDICO.GCC_CLIENTE.Num_doc_identidad.Contains(ruc));
                }

                var data = query.ToList();
               
                if (!string.IsNullOrEmpty(estado))
                {
                    
                    List<GCC_SOLICITUD_CREDITO> listFiltered = new List<GCC_SOLICITUD_CREDITO>();

                     foreach (var item in data)
                    {

                        String ultimoEstado = item.GCC_EMPLEADO_SOL_CREDITO.Last().Estado;

                        if (ultimoEstado == estado)
                        {
                            listFiltered.Add(item);

                        }

                    }

                     data = listFiltered;
                }
                
                

                return View(data.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                var solicitudesEncontradas = db.GCC_SOLICITUD_CREDITO.ToList();
                return View(solicitudesEncontradas.ToPagedList(pageNumber, pageSize));
            }
        }

        //
        // GET: /SolicitudDeCredito/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /SolicitudDeCredito/Create
        public ActionResult Create(GCC_CLIENTE_JURIDICO cliente)
        {
            GCC_SOLICITUD_CREDITO sc = new GCC_SOLICITUD_CREDITO();
            DateTime currentDate = DateTime.Now;
            string year = currentDate.Year.ToString();
            string month = currentDate.Month.ToString("D2");

            GCC_SOLICITUD_CREDITO lastSolicitudCredito = db.GCC_SOLICITUD_CREDITO.OrderByDescending(x => x.Cod_solicitud_credito).First();
            string lastNumSolicitud = lastSolicitudCredito.Num_solicitud;
            lastNumSolicitud = lastNumSolicitud.Substring(6, 4);

            int nextNumSolicitud = int.Parse(lastNumSolicitud);
            nextNumSolicitud = nextNumSolicitud + 1;
            lastNumSolicitud = nextNumSolicitud.ToString("D4");

            sc.Num_solicitud = "SC" + year.Substring(2, 2) + month + lastNumSolicitud;

            if (cliente.Cod_cliente!=0) {

                List<GCC_SOLICITUD_CREDITO> solicitudesDeCliente =  db.GCC_SOLICITUD_CREDITO.Where(b => b.Cod_cliente == cliente.Cod_cliente).ToList();

                foreach (GCC_SOLICITUD_CREDITO item in solicitudesDeCliente)
                {
                    String ultimoEstado = item.GCC_EMPLEADO_SOL_CREDITO.Last().Estado;

                    //rechazado Z o anulado O
                    if (ultimoEstado != "Z" && ultimoEstado != "O") {
                        ModelState.AddModelError("GCC_CLIENTE_JURIDICO.Razon_social", "El cliente selecionado ya tiene solicitud");
                        return View();
                    }

                }

                cliente.GCC_CLIENTE = db.GCC_CLIENTE.Where(b => b.Cod_cliente == cliente.Cod_cliente).Single();
                sc.GCC_CLIENTE_JURIDICO = cliente;

                //estado cliente

                if(sc.GCC_CLIENTE_JURIDICO.Categoria == "P"){
                    sc.Estado_cliente_str = "Cliente Nuevo";
                } else {
                    List<GCC_COMPROBANTE> comprobantes = sc.GCC_CLIENTE_JURIDICO.GCC_CLIENTE.GCC_COMPROBANTE.ToList();

                    if(comprobantes==null || comprobantes.Count==0){
                        sc.Estado_cliente_str = "Cliente Sin Historial";
                    }
                    else {
                        sc.Estado_cliente_str = "Cliente Con Historial";
                    }
                }

            }


            return View(sc);
        }

        //
        // POST: /SolicitudDeCredito/Create
        [HttpPost]
        public ActionResult Create(GCC_SOLICITUD_CREDITO solicitud)
        {
            try
            {
                // TODO: Add insert logic here
                solicitud.Cod_usu_regi = 1;
                solicitud.Fec_usu_regi = DateTime.Now;
                solicitud.GCC_CLIENTE_JURIDICO = db.GCC_CLIENTE_JURIDICO.Where(b => b.Cod_cliente == solicitud.Cod_cliente).Single();
                //solicitud.Cod_cliente = solicitud.GCC_CLIENTE_JURIDICO.Cod_cliente;

                GCC_EMPLEADO_SOL_CREDITO esc = new GCC_EMPLEADO_SOL_CREDITO();
                esc.Cod_empleado = solicitud.Cod_cliente;
                esc.Cod_solicitud_credito = solicitud.Cod_solicitud_credito;
                esc.Cod_usu_regi = 1;
                esc.Estado = "R";
                esc.Fec_usu_regi = DateTime.Now;
                esc.Fec_registro = DateTime.Now;
                esc.RRH_Empleado = db.RRH_Empleado.Where(b => b.Cod_empleado == 1).Single();
                solicitud.GCC_EMPLEADO_SOL_CREDITO.Add(esc);

                if (solicitud.Observacion == null)
                    solicitud.Observacion = "";

                if (solicitud.Estado_cliente_str == "Cliente Nuevo")
                {
                    solicitud.Estado_cliente = "N";
                }
                else if (solicitud.Estado_cliente_str == "Cliente Sin Historial")
                {
                    solicitud.Estado_cliente = "S";
                }
                else if (solicitud.Estado_cliente_str == "Cliente Con Historial")
                {
                    solicitud.Estado_cliente = "C";
                }

                db.GCC_SOLICITUD_CREDITO.Add(solicitud);                    
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            } 
        }

        //
        // GET: /SolicitudDeCredito/Edit/5
        public ActionResult Edit(int id)
        {
            
            GCC_SOLICITUD_CREDITO solicitud = db.GCC_SOLICITUD_CREDITO.Find(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }

            // cliente estado
            if (solicitud.Estado_cliente == "N")
            {
                solicitud.Estado_cliente_str = "Cliente Nuevo";
            }
            else if (solicitud.Estado_cliente == "S")
            {
                solicitud.Estado_cliente_str = "Cliente Sin Historial";
            }
            else if (solicitud.Estado_cliente == "C")
            {
                solicitud.Estado_cliente_str = "Cliente Con Historial";
            }

            return View(solicitud);
        }

        //
        // POST: /SolicitudDeCredito/Edit/5
        [HttpPost]
        public ActionResult Edit(GCC_SOLICITUD_CREDITO solicitud)
        {
            try
            {
                //rechazado Z o anulado O
                
                GCC_EMPLEADO_SOL_CREDITO vvv = db.GCC_EMPLEADO_SOL_CREDITO.Where(b => b.Cod_solicitud_credito == solicitud.Cod_solicitud_credito).ToList().Last();
                string ultimoEstado = vvv.Estado;

                if (ultimoEstado == "A" || ultimoEstado == "Z" || ultimoEstado == "O")
                {
                    ModelState.AddModelError("Num_solicitud", "No de puede editar una solicitud aprobada/anulada/rechazada");
                    return View();
                }
                // TODO: Add update logic here

                if (solicitud.Observacion == null)
                    solicitud.Observacion = "";

                db.Entry(solicitud).State = EntityState.Modified;
                db.SaveChanges();

                GCC_EMPLEADO_SOL_CREDITO esc = new GCC_EMPLEADO_SOL_CREDITO();
                esc.Cod_empleado = solicitud.Cod_cliente;
                esc.Cod_solicitud_credito = solicitud.Cod_solicitud_credito;
                esc.Cod_usu_regi = 1;
                esc.Estado = "M";
                esc.Fec_usu_regi = DateTime.Now;
                esc.Fec_registro = DateTime.Now;
                esc.RRH_Empleado = db.RRH_Empleado.Where(b => b.Cod_empleado == 1).Single();
                db.GCC_EMPLEADO_SOL_CREDITO.Add(esc);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SolicitudDeCredito/Delete/5
        public ActionResult Delete(int id)
        {
            GCC_SOLICITUD_CREDITO solicitud = db.GCC_SOLICITUD_CREDITO.Find(id);
            if (solicitud == null)
            {                
                return HttpNotFound();
            }
            return View(solicitud);
        }

        //
        // POST: /SolicitudDeCredito/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                GCC_EMPLEADO_SOL_CREDITO esc = new GCC_EMPLEADO_SOL_CREDITO();
                esc.Cod_empleado = 1;
                esc.Cod_solicitud_credito = id;
                esc.Cod_usu_regi = 1;
                esc.Estado = "O";
                esc.Fec_usu_regi = DateTime.Now;
                esc.Fec_registro = DateTime.Now;
                esc.RRH_Empleado = db.RRH_Empleado.Where(b => b.Cod_empleado == 1).Single();
                db.GCC_EMPLEADO_SOL_CREDITO.Add(esc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ViewSearchClienteJuridicoDialog()
        {
            return PartialView("_searchClienteJuridico");
        }

        public ActionResult Search(string ruc, string razonSocial)
        {
            var clientes = from s in db.GCC_CLIENTE
                           select s;

            if (razonSocial != null || ruc != null)
            {

                if (razonSocial != null && ruc != null)
                {
                    clientes = clientes.Where(b =>
                        (b.GCC_CLIENTE_JURIDICO.Razon_social.Contains(razonSocial))
                       && b.Num_doc_identidad.Contains(ruc));
                }
                else if (razonSocial == null && ruc != null)
                {
                    clientes = clientes.Where(b => b.Num_doc_identidad.Contains(ruc));
                }
                else if (razonSocial != null && ruc == null)
                {
                    clientes = clientes.Where(b => b.GCC_CLIENTE_JURIDICO.Razon_social.Contains(razonSocial));
                }

            }


            ViewBag.Clientes = clientes.ToList();
            return PartialView("_searchClienteJuridico", clientes);
        }

        public ActionResult Select(string id)
        {
            int idNum = int.Parse(id);
            var clientes = db.GCC_CLIENTE_JURIDICO.Where(b => b.Cod_cliente == idNum);

            GCC_CLIENTE_JURIDICO resultado = clientes.ToList().ElementAt(0);
            return RedirectToAction("Create", resultado);
        } 
    }
        
}
