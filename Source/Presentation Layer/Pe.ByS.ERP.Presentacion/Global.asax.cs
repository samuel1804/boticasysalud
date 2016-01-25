using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Pe.ByS.ERP.CrossCutting.IoC.StructureMap;
using Pe.ByS.ERP.Domain;
using Pe.ByS.ERP.Infrastructure.Persistence;
using Pe.ByS.ERP.Infrastructure.Persistence.EntityFramework;
using Pe.ByS.ERP.Presentacion;

namespace Pe.ByS.Presentacion
{
    // Nota: para obtener instrucciones sobre cómo habilitar el modo clásico de IIS6 o IIS7, 
    // visite http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            //RouteTable.Routes.MapHubs();
            Database.SetInitializer(new ContextInitializer());
            Database.SetInitializer<DbContextBase>(null);

            PersistenceConfigurator.Configure("DefaultConnection", typeof(Usuario).Assembly, typeof(ConnectionFactory).Assembly);

            BootStrapper.ConfigureDependencies();

            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());

            log4net.Config.XmlConfigurator.Configure();
        }
    }
}