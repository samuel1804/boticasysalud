using System.Data.Entity.ModelConfiguration;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Infrastructure.Persistence.DatabaseMappings
{
    public class ProductoConfiguration : EntityTypeConfiguration<Producto>
    {
        public ProductoConfiguration()
        {
            ToTable("DIS_Producto");

            Property(p => p.Id).HasColumnName("Cod_Producto");
            Property(p => p.Nombre).HasMaxLength(255).HasColumnName("Nom_Producto");
            Property(p => p.Descripcion).IsOptional().HasMaxLength(255);
            Property(p => p.TipoProductoId).HasColumnName("Cod_Tipo_Producto");
            Property(p => p.PresentacionId).HasColumnName("Cod_presentacion_Producto");
            Property(p => p.UnidadMedida).IsOptional().HasColumnName("Unidad_Medida");
            Property(p => p.Peso).HasPrecision(10, 2).HasColumnName("Peso_producto");
            Property(p => p.FechaCreacion).HasColumnName("Fec_Usu_Regi");
            Property(p => p.FechaModificacion).HasColumnName("Fec_Usu_Modi");
            Property(p => p.UsuarioCreacion).HasColumnName("Cod_Usu_Regi");
            Property(p => p.UsuarioModificacion).HasColumnName("Cod_Usu_Modi");

            HasRequired(p => p.TipoProducto).WithMany().HasForeignKey(p => p.TipoProductoId);
            HasRequired(p => p.Presentacion).WithMany().HasForeignKey(p => p.PresentacionId);
        }
    }
}