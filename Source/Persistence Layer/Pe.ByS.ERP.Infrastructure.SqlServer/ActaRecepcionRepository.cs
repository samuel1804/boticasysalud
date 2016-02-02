using Pe.ByS.ERP.Domain;
using Pe.ByS.ERP.Infrastructure.Persistence.Core;
using Pe.ByS.ERP.Infrastructure.Repository;

namespace Pe.ByS.ERP.Infrastructure.SqlServer
{
    public class ActaRecepcionRepository : RepositoryWithTypedId<ActaRecepcion, int>, IActaRecepcionRepository
    {
        
    }
}