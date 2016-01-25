using System.Web.Mvc;

namespace Pe.ByS.ERP.Presentacion.Areas.GestionPermiso
{
    public class GestionPermisoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GestionPermiso";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GestionPermiso_default",
                "GestionPermiso/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
