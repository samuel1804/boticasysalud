using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBS.Models;
using PagedList;

namespace WebBS.Controllers
{
    public class InformeCrediticioController : Controller
    {
        BDBoticasEntities db = new WebBS.Models.BDBoticasEntities();
        // GET: InformeCrediticio
        public ActionResult Index(int? page, string nroInformeCredito, string ruc, string estado, DateTime? fechaInformeInicio, DateTime? fechaInformeFin)
        {

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            if (nroInformeCredito != null || ruc != null || estado != null || fechaInformeInicio != null || fechaInformeFin != null)
            {

                var query = from s in db.GCC_INFORME_CREDITICIO
                            select s;

                if (fechaInformeInicio != null)
                {
                    query = query.Where(s => s.Fecha_informe >= fechaInformeInicio);
                }

                if (fechaInformeFin != null)
                {
                    query = query.Where(s => s.Fecha_informe <= fechaInformeFin);
                }

                if (!string.IsNullOrEmpty(nroInformeCredito))
                {
                    int nro = int.Parse(nroInformeCredito);
                    query = query.Where(s => s.Cod_informe_crediticio == nro);
                }

                if (!string.IsNullOrEmpty(ruc))
                {
                    query = query.Where(s => s.GCC_SOLICITUD_CREDITO.GCC_CLIENTE_JURIDICO.GCC_CLIENTE.Num_doc_identidad.Contains(ruc));
                }

                var data = query.ToList();

                foreach (var item in data)
                {

                    ICollection<GCC_EMPLEADO_INF_CREDITICIO> estados = item.GCC_EMPLEADO_INF_CREDITICIO;
                    string estado_actual = estados.Last().Estado;

                    if (estado_actual == "A")
                    {
                        estado_actual = "Aprobado";
                    }
                    else if (estado_actual == "R")
                    {
                        estado_actual = "Registrado";
                    }
                    else if (estado_actual == "M")
                    {
                        estado_actual = "Modificado";
                    }
                    else if (estado_actual == "O")
                    {
                        estado_actual = "Anulado";
                    }
                    else if (estado_actual == "Z")
                    {
                        estado_actual = "Rechazado";
                    }

                    item.Estado_actual = estado_actual;

                }

                if (!string.IsNullOrEmpty(estado))
                {
                    if (estado == "Aprobado")
                    {
                        estado = "A";
                    }
                    else if (estado == "Registrado")
                    {
                        estado = "R";
                    }
                    else if (estado == "Modificado")
                    {
                        estado = "M";
                    }
                    else if (estado == "Anulado")
                    {
                        estado = "O";
                    }
                    else if (estado == "Rechazado")
                    {
                        estado = "Z";
                    }

                    List<GCC_INFORME_CREDITICIO> listFiltered = new List<GCC_INFORME_CREDITICIO>();

                    foreach (var item in data)
                    {

                        String ultimoEstado = item.GCC_EMPLEADO_INF_CREDITICIO.Last().Estado;

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
                var solicitudesEncontradas = db.GCC_INFORME_CREDITICIO.ToList();

                foreach (var item in solicitudesEncontradas)
                {

                    ICollection<GCC_EMPLEADO_INF_CREDITICIO> estados = item.GCC_EMPLEADO_INF_CREDITICIO;
                    string estado_actual = estados.Last().Estado;

                    if (estado_actual == "A")
                    {
                        estado_actual = "Aprobado";
                    }
                    else if (estado_actual == "R")
                    {
                        estado_actual = "Registrado";
                    }
                    else if (estado_actual == "M")
                    {
                        estado_actual = "Modificado";
                    }
                    else if (estado_actual == "O")
                    {
                        estado_actual = "Anulado";
                    }
                    else if (estado_actual == "Z")
                    {
                        estado_actual = "Rechazado";
                    }

                    item.Estado_actual = estado_actual;

                }

                return View(solicitudesEncontradas.ToPagedList(pageNumber, pageSize));
            }

        }

        // GET: InformeCrediticio para Contrato
        public ActionResult Index2(int? page, string nroSolCredito, string ruc, DateTime? fechaInformeInicio, DateTime? fechaInformeFin)
        {

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var query = from s in db.GCC_INFORME_CREDITICIO
                        select s;

            if (fechaInformeInicio != null)
            {
                query = query.Where(s => s.GCC_SOLICITUD_CREDITO.Fec_solicitud >= fechaInformeInicio);
            }

            if (fechaInformeFin != null)
            {
                query = query.Where(s => s.GCC_SOLICITUD_CREDITO.Fec_solicitud <= fechaInformeFin);
            }

            if (!string.IsNullOrEmpty(nroSolCredito))
            {
                query = query.Where(s => s.GCC_SOLICITUD_CREDITO.Num_solicitud == nroSolCredito);
            }

            if (!string.IsNullOrEmpty(ruc))
            {
                query = query.Where(s => s.GCC_SOLICITUD_CREDITO.GCC_CLIENTE_JURIDICO.GCC_CLIENTE.Num_doc_identidad.Contains(ruc));
            }

            var data = query.ToList();

            foreach (var item in data)
            {

                ICollection<GCC_EMPLEADO_INF_CREDITICIO> estados = item.GCC_EMPLEADO_INF_CREDITICIO;
                string estado_actual = estados.Last().Estado;

                if (estado_actual == "A")
                {
                    estado_actual = "Aprobado";
                }
                else if (estado_actual == "R")
                {
                    estado_actual = "Registrado";
                }
                else if (estado_actual == "M")
                {
                    estado_actual = "Modificado";
                }
                else if (estado_actual == "O")
                {
                    estado_actual = "Anulado";
                }
                else if (estado_actual == "Z")
                {
                    estado_actual = "Rechazado";
                }
                else if (estado_actual == "G")
                {
                    estado_actual = "Generado";
                }

                item.Estado_actual = estado_actual;

            }

            List<GCC_INFORME_CREDITICIO> listFiltered = new List<GCC_INFORME_CREDITICIO>();

            foreach (var item in data)
            {

                String ultimoEstado = item.GCC_EMPLEADO_INF_CREDITICIO.Last().Estado;

                if (ultimoEstado == "A"  || ultimoEstado == "G")
                {
                    listFiltered.Add(item);
                }

            }

            data = listFiltered;

            return View(data.ToPagedList(pageNumber, pageSize));

        }

        // GET: InformeCrediticio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult BuscarCliente(GCC_INFORME_CREDITICIO informeCrediticio)
        {
            if (informeCrediticio.GCC_SOLICITUD_CREDITO != null)
            {
                // TODO: Add insert logic here
                List<GCC_SOLICITUD_CREDITO> solicitudes = db.GCC_SOLICITUD_CREDITO.Where(p => p.GCC_CLIENTE_JURIDICO.GCC_CLIENTE.Num_doc_identidad ==
                    informeCrediticio.GCC_SOLICITUD_CREDITO.GCC_CLIENTE_JURIDICO.GCC_CLIENTE.Num_doc_identidad).ToList();

                GCC_SOLICITUD_CREDITO solicitudEncontrada = null;
                foreach (var solicitud in solicitudes)
                {

                    ICollection<GCC_EMPLEADO_SOL_CREDITO> estados = solicitud.GCC_EMPLEADO_SOL_CREDITO;
                    string estado_actual = estados.Last().Estado;

                    if (estado_actual == "R" || estado_actual == "M")
                    {
                        solicitudEncontrada = solicitud;
                        break;
                    }
                }

                if (solicitudEncontrada != null)
                {
                    informeCrediticio.GCC_SOLICITUD_CREDITO = solicitudEncontrada;
                }
                else
                {
                    solicitudEncontrada = new GCC_SOLICITUD_CREDITO();
                    solicitudEncontrada.Cod_solicitud_credito = -1;
                    informeCrediticio.GCC_SOLICITUD_CREDITO = solicitudEncontrada;
                }

                return RedirectToAction("Create", solicitudEncontrada);
            } else {
            return View();
            }
        } 

        // GET: InformeCrediticio/Create
        public ActionResult Create(GCC_SOLICITUD_CREDITO solicitud)
        {
            GCC_INFORME_CREDITICIO informe = new GCC_INFORME_CREDITICIO();
            
            if(solicitud.Cod_solicitud_credito==-1){
            
                ModelState.AddModelError("GCC_SOLICITUD_CREDITO.GCC_CLIENTE_JURIDICO.GCC_CLIENTE.Num_doc_identidad", "El cliente selecionado no presenta solicitud");
            } else if(solicitud.Cod_solicitud_credito!=0){
                solicitud.GCC_CLIENTE_JURIDICO = db.GCC_CLIENTE_JURIDICO.Where(b => b.Cod_cliente == solicitud.Cod_cliente).Single();
                informe.GCC_SOLICITUD_CREDITO = solicitud;
            }

            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Alto", Value = "A", Selected = true });
            items.Add(new SelectListItem { Text = "Media", Value = "M" });
            items.Add(new SelectListItem { Text = "Baja", Value = "B"});
            //items.Add(new SelectListItem { Text = "Baja", Value = "b", Selected = true });
            ViewBag.RiesgoSelection = items;
            return View(informe);
            
        }

        // POST: InformeCrediticio/Create
        [HttpPost, ActionName("Create")]
        public ActionResult Create2(GCC_INFORME_CREDITICIO informeCrediticio)
        {
            try
            {
                

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: InformeCrediticio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InformeCrediticio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        

        // GET: InformeCrediticio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InformeCrediticio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: InformeCrediticio/Delete/5
        public ActionResult GenerarContrato(int id)
        {
            return View(db.GCC_INFORME_CREDITICIO.Where(b => b.Cod_informe_crediticio == id).Single());
        }

        // POST: InformeCrediticio/Delete/5
        [HttpPost]
        public ActionResult GenerarContrato(GCC_INFORME_CREDITICIO gccInf)
        {
            try
            {

                GCC_EMPLEADO_SOL_CREDITO gccEstSol = new GCC_EMPLEADO_SOL_CREDITO();
                gccEstSol.Cod_solicitud_credito = gccInf.Cod_solicitud_credito;
                gccEstSol.Cod_empleado = 1;
                gccEstSol.Fec_registro = DateTime.Now;
                gccEstSol.Estado = "G";
                gccEstSol.Cod_usu_regi = 1;
                gccEstSol.Fec_usu_regi = DateTime.Now;
                db.GCC_EMPLEADO_SOL_CREDITO.Add(gccEstSol);
                db.SaveChanges();

                GCC_EMPLEADO_INF_CREDITICIO gccEstInf = new GCC_EMPLEADO_INF_CREDITICIO();
                gccEstInf.Cod_informe_crediticio = gccInf.Cod_informe_crediticio;
                gccEstInf.Cod_empleado = 1;
                gccEstInf.Fec_registro = DateTime.Now;
                gccEstInf.Estado = "G";
                gccEstInf.Cod_usu_regi = 1;
                gccEstInf.Fec_usu_regi = DateTime.Now;
                db.GCC_EMPLEADO_INF_CREDITICIO.Add(gccEstInf);
                db.SaveChanges();

                GCC_CONTRATO_CREDITO gccCont = new GCC_CONTRATO_CREDITO();
                gccCont.Cod_solicitud_credito = gccInf.Cod_solicitud_credito;
                gccCont.Fec_inicio = DateTime.Now;
                gccCont.Fec_renovacion = DateTime.Today.Date.AddYears(1);
                gccCont.Cod_usu_regi = 1;
                gccCont.Fec_usu_regi = DateTime.Now;
                db.GCC_CONTRATO_CREDITO.Add(gccCont);
                db.SaveChanges();

                GCC_CUENTA_CLIENTE gccCta = new GCC_CUENTA_CLIENTE();
                gccCta.Cod_contrato_credito = gccCont.Cod_contrato_credito;
                gccCta.Num_cuenta = "00001";
                gccCta.Linea_credito = gccInf.Monto_linea_credito_aprob;
                gccCta.Linea_disponible = gccInf.Monto_linea_credito_aprob;
                gccCta.Estado_cuenta = "A";
                gccCta.Cod_usu_regi = 1;
                gccCta.Fec_usu_regi = DateTime.Now;
                db.GCC_CUENTA_CLIENTE.Add(gccCta);
                db.SaveChanges();

                return RedirectToAction("Index2");
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                System.Console.WriteLine(ex.Message);
                return View();
            }
        }
    }
}
