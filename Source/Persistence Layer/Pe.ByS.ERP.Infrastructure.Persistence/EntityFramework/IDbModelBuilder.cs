using System;

namespace Pe.ByS.ERP.Infrastructure.Persistence.EntityFramework
{
    public interface IDbModelBuilder
    {
        void AddConfiguration(Type entityTypeConfiguration);

        void AddEntity(Type entityType);
    }
}