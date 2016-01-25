using System.Data.Entity.ModelConfiguration;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Infrastructure.Persistence.DatabaseMappings
{
    public class DetalleActaRecepcionConfiguration : EntityTypeConfiguration<DetalleActaRecepcion>
    {
        public DetalleActaRecepcionConfiguration()
        {
            ToTable("RYA_ACTARECEP_DET");

            Property(p => p.ProductoId).HasColumnName("Cod_Producto");
            Property(p => p.ActaRecepcionId).HasColumnName("NumActa");
            Property(p => p.Cantidad).HasColumnName("Cant");
            Property(p => p.Lote).IsRequired().HasMaxLength(15);
            Property(p => p.Observacion).IsOptional().HasMaxLength(150);

            HasRequired(p => p.Producto).WithMany().HasForeignKey(p => p.ProductoId);
            HasRequired(p => p.ActaRecepcion).WithMany(p => p.DetalleActaRecepcion).HasForeignKey(p => p.ActaRecepcionId);
        }
    }
}