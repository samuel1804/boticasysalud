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
    public class ActaRecepcionBL : IActaRecepcionBL
    {
        private readonly IActaRecepcionRepository _actaRepository;

        public ActaRecepcionBL(IActaRecepcionRepository actaRepository)
        {
            _actaRepository = actaRepository;
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public ActaRecepcion Get(Expression<Func<ActaRecepcion, bool>> where)
        {
            return _actaRepository.FindOne(where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IQueryable<ActaRecepcion> FindAll(Expression<Func<ActaRecepcion, bool>> where)
        {
            return _actaRepository.FindAll(where);
        }

        [CommitsOperation]
        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public void Add(ActaRecepcion entity)
        {
            _actaRepository.Add(entity);
        }

        [CommitsOperation]
        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public void Update(ActaRecepcion entity)
        {
            _actaRepository.Update(entity);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public int Count(Expression<Func<ActaRecepcion, bool>> where)
        {
            return _actaRepository.Count(where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IList<ActaRecepcion> GetAll(string sidx, string sord, int rows, int start, Expression<Func<ActaRecepcion, bool>> where)
        {
            return _actaRepository.FindAllPaging(sidx, sord, rows, start, where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IQueryable<ActaRecepcion> GetAll(JQGridParameters<ActaRecepcion> parameters)
        {
            return _actaRepository.FindAllPaging(parameters);
        }
    }
}