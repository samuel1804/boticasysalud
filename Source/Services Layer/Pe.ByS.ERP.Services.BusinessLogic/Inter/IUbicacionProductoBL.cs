using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Services.BusinessLogic.Inter
{
    public interface IUbicacionProductoBL : IJQGridPaging<UbicacionProducto>
    {
        void Add(UbicacionProducto entity);
        void AddRange(List<UbicacionProducto> entityList);
        void Update(UbicacionProducto entity);
        UbicacionProducto Get(Expression<Func<UbicacionProducto, bool>> where);
        IQueryable<UbicacionProducto> FindAll(Expression<Func<UbicacionProducto, bool>> where);
    }
}