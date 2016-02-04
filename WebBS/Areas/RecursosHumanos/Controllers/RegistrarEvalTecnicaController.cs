using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicaBS;
using EntidadesBS;
using System.Text;
using System.Web.Script.Serialization;

namespace WebBS.Areas.RecursosHumanos.Controllers
{
    public class RegistrarEvalTecnicaController : Controller
    {
        //
        // GET: /RecursosHumanos/RegistrarEvalTecnica/
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult getDatosJefe()
        {
            blEmpleado action = new blEmpleado();
            beEmpleado obeEmpleado = action.getJefe();

            return Json(new
            {
                obeEmpleado.intCod_empleado,
                obeEmpleado.strNomCompleto,
                obeEmpleado.strDesc_Area
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getDatosEmpleado(int intCod_Empleado)
        {
            blEmpleado action = new blEmpleado();
            beEmpleado obeEmpleado = action.get(intCod_Empleado);

            return Json(new
            {
                obeEmpleado.intCod_empleado,
                obeEmpleado.strNomCompleto,
                obeEmpleado.strNom_puesto,
                obeEmpleado.intCod_perfil,
                obeEmpleado.strDesc_perfil,
                obeEmpleado.strDesc_Area
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult selectEmpleados(string sidx, string sord, int page, int rows, int intCod_Jefe)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            int totalRecords = 0;
            var totalPages = 0;
            var lstEmpleado = (IEnumerable<beEmpleado>)null;


            var strNomCompleto = Request.Params["strNomCompleto"] == null ? "" : Request.Params["strNomCompleto"].ToUpper();
            var strNom_puesto = Request.Params["strNom_puesto"] == null ? "" : Request.Params["strNom_puesto"].ToUpper();

            var action = new blEmpleado();
            lstEmpleado = action.select(intCod_Jefe, strNomCompleto, strNom_puesto);

            if (lstEmpleado != null)
            {
                totalRecords = lstEmpleado.Count();
                totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            }

            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = lstEmpleado
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getPreguntaEvalTecnica(int intCod_perfil)
        {
            var action = new blPreguntaEvaluacionTecnica();
            List<bePreguntaEvaluacionTecnica>  lstPreguntaEvaluacionTecnica = action.get(intCod_perfil);

            StringBuilder jsonLista = new StringBuilder();
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.Serialize(lstPreguntaEvaluacionTecnica, jsonLista);
            return Json(jsonLista.ToString(), "text/x-json", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Grabar(FormCollection collection)
        {
            List<string> lstSelec = collection.AllKeys.ToList();

            //for (int i = 1; i < lstSelec.Count; i++)
            //{
            //    string[] strDato = lstSelec[i].Split('|');
            //    if (strDato.Length > 1)
            //    {
            //        string strNombre = strDato[0].Trim();
            //        string strCampo = strDato[1].Trim();
            //    }
            //}
            return RedirectToAction("Index");
        }

        ////
        //// GET: /RecursosHumanos/RegistrarEvalTecnica/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        ////
        //// GET: /RecursosHumanos/RegistrarEvalTecnica/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /RecursosHumanos/RegistrarEvalTecnica/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /RecursosHumanos/RegistrarEvalTecnica/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /RecursosHumanos/RegistrarEvalTecnica/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /RecursosHumanos/RegistrarEvalTecnica/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /RecursosHumanos/RegistrarEvalTecnica/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
