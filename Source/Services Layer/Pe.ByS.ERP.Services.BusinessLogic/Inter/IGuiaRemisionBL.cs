using System;
using System.Linq;
using System.Linq.Expressions;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Services.BusinessLogic.Inter
{
    public interface IGuiaRemisionBL : IJQGridPaging<GuiaRemision>
    {
        void Add(GuiaRemision entity);
        void Update(GuiaRemision entity);
        GuiaRemision Get(Expression<Func<GuiaRemision, bool>> where);
        IQueryable<GuiaRemision> FindAll(Expression<Func<GuiaRemision, bool>> where);
    }
}