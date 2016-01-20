using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBS.Controllers.ALP
{
    public class ConstanciaController : Controller
    {

        public ActionResult Index()
        {
            return View("~/Views/ALP/Constancia/Index.cshtml");
        }

    }
}
