using System.Data.Entity.ModelConfiguration;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Infrastructure.Persistence.DatabaseMappings
{
    public class TiendaConfiguration : EntityTypeConfiguration<Tienda>
    {
        public TiendaConfiguration()
        {
            Property(p => p.CodigoTienda).IsRequired().HasMaxLength(15);
            Property(p => p.Direccion).IsRequired();
        }
    }
}