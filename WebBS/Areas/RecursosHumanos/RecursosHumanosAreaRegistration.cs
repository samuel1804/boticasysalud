using System.Web.Mvc;

namespace WebBS.Areas.RecursosHumanos
{
    public class RecursosHumanosAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "RecursosHumanos";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "RecursosHumanos_default",
                "RecursosHumanos/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}