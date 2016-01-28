using System.Data.Entity.ModelConfiguration;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Infrastructure.Persistence.DatabaseMappings
{
    public class SucursalConfiguration : EntityTypeConfiguration<Sucursal>
    {
        public SucursalConfiguration()
        {
            ToTable("RRH_Sucursal");

            Property(p => p.Id).HasColumnName("Cod_Sucursal");
            Property(p => p.Nombre).IsRequired().HasMaxLength(50).HasColumnName("Nom_Sucursal");
            Property(p => p.Direccion).HasMaxLength(200);
            Property(p => p.FechaCreacion).HasColumnName("Fec_Usu_Regi");
            Property(p => p.FechaModificacion).HasColumnName("Fec_Usu_Modi");
            Property(p => p.UsuarioCreacion).HasColumnName("Cod_Usu_Regi");
            Property(p => p.UsuarioModificacion).HasColumnName("Cod_Usu_Modi");
        }
    }
}