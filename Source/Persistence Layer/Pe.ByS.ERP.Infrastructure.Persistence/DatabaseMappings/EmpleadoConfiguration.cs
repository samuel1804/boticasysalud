using System.Data.Entity.ModelConfiguration;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Infrastructure.Persistence.DatabaseMappings
{
    public class EmpleadoConfiguration : EntityTypeConfiguration<Empleado>
    {
        public EmpleadoConfiguration()
        {
            ToTable("RRH_Empleado");

            Property(p => p.Id).HasColumnName("Cod_Empleado");
            Property(p => p.Nombre).HasMaxLength(50).HasColumnName("Nom_Empleado");
            Property(p => p.ApellidoPaterno).HasMaxLength(50).HasColumnName("Ap_Paterno");
            Property(p => p.ApellidoMaterno).HasMaxLength(50).HasColumnName("Ap_Materno");
            Property(p => p.Dni).HasMaxLength(50);
            Property(p => p.Telefono).HasMaxLength(12);
            Property(p => p.Direccion).HasMaxLength(150);
            Property(p => p.Foto).HasMaxLength(50);
            Property(p => p.PuestoId).HasColumnName("Cod_Puesto");
            Property(p => p.FechaIngreso).HasColumnName("Fec_Ingreso");
            Property(p => p.FechaCreacion).HasColumnName("Fec_Usu_Regi");
            Property(p => p.FechaModificacion).HasColumnName("Fec_Usu_Modi");
            Property(p => p.UsuarioCreacion).HasColumnName("Cod_Usu_Regi");
            Property(p => p.UsuarioModificacion).HasColumnName("Cod_Usu_Modi");

            HasRequired(p => p.Puesto).WithMany().HasForeignKey(p => p.PuestoId);
        }
    }
}