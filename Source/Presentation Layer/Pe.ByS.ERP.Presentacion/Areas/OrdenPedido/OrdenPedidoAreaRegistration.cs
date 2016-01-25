using System.Web.Mvc;

namespace Pe.ByS.ERP.Presentacion.Areas.OrdenPedido
{
    public class OrdenPedidoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "OrdenPedido";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "OrdenPedido_default",
                "OrdenPedido/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}