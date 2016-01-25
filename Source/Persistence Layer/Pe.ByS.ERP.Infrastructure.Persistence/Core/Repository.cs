using Pe.ByS.ERP.Infrastructure.Repository.RepositoryContracts;

namespace Pe.ByS.ERP.Infrastructure.Persistence.Core
{

    public class Repository<T> : RepositoryWithTypedId<T, int>, IRepository<T> where T : class
    {
    }
}