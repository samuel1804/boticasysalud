using System.Linq;

namespace Pe.ByS.ERP.Infrastructure.Repository.Specifications
{
    public interface IQuerySpecification<T>
    {
        IQueryable<T> SatisfyingElementsFrom(IQueryable<T> candidates);
    }
}