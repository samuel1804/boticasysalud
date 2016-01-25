using System.Data.Entity;
using System.Web.Security;
using Pe.ByS.ERP.Infrastructure.Persistence.Core;
using Pe.ByS.ERP.Infrastructure.Persistence.EntityFramework;
using Pe.ByS.ERP.Infrastructure.Repository;
using Pe.ByS.ERP.Infrastructure.SqlServer;
using Pe.ByS.ERP.Services.BusinessLogic.Inter;
using StructureMap;
using StructureMap.Web;

namespace Pe.ByS.ERP.CrossCutting.IoC.StructureMap
{
    public class BootStrapper
    {
        /// <summary>
        /// Metodo que inserta en el StructureMap el registro con las inyecciones de dependencia.
        /// </summary>
        public static void ConfigureDependencies()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.AssemblyContainingType<IUsuarioRepository>();
                    scan.AssemblyContainingType<UsuarioRepository>();
                    scan.AssemblyContainingType<IUsuarioBL>();
                    scan.AssemblyContainingType<RepositoryQueryExecutor>();
                    scan.WithDefaultConventions();
                });

                x.For<DbContext>().HybridHttpOrThreadLocalScoped().Use<DbContextBase>();
                x.For<MembershipProvider>().Use(Membership.Provider);
            });
        }
    }
}
