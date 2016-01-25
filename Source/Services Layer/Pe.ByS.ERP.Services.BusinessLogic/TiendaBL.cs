using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Pe.ByS.ERP.CrossCutting.Aspects;
using Pe.ByS.ERP.CrossCutting.Common;
using Pe.ByS.ERP.Domain;
using Pe.ByS.ERP.Infrastructure.Persistence.Aspects;
using Pe.ByS.ERP.Infrastructure.Repository;
using Pe.ByS.ERP.Services.BusinessLogic.Inter;

namespace Pe.ByS.ERP.Services.BusinessLogic
{
    public class TiendaBL : ITiendaBL
    {
        private readonly ITiendaRepository _tiendaRepository;

        public TiendaBL(ITiendaRepository tiendaRepository)
        {
            _tiendaRepository = tiendaRepository;
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public Tienda Get(Expression<Func<Tienda, bool>> where)
        {
            return _tiendaRepository.FindOne(where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IQueryable<Tienda> FindAll(Expression<Func<Tienda, bool>> where)
        {
            return _tiendaRepository.FindAll(where);
        }

        [CommitsOperation]
        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public void Add(Tienda entity)
        {
            _tiendaRepository.Add(entity);
        }

        [CommitsOperation]
        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public void Update(Tienda entity)
        {
            _tiendaRepository.Update(entity);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public int Count(Expression<Func<Tienda, bool>> where)
        {
            return _tiendaRepository.Count(where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IList<Tienda> GetAll(string sidx, string sord, int rows, int start, Expression<Func<Tienda, bool>> where)
        {
            return _tiendaRepository.FindAllPaging(sidx, sord, rows, start, where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IQueryable<Tienda> GetAll(JQGridParameters<Tienda> parameters)
        {
            return _tiendaRepository.FindAllPaging(parameters);
        }
    }
}