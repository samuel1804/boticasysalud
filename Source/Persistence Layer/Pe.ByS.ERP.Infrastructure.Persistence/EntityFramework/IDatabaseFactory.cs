
using System;

namespace Pe.ByS.ERP.Infrastructure.Persistence.EntityFramework
{
    public interface IDatabaseFactory : IDisposable
    {
        DbContextBase Get();
    }
}
