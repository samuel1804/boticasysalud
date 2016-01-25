using System;
using System.Linq;
using System.Linq.Expressions;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Services.BusinessLogic.Inter
{
    public interface ITiendaBL : IJQGridPaging<Tienda>
    {
        void Add(Tienda entity);
        void Update(Tienda entity);
        Tienda Get(Expression<Func<Tienda, bool>> where);
        IQueryable<Tienda> FindAll(Expression<Func<Tienda, bool>> where);
    }
}