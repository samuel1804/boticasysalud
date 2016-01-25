using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pe.ByS.ERP.Domain;
using Pe.ByS.ERP.Infrastructure.Persistence;
using Pe.ByS.ERP.Infrastructure.Persistence.EntityFramework;

namespace Pe.ByS.ERP.DataBase.Generator
{
    [TestClass]
    public class DataBaseTest
    {
        [TestMethod]
        public void CreateDataBaseDesarrollo()
        {
            Database.SetInitializer(new DbContextDropCreateDatabaseAlwaysDesarrollo());
            PersistenceConfigurator.Configure("DefaultConnection", typeof(Usuario).Assembly, typeof(ConnectionFactory).Assembly);
            var target = new DbContextBase();
            target.Database.Initialize(true);
        }
    }

    public class DbContextDropCreateDatabaseAlwaysDesarrollo : DropCreateDatabaseAlways<DbContextBase>
    {
        protected override void Seed(DbContextBase context)
        {
            
        }
    }
}