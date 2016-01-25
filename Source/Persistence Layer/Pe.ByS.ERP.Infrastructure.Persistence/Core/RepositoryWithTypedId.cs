using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using Pe.ByS.ERP.CrossCutting.Common;
using Pe.ByS.ERP.CrossCutting.Common.Enums;
using Pe.ByS.ERP.Infrastructure.Repository.RepositoryContracts;
using Pe.ByS.ERP.Infrastructure.Repository.Specifications;
using SIGCOMT.Comun.Enum;
using StructureMap;

namespace Pe.ByS.ERP.Infrastructure.Persistence.Core
{
    /// <summary>
    /// Clase Generica para utilizarse como repositorio de Datos
    /// </summary>
    /// <typeparam name="T">Tipo del Domain asociado</typeparam>
    /// <typeparam name="TId">Tipo de dato del parametro utilizado como llave</typeparam>
    public class RepositoryWithTypedId<T, TId> : IRepositoryWithTypedId<T, TId> where T : class
    {
        public IDbSet<T> Set;
        private readonly DbContext _instanceDB;
        public Expression<Func<T, bool>> Filter { get; set; }

        public RepositoryWithTypedId()
        {
            _instanceDB = ObjectFactory.GetInstance<DbContext>();
            Set = _instanceDB.Set<T>();
        }

        public void Add(T entity)
        {
            Set.Add(entity);
        }

        public T AddGet(T entity)
        {
            return Set.Add(entity);
        }

        public void Update(T entity)
        {
            //var entidadTrackeada = Set.Find(GetKey(entity));
            //if (entidadTrackeada != null)
            //{
            //    var attachedEntity = _instanceDB.Entry(entidadTrackeada);
            //    attachedEntity.CurrentValues.SetValues(entity);
            //}
            //else
            //{
            //    _instanceDB.Entry(entity).State = System.Data.EntityState.Modified;
            //}
        }

        public void Delete(T entity)
        {
            Set.Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return Set;
        }

        public IQueryable<T> FindAll(IQuerySpecification<T> specification)
        {
            return specification.SatisfyingElementsFrom(Set);
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> expression)
        {
            return FindAll(new AdHocSpecification<T>(expression));
        }

        public T FindOne(IQuerySpecification<T> specification)
        {
            return specification.SatisfyingElementsFrom(Set).SingleOrDefault();
        }

        public T FindOne(Expression<Func<T, bool>> expression)
        {
            return FindOne(new AdHocSpecification<T>(expression));
        }

        public T FindOne(TId id)
        {
            return Set.Find(new object[] { id });
        }

        [Obsolete]
        public IList<T> FindAllPaging(string sidx, string sord, int rows, int start, Expression<Func<T, bool>> where)
        {
            dynamic orderBy = UtilsComun.LambdaPropertyOrderBy<T>(sidx);

            return (sord == TipoOrden.asc.ToString()) ?
                Enumerable.ToList(Queryable.Take(Queryable.Skip(Queryable.OrderBy(GetListContext().Where(where), orderBy), start), rows)) :
                Enumerable.ToList(Queryable.Take(Queryable.Skip(Queryable.OrderByDescending(GetListContext().Where(where), orderBy), start), rows));
        }

        //public IList<T> FindAllPaging(JQGridParameters<T> parameters)
        //{
        //    dynamic orderBy = UtilsComun.LambdaPropertyOrderBy<T>(parameters.ColumnOrder);

        //    return (parameters.OrderType == TipoOrden.asc) ?
        //       Enumerable.ToList(Queryable.Take(Queryable.Skip(Queryable.OrderBy(GetListContext().Where(parameters.WhereFilter), orderBy), parameters.Start), parameters.AmountRows)) :
        //       Enumerable.ToList(Queryable.Take(Queryable.Skip(Queryable.OrderByDescending(GetListContext().Where(parameters.WhereFilter), orderBy), parameters.Start), parameters.AmountRows));
        //}

        public IQueryable<T> FindAllPaging(JQGridParameters<T> parameters)
        {
            var orderBy = UtilsComun.LambdaPropertyOrderBy<T>(parameters.ColumnOrder);

            return (parameters.OrderType == TipoOrden.asc) ?
               Queryable.Take(Queryable.Skip(Queryable.OrderBy(GetListContext().Where(parameters.WhereFilter), orderBy), parameters.Start), parameters.AmountRows) :
               Queryable.Take(Queryable.Skip(Queryable.OrderByDescending(GetListContext().Where(parameters.WhereFilter), orderBy), parameters.Start), parameters.AmountRows);
        }

        public int Count(Expression<Func<T, bool>> expression)
        {
            return Set.AsExpandable().Where(expression).Count();
        }

        public virtual object[] GetKey(T entity)
        {
            throw new NotImplementedException();
        }

        private IQueryable<T> GetListContext()
        {
            if (Filter == null)
            {
                return Set;
            }
            return Set.Where(Filter);
        }

        public IEnumerable<TQ> SqlCommand<TQ>(string sql, params object[] parameters)
        {
            _instanceDB.Database.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["TimeOutCommandsDatabase"] ?? "60");
            return _instanceDB.Database.SqlQuery<TQ>(sql, parameters);
        }
    }
}