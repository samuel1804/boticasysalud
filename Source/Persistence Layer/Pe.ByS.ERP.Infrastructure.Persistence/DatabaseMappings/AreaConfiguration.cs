using System.Data.Entity.ModelConfiguration;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Infrastructure.Persistence.DatabaseMappings
{
    public class AreaConfiguration : EntityTypeConfiguration<Area>
    {
        public AreaConfiguration()
        {
            ToTable("RRH_Area");

            Property(p => p.Id).HasColumnName("Cod_Area");
            Property(p => p.Nombre).HasMaxLength(50);
        }
    }
}