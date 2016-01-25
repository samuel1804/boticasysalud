using Pe.ByS.ERP.Domain;
using Pe.ByS.ERP.Infrastructure.Persistence.Core;
using Pe.ByS.ERP.Infrastructure.Repository;

namespace Pe.ByS.ERP.Infrastructure.SqlServer
{
    public class UsuarioRepository : RepositoryWithTypedId<Usuario, int>, IUsuarioRepository
    {
        public Usuario Login(string username, string password)
        {
            if (username.ToLower() == "admin" && password.ToLower() == "1234")
            {
                return new Usuario
                {
                    Id = 1,
                    Username = "Admin",
                    Password = "1234",
                    Email = "mcastillo@sigcomt.com"
                };
            }
            return null;
        }

        public bool IsUserInRole(string username, string roleName)
        {
            return true;
        }

        public System.Collections.Generic.IList<Usuario> GetUsersInRol(string roleName, string usernameToMatch)
        {
            throw new System.NotImplementedException();
        }

        public override object[] GetKey(Usuario entity)
        {
            return new object[] 
            {
                entity.Id
            };
        }
    }
}