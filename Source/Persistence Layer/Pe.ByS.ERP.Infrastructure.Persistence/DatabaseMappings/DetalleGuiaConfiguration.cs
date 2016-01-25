using System.Data.Entity.ModelConfiguration;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Infrastructure.Persistence.DatabaseMappings
{
    public class DetalleGuiaConfiguration : EntityTypeConfiguration<DetalleGuia>
    {
        public DetalleGuiaConfiguration()
        {
            HasRequired(p => p.Producto).WithMany().HasForeignKey(p => p.ProductoId);
            HasRequired(p => p.GuiaRemision).WithMany().HasForeignKey(p => p.GuiaRemisionId);
        }
    }
}