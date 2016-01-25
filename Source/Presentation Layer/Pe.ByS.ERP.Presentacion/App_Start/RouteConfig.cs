using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pe.ByS.ERP.Presentacion
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            //routes.Where(r => r is Route).ToList().ForEach(r =>
            //{
            //    Route router = (Route)r;
            //    if (router.DataTokens != null && router.DataTokens.ContainsKey("area"))
            //    {
            //        router.DataTokens["Namespaces"] = "Pe.ByS.Presentacion.Core.Controllers." + router.DataTokens["area"];
            //    }
            //});

            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}