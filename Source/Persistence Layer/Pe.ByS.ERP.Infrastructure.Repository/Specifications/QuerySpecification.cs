using System;
using System.Linq;
using System.Linq.Expressions;

namespace Pe.ByS.ERP.Infrastructure.Repository.Specifications
{
    public abstract class QuerySpecification<T> : IQuerySpecification<T>
    {
        protected QuerySpecification()
        {
        }

        public virtual IQueryable<T> SatisfyingElementsFrom(IQueryable<T> candidates)
        {
            if (this.MatchingCriteria != null)
            {
                return candidates.Where<T>(this.MatchingCriteria).AsQueryable<T>();
            }
            return candidates;
        }

        public virtual Expression<Func<T, bool>> MatchingCriteria
        {
            get
            {
                return null;
            }
        }
    }
}