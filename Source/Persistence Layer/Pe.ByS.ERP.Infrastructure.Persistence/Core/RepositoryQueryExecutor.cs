using System.Collections.Generic;
using System.Data.Entity;
using Pe.ByS.ERP.Infrastructure.Repository.RepositoryContracts;
using StructureMap;

namespace Pe.ByS.ERP.Infrastructure.Persistence.Core
{
    public class RepositoryQueryExecutor : IRepositoryQueryExecutor
    {
        private readonly DbContext _instanceDB;

        public RepositoryQueryExecutor()
        {
            _instanceDB = ObjectFactory.GetInstance<DbContext>();
        }

        public IEnumerable<TQ> SqlCommand<TQ>(string sql, params object[] parameters)
        {
            return _instanceDB.Database.SqlQuery<TQ>(sql, parameters);
        }
    }
}