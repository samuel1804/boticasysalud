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
    public class EmpleadoBL : IEmpleadoBL
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoBL(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public Empleado Get(Expression<Func<Empleado, bool>> where)
        {
            return _empleadoRepository.FindOne(where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IQueryable<Empleado> FindAll(Expression<Func<Empleado, bool>> where)
        {
            return _empleadoRepository.FindAll(where);
        }

        [CommitsOperation]
        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public void Add(Empleado entity)
        {
            _empleadoRepository.Add(entity);
        }

        [CommitsOperation]
        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public void Update(Empleado entity)
        {
            _empleadoRepository.Update(entity);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public int Count(Expression<Func<Empleado, bool>> where)
        {
            return _empleadoRepository.Count(where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IList<Empleado> GetAll(string sidx, string sord, int rows, int start, Expression<Func<Empleado, bool>> where)
        {
            return _empleadoRepository.FindAllPaging(sidx, sord, rows, start, where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IQueryable<Empleado> GetAll(JQGridParameters<Empleado> parameters)
        {
            return _empleadoRepository.FindAllPaging(parameters);
        }
    }
}