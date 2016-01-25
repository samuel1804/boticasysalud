namespace Pe.ByS.ERP.Infrastructure.Repository.RepositoryContracts
{
    public interface IRepository<T> : IRepositoryWithTypedId<T, int> where T : class
    {
    }
}