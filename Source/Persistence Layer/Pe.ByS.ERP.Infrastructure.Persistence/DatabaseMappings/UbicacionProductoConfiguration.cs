using System.Data.Entity.ModelConfiguration;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Infrastructure.Persistence.DatabaseMappings
{
    public class UbicacionProductoConfiguration : EntityTypeConfiguration<UbicacionProducto>
    {
        public UbicacionProductoConfiguration()
        {
            ToTable("RYA_UBICACIONES");

            Property(p => p.ProductoId).HasColumnName("Cod_Producto");
            Property(p => p.Lote).IsRequired().HasMaxLength(15);
            Property(p => p.Cantidad).HasColumnName("Cant");
            Property(p => p.Modulo).IsRequired().HasMaxLength(20);
            Property(p => p.FechaCreacion).HasColumnName("Fec_Usu_Regi");
            Property(p => p.FechaModificacion).HasColumnName("Fec_Usu_Modi");
            Property(p => p.UsuarioCreacion).HasColumnName("Cod_Usu_Regi");
            Property(p => p.UsuarioModificacion).HasColumnName("Cod_Usu_Modi");

            HasRequired(p => p.Producto).WithMany().HasForeignKey(p => p.ProductoId);
            HasRequired(p => p.Almacen).WithMany().HasForeignKey(p => p.AlmacenId);
        }
    }
}