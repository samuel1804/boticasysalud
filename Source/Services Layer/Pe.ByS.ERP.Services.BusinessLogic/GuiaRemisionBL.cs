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
    public class GuiaRemisionBL : IGuiaRemisionBL
    {
        private readonly IGuiaRemisionRepository _guiaRepository;

        public GuiaRemisionBL(IGuiaRemisionRepository guiaRepository)
        {
            _guiaRepository = guiaRepository;
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public GuiaRemision Get(Expression<Func<GuiaRemision, bool>> where)
        {
            return _guiaRepository.FindOne(where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IQueryable<GuiaRemision> FindAll(Expression<Func<GuiaRemision, bool>> where)
        {
            return _guiaRepository.FindAll(where);
        }

        [CommitsOperation]
        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public void Add(GuiaRemision entity)
        {
            _guiaRepository.Add(entity);
        }

        [CommitsOperation]
        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public void Update(GuiaRemision entity)
        {
            _guiaRepository.Update(entity);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public int Count(Expression<Func<GuiaRemision, bool>> where)
        {
            return _guiaRepository.Count(where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IList<GuiaRemision> GetAll(string sidx, string sord, int rows, int start, Expression<Func<GuiaRemision, bool>> where)
        {
            return _guiaRepository.FindAllPaging(sidx, sord, rows, start, where);
        }

        [TryCatch(ExceptionTypeExpected = typeof(Exception), RethrowException = true)]
        public IQueryable<GuiaRemision> GetAll(JQGridParameters<GuiaRemision> parameters)
        {
            return _guiaRepository.FindAllPaging(parameters);
        }
    }
}