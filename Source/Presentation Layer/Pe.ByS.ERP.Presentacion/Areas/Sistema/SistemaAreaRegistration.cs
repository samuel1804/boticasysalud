using System.Web.Mvc;

namespace Pe.ByS.ERP.Presentacion.Areas.Sistema
{
    public class SistemaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Sistema";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Sistema_default",
                "Sistema/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
