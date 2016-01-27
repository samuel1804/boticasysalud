using System.Data.Entity.ModelConfiguration;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Infrastructure.Persistence.DatabaseMappings
{
    public class TipoProductoConfiguration : EntityTypeConfiguration<TipoProducto>
    {
        public TipoProductoConfiguration()
        {
            ToTable("DIS_TipoProducto");

            Property(p => p.Id).HasColumnName("Cod_Tipo_Producto");
            Property(p => p.Descripcion).IsRequired().HasMaxLength(50).HasColumnName("Des_Tipo_Producto");

            Property(p => p.FechaCreacion).HasColumnName("Fec_Usu_Regi");
            Property(p => p.FechaModificacion).HasColumnName("Fec_Usu_Modi");
            Property(p => p.UsuarioCreacion).HasColumnName("Cod_Usu_Regi");
            Property(p => p.UsuarioModificacion).HasColumnName("Cod_Usu_Modi");
        }
    }
}