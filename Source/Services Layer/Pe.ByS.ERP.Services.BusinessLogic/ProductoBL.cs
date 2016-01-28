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
    public class ProductoBL : IProductoBL
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoBL(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public Producto Get(Expression<Func<Producto, bool>> where)
        {
            return _productoRepository.FindOne(where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IQueryable<Producto> FindAll(Expression<Func<Producto, bool>> where)
        {
            return _productoRepository.FindAll(where);
        }

        [CommitsOperation]
        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public void Add(Producto entity)
        {
            _productoRepository.Add(entity);
        }

        [CommitsOperation]
        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public void Update(Producto entity)
        {
            _productoRepository.Update(entity);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public int Count(Expression<Func<Producto, bool>> where)
        {
            return _productoRepository.Count(where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IList<Producto> GetAll(string sidx, string sord, int rows, int start, Expression<Func<Producto, bool>> where)
        {
            return _productoRepository.FindAllPaging(sidx, sord, rows, start, where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IQueryable<Producto> GetAll(JQGridParameters<Producto> parameters)
        {
            return _productoRepository.FindAllPaging(parameters);
        }
    }
}