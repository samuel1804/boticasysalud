using System;
using System.Linq.Expressions;

namespace Pe.ByS.ERP.Infrastructure.Repository.Specifications
{
    public class AdHocSpecification<T> : QuerySpecification<T>
    {
        private readonly Expression<Func<T, bool>> expression;

        public AdHocSpecification(Expression<Func<T, bool>> expression)
        {
            this.expression = expression;
        }

        public override Expression<Func<T, bool>> MatchingCriteria
        {
            get
            {
                return this.expression;
            }
        }
    }
}