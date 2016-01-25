using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Pe.ByS.ERP.CrossCutting.Common;
using Pe.ByS.ERP.Infrastructure.Repository.Specifications;

namespace Pe.ByS.ERP.Infrastructure.Repository.RepositoryContracts
{
    public interface IRepositoryWithTypedId<T, in TId> where T : class
    {
        Expression<Func<T, bool>> Filter { get; set; }

        void Add(T entity);

        T AddGet(T entity);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> FindAll();

        IQueryable<T> FindAll(IQuerySpecification<T> specification);

        IQueryable<T> FindAll(Expression<Func<T, bool>> expression);

        T FindOne(IQuerySpecification<T> specification);

        T FindOne(Expression<Func<T, bool>> expression);

        T FindOne(TId id);

        //IList<T> FindAllPaging(Expression<Func<T, object>> orderBy, string sord, int rows, int start, Expression<Func<T, bool>> where);
        IList<T> FindAllPaging(string sidx, string sord, int rows, int start, Expression<Func<T, bool>> where);

        IQueryable<T> FindAllPaging(JQGridParameters<T> parameters);

        int Count(Expression<Func<T, bool>> expression);

        IEnumerable<TQ> SqlCommand<TQ>(string sql, params object[] parameters);
    }
}