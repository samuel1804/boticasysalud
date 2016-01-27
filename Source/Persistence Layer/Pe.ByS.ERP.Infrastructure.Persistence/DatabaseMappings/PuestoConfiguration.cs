using System.Data.Entity.ModelConfiguration;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Infrastructure.Persistence.DatabaseMappings
{
    public class PuestoConfiguration : EntityTypeConfiguration<Puesto>
    {
        public PuestoConfiguration()
        {
            ToTable("RRH_Puesto");

            Property(p => p.Id).HasColumnName("Cod_Puesto");
            Property(p => p.Nombre).HasMaxLength(50).HasColumnName("Nom_Puesto");
            Property(p => p.AreaId).HasColumnName("Cod_Area");
            Property(p => p.FechaCreacion).HasColumnName("Fec_Usu_Regi");
            Property(p => p.FechaModificacion).HasColumnName("Fec_Usu_Modi");
            Property(p => p.UsuarioCreacion).HasColumnName("Cod_Usu_Regi");
            Property(p => p.UsuarioModificacion).HasColumnName("Cod_Usu_Modi");

            HasRequired(p => p.Area).WithMany().HasForeignKey(p => p.AreaId);
        }
    }
}