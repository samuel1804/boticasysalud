using System.Data.Entity.ModelConfiguration;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Infrastructure.Persistence.DatabaseMappings
{
    public class PresentacionProductoConfiguration : EntityTypeConfiguration<PresentacionProducto>
    {
        public PresentacionProductoConfiguration()
        {
            ToTable("DIS_PresentacionProducto");

            Property(p => p.Id).HasColumnName("Cod_Presentacion_Producto");
            Property(p => p.Descripcion).IsRequired().HasMaxLength(50).HasColumnName("Des_Presentacion_Producto");

            Property(p => p.FechaCreacion).HasColumnName("Fec_Usu_Regi");
            Property(p => p.FechaModificacion).HasColumnName("Fec_Usu_Modi");
            Property(p => p.UsuarioCreacion).HasColumnName("Cod_Usu_Regi");
            Property(p => p.UsuarioModificacion).HasColumnName("Cod_Usu_Modi");
        }
    }
}