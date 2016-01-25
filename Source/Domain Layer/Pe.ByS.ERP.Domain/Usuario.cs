using Pe.ByS.ERP.Domain.Core;

namespace Pe.ByS.ERP.Domain
{
    public class Usuario: EntityAuditable<int>
    {
        public virtual string Nombre { get; set; }
        public virtual string Username { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string Telefono { get; set; }
    }
}