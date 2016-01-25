using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;

namespace Pe.ByS.ERP.Infrastructure.Persistence.EntityFramework
{
    public class DbContextBase : DbContext
    {
        public DbContextBase()
            : base(PersistenceConfigurator.ConnectionStringKey)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            new AutoMapper().Apply(new DbModelBuilderWrapper(modelBuilder));
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                string msg = dbEx.Message;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += " " + string.Format("Class: {0}, Property: {1}, Error: {2}", validationErrors.Entry.Entity.GetType().FullName, validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                throw new Exception(msg);
            }
        }
    }
}