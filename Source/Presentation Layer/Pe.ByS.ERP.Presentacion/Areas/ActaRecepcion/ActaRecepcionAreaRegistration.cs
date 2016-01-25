using System.Web.Mvc;

namespace Pe.ByS.ERP.Presentacion.Areas.ActaRecepcion
{
    public class ActaRecepcionAreaRegistration:  AreaRegistration
    {

        public override string AreaName
        {
            get
            {
                return "ActaRecepcion";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ActaRecepcion_default",
                "ActaRecepcion/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }

    }
}