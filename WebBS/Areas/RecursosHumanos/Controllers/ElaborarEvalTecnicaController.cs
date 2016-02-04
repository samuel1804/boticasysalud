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
    public class ElaborarEvalTecnicaController : Controller
    {
        //
        // GET: /RecursosHumanos/ElaborarEvalTecnica/
        public ActionResult Index()
        {
            return View();
        }



        public JsonResult selectElaborarEvalTecnica(string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            int totalRecords = 0;
            var totalPages = 0;
            var lstPreguntaEvaluacionTecnica = (IEnumerable<bePreguntaEvaluacionTecnica>)null;

            var action = new blPreguntaEvaluacionTecnica();
            lstPreguntaEvaluacionTecnica = action.select((page - 1) * rows + 1, (page - 1) * rows + rows, sidx, sord);

            if (lstPreguntaEvaluacionTecnica != null)
            {
                totalRecords = action.count();
                totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            }

            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = lstPreguntaEvaluacionTecnica
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult cargaComboPerfil()
        {
            blPerfil action = new blPerfil();
            var lstbeCamposResul = action.selectPerfil().ToList();
            lstbeCamposResul.Add(new bePerfil()
            {
                intCod_perfil = 0,
                strDesc_perfil = "-- Seleccione --"
            });

            IEnumerable<SelectListItem> items = from value in lstbeCamposResul.OrderBy(x => x.strDesc_perfil)
                                                select new SelectListItem()
                                                {
                                                    Text = value.strDesc_perfil.Trim(),
                                                    Value = value.intCod_perfil.ToString(),
                                                    Selected = (value.intCod_perfil.ToString().Equals("0"))
                                                };

            StringBuilder jsonLista = new StringBuilder();
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.Serialize(items, jsonLista);
            return Json(jsonLista.ToString(), "text/x-json", JsonRequestBehavior.AllowGet);
        }

        public JsonResult cargaComboCriterio()
        {
            blCriterio action = new blCriterio();
            var lstbeCamposResul = action.select().ToList();
            lstbeCamposResul.Add(new beCriterio()
            {
                intCod_criterio = 0,
                strDesc_criterio = "-- Seleccione --"
            });

            IEnumerable<SelectListItem> items = from value in lstbeCamposResul.OrderBy(x => x.strDesc_criterio)
                                                select new SelectListItem()
                                                {
                                                    Text = value.strDesc_criterio.Trim(),
                                                    Value = value.intCod_criterio.ToString(),
                                                    Selected = (value.intCod_criterio.ToString().Equals("0"))
                                                };

            StringBuilder jsonLista = new StringBuilder();
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.Serialize(items, jsonLista);
            return Json(jsonLista.ToString(), "text/x-json", JsonRequestBehavior.AllowGet);
        }

        public JsonResult cargaComboAlternativa()
        {
            blAlternativa action = new blAlternativa();
            var lstbeCamposResul = action.selectAlternativa().ToList();
            lstbeCamposResul.Add(new beAlternativa()
            {
                intCod_alternativa_evaluaciontec = 0,
                strDesc_Alternatica = "-- Seleccione --"
            });

            IEnumerable<SelectListItem> items = from value in lstbeCamposResul.OrderBy(x => x.strDesc_Alternatica)
                                                select new SelectListItem()
                                                {
                                                    Text = value.strDesc_Alternatica.Trim(),
                                                    Value = value.intCod_alternativa_evaluaciontec.ToString(),
                                                    Selected = (value.intCod_alternativa_evaluaciontec.ToString().Equals("0"))
                                                };

            StringBuilder jsonLista = new StringBuilder();
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.Serialize(items, jsonLista);
            return Json(jsonLista.ToString(), "text/x-json", JsonRequestBehavior.AllowGet);
        }

    }
}
