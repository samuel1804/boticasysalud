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
    public class DetalleOrdenPedidoBL : IDetalleOrdenPedidoBL
    {
        private readonly IDetalleOrdenPedidoRepository _detalleRepository;

        public DetalleOrdenPedidoBL(IDetalleOrdenPedidoRepository detalleRepository)
        {
            _detalleRepository = detalleRepository;
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public DetalleOrdenPedido Get(Expression<Func<DetalleOrdenPedido, bool>> where)
        {
            return _detalleRepository.FindOne(where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IQueryable<DetalleOrdenPedido> FindAll(Expression<Func<DetalleOrdenPedido, bool>> where)
        {
            return _detalleRepository.FindAll(where);
        }

        [CommitsOperation]
        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public void Add(DetalleOrdenPedido entity)
        {
            _detalleRepository.Add(entity);
        }

        [CommitsOperation]
        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public void Update(DetalleOrdenPedido entity)
        {
            _detalleRepository.Update(entity);
        }

        public void Delete(DetalleOrdenPedido entity)
        {
            _detalleRepository.Delete(entity);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public int Count(Expression<Func<DetalleOrdenPedido, bool>> where)
        {
            return _detalleRepository.Count(where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IList<DetalleOrdenPedido> GetAll(string sidx, string sord, int rows, int start, Expression<Func<DetalleOrdenPedido, bool>> where)
        {
            return _detalleRepository.FindAllPaging(sidx, sord, rows, start, where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IQueryable<DetalleOrdenPedido> GetAll(JQGridParameters<DetalleOrdenPedido> parameters)
        {
            return _detalleRepository.FindAllPaging(parameters);
        }
    }
}