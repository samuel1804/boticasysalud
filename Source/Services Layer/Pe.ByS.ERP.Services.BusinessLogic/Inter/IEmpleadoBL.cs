using System;
using System.Linq;
using System.Linq.Expressions;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Services.BusinessLogic.Inter
{
    public interface IEmpleadoBL : IJQGridPaging<Empleado>
    {
        void Add(Empleado entity);
        void Update(Empleado entity);
        Empleado Get(Expression<Func<Empleado, bool>> where);
        IQueryable<Empleado> FindAll(Expression<Func<Empleado, bool>> where);
    }
}