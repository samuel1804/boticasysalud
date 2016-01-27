using System.Data.Entity.ModelConfiguration;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Infrastructure.Persistence.DatabaseMappings
{
    public class AlmacenConfiguration : EntityTypeConfiguration<Almacen>
    {
        public AlmacenConfiguration()
        {
            ToTable("RYA_ALMACENES");

            Property(p => p.Id).HasColumnName("Cod_Almacen");
            Property(p => p.Descripcion).IsRequired().HasMaxLength(100);
            Property(p => p.SucursalId).HasColumnName("Cod_Sucursal");
            Property(p => p.Encargado).HasMaxLength(100);
            Property(p => p.FechaCreacion).HasColumnName("Fec_Usu_Regi");
            Property(p => p.FechaModificacion).HasColumnName("Fec_Usu_Modi");
            Property(p => p.UsuarioCreacion).HasColumnName("Cod_Usu_Regi");
            Property(p => p.UsuarioModificacion).HasColumnName("Cod_Usu_Modi");

            HasRequired(p => p.Sucursal).WithMany(p => p.AlmacenList).HasForeignKey(p => p.SucursalId);
        }
    }
}