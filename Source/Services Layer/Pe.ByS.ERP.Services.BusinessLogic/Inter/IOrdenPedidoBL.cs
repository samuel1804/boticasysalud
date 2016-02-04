using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Services.BusinessLogic.Inter
{
    public interface IOrdenPedidoBL : IJQGridPaging<OrdenPedido>
    {
        void Add(OrdenPedido entity);
        void Update(OrdenPedido entity, List<int> detalleEliminar);
        void Delete(OrdenPedido entity);
        OrdenPedido Get(Expression<Func<OrdenPedido, bool>> where);
        IQueryable<OrdenPedido> FindAll(Expression<Func<OrdenPedido, bool>> where);
    }
}