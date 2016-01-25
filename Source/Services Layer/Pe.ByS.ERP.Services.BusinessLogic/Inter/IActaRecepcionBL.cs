using System;
using System.Linq;
using System.Linq.Expressions;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Services.BusinessLogic.Inter
{
    public interface IActaRecepcionBL : IJQGridPaging<ActaRecepcion>
    {
        void Add(ActaRecepcion entity);
        void Update(ActaRecepcion entity);
        ActaRecepcion Get(Expression<Func<ActaRecepcion, bool>> where);
        IQueryable<ActaRecepcion> FindAll(Expression<Func<ActaRecepcion, bool>> where);
    }
}