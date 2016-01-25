using System.Collections.Generic;

namespace Pe.ByS.ERP.Infrastructure.Repository.RepositoryContracts
{
    public interface IRepositoryQueryExecutor
    {
        IEnumerable<TQ> SqlCommand<TQ>(string sql, params object[] parameters);
    }
}