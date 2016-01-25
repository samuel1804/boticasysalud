using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Pe.ByS.ERP.CrossCutting.Common;

namespace Pe.ByS.ERP.Services.BusinessLogic.Inter
{
    public interface IJQGridPaging<T> where T : class
    {
        int Count(Expression<Func<T, bool>> @where);
        IList<T> GetAll(string sidx, string sord, int rows, int start, Expression<Func<T, bool>> @where);
        IQueryable<T> GetAll(JQGridParameters<T> parameters);
    }
}