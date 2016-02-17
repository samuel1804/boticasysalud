using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBS.Models;
using PagedList;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity;

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

                if (!string.IsNullOrEmpty(estado))
                {

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
                return View(solicitudesEncontradas.ToPagedList(pageNumber, pageSize));
            }

        }

        // GET: InformeCrediticio para Contrato
        public ActionResult GenerarContratoIndex(int? page, string nroSolCredito, string ruc, DateTime? fechaInformeInicio, DateTime? fechaInformeFin)
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

        public ActionResult EvaluarCliente(GCC_INFORME_CREDITICIO informe)
        {

            GCC_CLIENTE_JURIDICO cliente = db.GCC_CLIENTE_JURIDICO.Where(b => b.Razon_social == informe.GCC_SOLICITUD_CREDITO.GCC_CLIENTE_JURIDICO.Razon_social).Single();

            if (cliente.Categoria == "P")
            {
                informe.Capacidad_crediticia = "Alto";
            } else if (cliente.Categoria == "C")
            {
                List < GCC_COMPROBANTE> comprobantes = cliente.GCC_CLIENTE.GCC_COMPROBANTE.ToList();

                if(comprobantes.Count == 0){
                    informe.Capacidad_crediticia = "Alto";
                } else if (comprobantes.Count>=1 && comprobantes.Count<=9){
                    informe.Capacidad_crediticia = "Bajo";
                    informe.Capacidad_crediticia = obtenerCapacidadCrediticia(comprobantes, "Medio", "Bajo", 40);
                }
                else if (comprobantes.Count >= 10 && comprobantes.Count <= 50)
                {
                    informe.Capacidad_crediticia = obtenerCapacidadCrediticia(comprobantes, "Medio", "Bajo", 80);
                }
                else if (comprobantes.Count >= 51)
                {
                    informe.Capacidad_crediticia = obtenerCapacidadCrediticia(comprobantes, "Alto", "Medio", 80);
                }
            }
            informe.GCC_SOLICITUD_CREDITO.Capacidad_crediticia_str = informe.Capacidad_crediticia;
            return RedirectToAction("Create", informe.GCC_SOLICITUD_CREDITO);
        }
        public ActionResult DeterminarLineaCredito(GCC_INFORME_CREDITICIO informe)
        {
            string capacidadCrediticia = informe.GCC_SOLICITUD_CREDITO.Capacidad_crediticia_str.Substring(0,1);
            string nivelRiesto = informe.GCC_SOLICITUD_CREDITO.Nivel_riesgo_str;
            bool clienteNuevo = false;

            if(informe.GCC_SOLICITUD_CREDITO.GCC_CLIENTE_JURIDICO.Categoria == "P"){
                clienteNuevo = true;
            }
            GCC_POLITICA_CREDITO politica = db.GCC_POLITICA_CREDITO.Where(b => b.Capacidad_crediticia == capacidadCrediticia
                && b.Nivel_riesgo == nivelRiesto && b.Cliente_nuevo==clienteNuevo).Single();
            GCC_PLAN_CREDITO plan = politica.GCC_PLAN_CREDITO;

            informe.GCC_SOLICITUD_CREDITO.Rango_credito = "<<" + plan.Rango_inicio + " a " + plan.Rango_fin + ">>";
            informe.GCC_SOLICITUD_CREDITO.Estado_informe = politica.Estado_resultante;
            informe.GCC_SOLICITUD_CREDITO.Cantidad_credito = Convert.ToInt32(plan.Rango_inicio);//Convert.ToInt32((plan.Rango_inicio + plan.Rango_fin) / 2);
            informe.GCC_SOLICITUD_CREDITO.Codigo_politica = politica.Cod_politica_credito; 
            return RedirectToAction("Create", informe.GCC_SOLICITUD_CREDITO);
        }
        
        public string obtenerCapacidadCrediticia(List<GCC_COMPROBANTE> comprobantes, string superior, string inferior, int porcentajeAprobacion)
        {
            int totalComprobantes = comprobantes.Count;
            int totalComprobantesATiempo = 0;
            int totalPorcentajeAprobacion = (totalComprobantes * porcentajeAprobacion) / 100;

            foreach (GCC_COMPROBANTE item in comprobantes)
            {

                if (item.Fec_pago <= item.Fec_vencimiento)
                {
                    totalComprobantesATiempo = totalComprobantesATiempo + 1;
                }

            }

            if (totalComprobantesATiempo >= totalPorcentajeAprobacion)
            {
                return superior;
            }
            else
            {
                return inferior;
            }
        }
        // GET: InformeCrediticio/Create
        [HttpGet, ActionName("Create")]
        public ActionResult CreateGet(GCC_SOLICITUD_CREDITO solicitud)
        {
            GCC_INFORME_CREDITICIO informe = new GCC_INFORME_CREDITICIO();
            if (solicitud != null)
            {
                if (solicitud.Cod_solicitud_credito == -1)
                {

                    ModelState.AddModelError("GCC_SOLICITUD_CREDITO.GCC_CLIENTE_JURIDICO.GCC_CLIENTE.Num_doc_identidad", "El cliente selecionado no presenta solicitud");
                }
                else if (solicitud.Cod_cliente != 0)
                {
                    solicitud.GCC_CLIENTE_JURIDICO = db.GCC_CLIENTE_JURIDICO.Where(b => b.Cod_cliente == solicitud.Cod_cliente).Single();
                }
            }

            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Alto", Value = "A", Selected = true });
            items.Add(new SelectListItem { Text = "Media", Value = "M" });
            items.Add(new SelectListItem { Text = "Baja", Value = "B"});
            ViewBag.RiesgoSelection = items;
            informe.GCC_SOLICITUD_CREDITO = solicitud;
            return View(informe);
            
        }

        // POST: InformeCrediticio/Create
        [HttpPost, ActionName("Create")]
        public ActionResult CreatPost(GCC_INFORME_CREDITICIO informeCrediticio)
        {            

            String estadoInforme = informeCrediticio.GCC_SOLICITUD_CREDITO.Estado_informe;
            informeCrediticio.Monto_linea_credito_eval = informeCrediticio.GCC_SOLICITUD_CREDITO.Cantidad_credito;
            informeCrediticio.Monto_linea_credito_aprob = informeCrediticio.GCC_SOLICITUD_CREDITO.Cantidad_credito;
            informeCrediticio.Capacidad_crediticia = informeCrediticio.GCC_SOLICITUD_CREDITO.Capacidad_crediticia_str.Substring(0,1);
            informeCrediticio.Nivel_riesgo = informeCrediticio.GCC_SOLICITUD_CREDITO.Nivel_riesgo_str;                 
            informeCrediticio.GCC_POLITICA_CREDITO = db.GCC_POLITICA_CREDITO.Where(b => b.Cod_politica_credito == informeCrediticio.GCC_SOLICITUD_CREDITO.Codigo_politica).Single();
            informeCrediticio.Cod_politica_credito = informeCrediticio.GCC_POLITICA_CREDITO.Cod_politica_credito;
            informeCrediticio.GCC_SOLICITUD_CREDITO = db.GCC_SOLICITUD_CREDITO.Where(b => b.Cod_solicitud_credito == informeCrediticio.GCC_SOLICITUD_CREDITO.Cod_solicitud_credito).Single();
            informeCrediticio.Cod_solicitud_credito = informeCrediticio.GCC_SOLICITUD_CREDITO.Cod_solicitud_credito;
            informeCrediticio.Cod_usu_regi = 1;
            informeCrediticio.Fec_usu_regi = DateTime.Now;
            informeCrediticio.Fecha_informe = DateTime.Now;
            informeCrediticio.Fec_ultima_evaluacion = DateTime.Now;

            GCC_EMPLEADO_INF_CREDITICIO estado = new GCC_EMPLEADO_INF_CREDITICIO();
            estado.Cod_empleado = informeCrediticio.GCC_SOLICITUD_CREDITO.Cod_cliente;
            estado.Cod_informe_crediticio = informeCrediticio.Cod_informe_crediticio;
            estado.Cod_usu_regi = 1;
            estado.Estado = estadoInforme;
            estado.Fec_usu_regi = DateTime.Now;
            estado.Fec_registro = DateTime.Now;
            estado.RRH_Empleado = db.RRH_Empleado.Where(b => b.Cod_empleado == 1).Single();
            informeCrediticio.GCC_EMPLEADO_INF_CREDITICIO.Add(estado);

            if (Request.Files != null && Request.Files.Count == 1)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    var content = new byte[file.ContentLength];
                    file.InputStream.Read(content, 0, file.ContentLength);
                    informeCrediticio.Reporte_infocorp = content;

                    // the rest of your db code here
                }
            }

            if(informeCrediticio.Reporte_infocorp==null){
                List<SelectListItem> items = new List<SelectListItem>();

                items.Add(new SelectListItem { Text = "Alto", Value = "A", Selected = true });
                items.Add(new SelectListItem { Text = "Media", Value = "M" });
                items.Add(new SelectListItem { Text = "Baja", Value = "B" });
                ViewBag.RiesgoSelection = items;
                TempData["message"] = "Reporte INFOCORP es requerido";
                return View();
            }

            db.GCC_INFORME_CREDITICIO.Add(informeCrediticio);
            db.SaveChanges();

            GCC_EMPLEADO_SOL_CREDITO esc = new GCC_EMPLEADO_SOL_CREDITO();
            esc.Cod_empleado = informeCrediticio.GCC_SOLICITUD_CREDITO.Cod_cliente;
            esc.Cod_solicitud_credito = informeCrediticio.GCC_SOLICITUD_CREDITO.Cod_solicitud_credito;
            esc.Cod_usu_regi = 1;

            if (estadoInforme == "R")
            {
                esc.Estado = "C";
            }
            else
            {
                esc.Estado = "Z";
            }

            esc.Fec_usu_regi = DateTime.Now;
            esc.Fec_registro = DateTime.Now;
            esc.RRH_Empleado = db.RRH_Empleado.Where(b => b.Cod_empleado == 1).Single();
            db.GCC_EMPLEADO_SOL_CREDITO.Add(esc);
            db.SaveChanges();

            return RedirectToAction("Index");

        }        

        // GET: InformeCrediticio/Delete/5
        public ActionResult Delete(int id)
        {
            GCC_INFORME_CREDITICIO informe = db.GCC_INFORME_CREDITICIO.Where(b => b.Cod_informe_crediticio == id).Single();
            informe.GCC_SOLICITUD_CREDITO.Rango_credito = "<<" + informe.GCC_POLITICA_CREDITO.GCC_PLAN_CREDITO.Rango_inicio + " a " + informe.GCC_POLITICA_CREDITO.GCC_PLAN_CREDITO.Rango_fin + ">>";
            return View(informe);
        }

        // POST: InformeCrediticio/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                GCC_EMPLEADO_INF_CREDITICIO esc = new GCC_EMPLEADO_INF_CREDITICIO();
                esc.Cod_empleado = 1;
                esc.Cod_informe_crediticio = id;
                esc.Cod_usu_regi = 1;
                esc.Estado = "O";
                esc.Fec_usu_regi = DateTime.Now;
                esc.Fec_registro = DateTime.Now;
                esc.RRH_Empleado = db.RRH_Empleado.Where(b => b.Cod_empleado == 1).Single();
                db.GCC_EMPLEADO_INF_CREDITICIO.Add(esc);
                db.SaveChanges();

                GCC_EMPLEADO_SOL_CREDITO estSc = new GCC_EMPLEADO_SOL_CREDITO();
                estSc.Cod_empleado = 1;
                estSc.Cod_solicitud_credito = db.GCC_INFORME_CREDITICIO.Find(id).GCC_SOLICITUD_CREDITO.Cod_solicitud_credito;
                estSc.Cod_usu_regi = 1;
                estSc.Estado = "O";
                estSc.Fec_usu_regi = DateTime.Now;
                estSc.Fec_registro = DateTime.Now;
                estSc.RRH_Empleado = db.RRH_Empleado.Where(b => b.Cod_empleado == 1).Single();
                db.GCC_EMPLEADO_SOL_CREDITO.Add(estSc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            GCC_INFORME_CREDITICIO informe = db.GCC_INFORME_CREDITICIO.Where(b=> b.Cod_informe_crediticio == id).Single();
            informe.GCC_SOLICITUD_CREDITO.Rango_credito = "<<" + informe.GCC_POLITICA_CREDITO.GCC_PLAN_CREDITO.Rango_inicio + " a " + informe.GCC_POLITICA_CREDITO.GCC_PLAN_CREDITO.Rango_fin + ">>";
            return View(informe);
        }

        // GET: InformeCrediticio/Delete/5
        public ActionResult GenerarContrato(int id)
        {
            return View(db.GCC_INFORME_CREDITICIO.Where(b => b.Cod_informe_crediticio == id).Single());
        }
         [HttpPost]
        public ActionResult GenerarContrato(GCC_INFORME_CREDITICIO gccInf)
        {
            try
            {
                GCC_CLIENTE_JURIDICO gccCliente = db.GCC_CLIENTE_JURIDICO.Find(gccInf.GCC_SOLICITUD_CREDITO.GCC_CLIENTE_JURIDICO.Cod_cliente);
                gccCliente.Categoria = "C";
                db.Entry(gccCliente).State = EntityState.Modified;
                db.SaveChanges();

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

                GCC_INFORME_CREDITICIO informe = db.GCC_INFORME_CREDITICIO.Find(gccInf.Cod_informe_crediticio);

                GCC_CUENTA_CLIENTE gccCta = new GCC_CUENTA_CLIENTE();
                gccCta.Cod_contrato_credito = gccCont.Cod_contrato_credito;
                gccCta.Num_cuenta = "00001";
                gccCta.Linea_credito = informe.Monto_linea_credito_aprob;
                gccCta.Linea_disponible = informe.Monto_linea_credito_aprob;
                gccCta.Estado_cuenta = "A";
                gccCta.Cod_usu_regi = 1;
                gccCta.Fec_usu_regi = DateTime.Now;
                db.GCC_CUENTA_CLIENTE.Add(gccCta);
                db.SaveChanges();

                return RedirectToAction("GenerarContratoIndex");
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                System.Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: InformeCrediticio/Delete/5
        public ActionResult ImprimirContrato(int id)
        {
            return View(db.GCC_INFORME_CREDITICIO.Where(b => b.Cod_informe_crediticio == id).Single());
        }

        // POST: InformeCrediticio/Delete/5
        [HttpPost]
        public ActionResult ImprimirContrato(GCC_INFORME_CREDITICIO gccInf)
        {
            try
            {

                return RedirectToAction("GenerarContratoIndex");
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                System.Console.WriteLine(ex.Message);
                return View();
            }
        }
    }
}
