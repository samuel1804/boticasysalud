using System;
using System.Linq.Expressions;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Services.BusinessLogic.Inter
{
    public interface IUsuarioBL : IJQGridPaging<Usuario>
    {
        Usuario Login(string username, string password);
        bool IsUserInRole(string username, string roleName);
        Usuario Get(Expression<Func<Usuario, bool>> where);
        void Add(Usuario entity);
        void Update(Usuario entity);
        Usuario GetById(int id);
    }
}