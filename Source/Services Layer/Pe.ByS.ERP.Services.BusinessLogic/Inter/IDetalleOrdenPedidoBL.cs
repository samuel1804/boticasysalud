using System;
using System.Linq;
using System.Linq.Expressions;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Services.BusinessLogic.Inter
{
    public interface IDetalleOrdenPedidoBL : IJQGridPaging<DetalleOrdenPedido>
    {
        void Add(DetalleOrdenPedido entity);
        void Update(DetalleOrdenPedido entity);
        void Delete(DetalleOrdenPedido entity);
        DetalleOrdenPedido Get(Expression<Func<DetalleOrdenPedido, bool>> where);
        IQueryable<DetalleOrdenPedido> FindAll(Expression<Func<DetalleOrdenPedido, bool>> where);
    }
}