using System.Web.Mvc;

namespace Pe.ByS.ERP.Presentacion.Areas.Kardex
{
    public class KardexAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Kardex";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Kardex_default",
                "Kardex/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
