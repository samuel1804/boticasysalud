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
    public class OrdenPedidoBL : IOrdenPedidoBL
    {
        private readonly IOrdenPedidoRepository _ordenRepository;

        public OrdenPedidoBL(IOrdenPedidoRepository ordenRepository)
        {
            _ordenRepository = ordenRepository;
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public OrdenPedido Get(Expression<Func<OrdenPedido, bool>> where)
        {
            return _ordenRepository.FindOne(where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IQueryable<OrdenPedido> FindAll(Expression<Func<OrdenPedido, bool>> where)
        {
            return _ordenRepository.FindAll(where);
        }

        [CommitsOperation]
        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public void Add(OrdenPedido entity)
        {
            _ordenRepository.Add(entity);
        }

        [CommitsOperation]
        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public void Update(OrdenPedido entity)
        {
            _ordenRepository.Update(entity);
        }

        [CommitsOperation]
        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public void Delete(OrdenPedido entity)
        {
            _ordenRepository.Delete(entity);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public int Count(Expression<Func<OrdenPedido, bool>> where)
        {
            return _ordenRepository.Count(where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IList<OrdenPedido> GetAll(string sidx, string sord, int rows, int start, Expression<Func<OrdenPedido, bool>> where)
        {
            return _ordenRepository.FindAllPaging(sidx, sord, rows, start, where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IQueryable<OrdenPedido> GetAll(JQGridParameters<OrdenPedido> parameters)
        {
            return _ordenRepository.FindAllPaging(parameters);
        }
    }
}