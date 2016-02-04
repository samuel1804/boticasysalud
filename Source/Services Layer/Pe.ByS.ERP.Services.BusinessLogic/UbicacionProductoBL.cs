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
    public class UbicacionProductoBL : IUbicacionProductoBL
    {
        private readonly IUbicacionProductoRepository _ubicacionRepository;

        public UbicacionProductoBL(IUbicacionProductoRepository ubicacionRepository)
        {
            _ubicacionRepository = ubicacionRepository;
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public UbicacionProducto Get(Expression<Func<UbicacionProducto, bool>> where)
        {
            return _ubicacionRepository.FindOne(where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IQueryable<UbicacionProducto> FindAll(Expression<Func<UbicacionProducto, bool>> where)
        {
            return _ubicacionRepository.FindAll(where);
        }

        [CommitsOperation]
        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public void Add(UbicacionProducto entity)
        {
            _ubicacionRepository.Add(entity);
        }

        [CommitsOperation]
        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public void AddRange(List<UbicacionProducto> entityList)
        {
            foreach (var item in entityList)
            {
                _ubicacionRepository.Add(item);
            }
        }

        [CommitsOperation]
        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public void Update(UbicacionProducto entity)
        {
            _ubicacionRepository.Update(entity);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public int Count(Expression<Func<UbicacionProducto, bool>> where)
        {
            return _ubicacionRepository.Count(where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IList<UbicacionProducto> GetAll(string sidx, string sord, int rows, int start, Expression<Func<UbicacionProducto, bool>> where)
        {
            return _ubicacionRepository.FindAllPaging(sidx, sord, rows, start, where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IQueryable<UbicacionProducto> GetAll(JQGridParameters<UbicacionProducto> parameters)
        {
            return _ubicacionRepository.FindAllPaging(parameters);
        }
    }
}