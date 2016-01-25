using System;
using System.Data.Entity;

namespace Pe.ByS.ERP.Infrastructure.Persistence.EntityFramework
{
    public class DbModelBuilderWrapper : IDbModelBuilder
    {
        private readonly DbModelBuilder modelBuilder;

        public DbModelBuilderWrapper(DbModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void AddConfiguration(Type entityTypeConfiguration)
        {
            object obj2 = Activator.CreateInstance(entityTypeConfiguration);
            this.modelBuilder.Configurations.Add((dynamic)obj2);
        }

        public void AddEntity(Type entityType)
        {
            typeof(DbModelBuilder).GetMethod("Entity").MakeGenericMethod(new Type[] { entityType }).Invoke(this.modelBuilder, null);
        }
    }
}