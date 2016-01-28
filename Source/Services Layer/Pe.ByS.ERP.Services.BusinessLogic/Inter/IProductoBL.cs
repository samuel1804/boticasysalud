using System;
using System.Linq;
using System.Linq.Expressions;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Services.BusinessLogic.Inter
{
    public interface IProductoBL : IJQGridPaging<Producto>
    {
        void Add(Producto entity);
        void Update(Producto entity);
        Producto Get(Expression<Func<Producto, bool>> where);
        IQueryable<Producto> FindAll(Expression<Func<Producto, bool>> where);
    }
}