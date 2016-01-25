using System;
using System.Linq;
using System.Linq.Expressions;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Services.BusinessLogic.Inter
{
    public interface ISucursalBL : IJQGridPaging<Sucursal>
    {
        void Add(Sucursal entity);
        void Update(Sucursal entity);
        Sucursal Get(Expression<Func<Sucursal, bool>> where);
        IQueryable<Sucursal> FindAll(Expression<Func<Sucursal, bool>> where);
    }
}