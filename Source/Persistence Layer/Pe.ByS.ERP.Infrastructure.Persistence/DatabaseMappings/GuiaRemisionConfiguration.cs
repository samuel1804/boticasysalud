using System.Data.Entity.ModelConfiguration;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Infrastructure.Persistence.DatabaseMappings
{
    public class GuiaRemisionConfiguration : EntityTypeConfiguration<GuiaRemision>
    {
        public GuiaRemisionConfiguration()
        {
            Property(p => p.Serie).IsOptional();
            Property(p => p.Direccion).IsOptional();
            Property(p => p.Telefono).IsOptional();
            Property(p => p.Detalle).IsOptional();
        }
    }
}