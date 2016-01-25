using System.Data.Entity.ModelConfiguration;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Infrastructure.Persistence.DatabaseMappings
{
    public class ProductoConfiguration : EntityTypeConfiguration<Producto>
    {
        public ProductoConfiguration()
        {
            ToTable("RYA_PRODUCTO");

            Property(p => p.Id).HasColumnName("Cod_Producto").HasMaxLength(10);
            Property(p => p.Nombre).IsOptional().HasMaxLength(100);
            Property(p => p.UnidadMedida).IsOptional();
            Property(p => p.Precio).HasPrecision(10, 2);
            Property(p => p.Presentacion).IsOptional().HasMaxLength(20);
            
            Property(p => p.FechaCreacion).HasColumnName("Fec_Usu_Regi");
            Property(p => p.FechaModificacion).HasColumnName("Fec_Usu_Modi");
            Property(p => p.UsuarioCreacion).HasColumnName("Cod_Usu_Regi");
            Property(p => p.UsuarioModificacion).HasColumnName("Cod_Usu_Modi");
        }
    }
}