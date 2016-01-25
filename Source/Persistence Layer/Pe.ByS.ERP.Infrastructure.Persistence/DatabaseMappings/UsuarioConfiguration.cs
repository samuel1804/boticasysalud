using System.Data.Entity.ModelConfiguration;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Infrastructure.Persistence.DatabaseMappings
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            Property(p => p.Password).IsRequired().HasMaxLength(100);
            Property(p => p.Nombre).IsRequired().HasMaxLength(100);
            Property(p => p.Username).IsRequired().HasMaxLength(100);
            Property(p => p.Apellido).IsRequired().HasMaxLength(250);
            Property(p => p.Email).IsRequired().HasMaxLength(100);
            Property(p => p.Telefono).HasMaxLength(50);
        }
    }
}