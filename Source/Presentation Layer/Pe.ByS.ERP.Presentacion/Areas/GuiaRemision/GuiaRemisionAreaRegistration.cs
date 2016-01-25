using System.Web.Mvc;

namespace Pe.ByS.ERP.Presentacion.Areas.GuiaRemision
{
    public class GuiaRemisionAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GuiaRemision";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GuiaRemision_default",
                "GuiaRemision/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
