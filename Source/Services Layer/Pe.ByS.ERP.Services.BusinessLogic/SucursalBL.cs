using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Pe.ByS.ERP.CrossCutting.Aspects;
using Pe.ByS.ERP.CrossCutting.Common;
using Pe.ByS.ERP.CrossCutting.Common.Enums;
using Pe.ByS.ERP.Domain;
using Pe.ByS.ERP.Infrastructure.Persistence.Aspects;
using Pe.ByS.ERP.Infrastructure.Repository;
using Pe.ByS.ERP.Services.BusinessLogic.Inter;

namespace Pe.ByS.ERP.Services.BusinessLogic
{
    public class SucursalBL : ISucursalBL
    {
        private readonly ISucursalRepository _sucursalRepository;

        public SucursalBL(ISucursalRepository sucursalRepository)
        {
            _sucursalRepository = sucursalRepository;
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public Sucursal Get(Expression<Func<Sucursal, bool>> where)
        {
            return _sucursalRepository.FindOne(where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IQueryable<Sucursal> FindAll(Expression<Func<Sucursal, bool>> where)
        {
            return _sucursalRepository.FindAll(where);
        }

        [CommitsOperation]
        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public void Add(Sucursal entity)
        {
            _sucursalRepository.Add(entity);
        }

        [CommitsOperation]
        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public void Update(Sucursal entity)
        {
            _sucursalRepository.Update(entity);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public int Count(Expression<Func<Sucursal, bool>> where)
        {
            return _sucursalRepository.Count(where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IList<Sucursal> GetAll(string sidx, string sord, int rows, int start, Expression<Func<Sucursal, bool>> where)
        {
            return _sucursalRepository.FindAllPaging(sidx, sord, rows, start, where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IQueryable<Sucursal> GetAll(JQGridParameters<Sucursal> parameters)
        {
            return _sucursalRepository.FindAllPaging(parameters);
        }
    }
}