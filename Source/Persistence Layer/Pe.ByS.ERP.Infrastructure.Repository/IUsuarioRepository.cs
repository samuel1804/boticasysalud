
using System.Collections.Generic;
using Pe.ByS.ERP.Domain;
using Pe.ByS.ERP.Infrastructure.Repository.RepositoryContracts;

namespace Pe.ByS.ERP.Infrastructure.Repository
{
    public interface IUsuarioRepository : IRepositoryWithTypedId<Usuario, int>
    {
        Usuario Login(string username, string password);
        bool IsUserInRole(string username, string roleName);
        IList<Usuario> GetUsersInRol(string roleName, string usernameToMatch);
    }
}