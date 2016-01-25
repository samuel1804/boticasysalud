using System.Data.Entity.ModelConfiguration;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Infrastructure.Persistence.DatabaseMappings
{
    public class ActaRecepcionConfiguration : EntityTypeConfiguration<ActaRecepcion>
    {
        public ActaRecepcionConfiguration()
        {
            ToTable("RYA_ACTARECEP_CAB");

            Property(p => p.Id).HasColumnName("NumActa");
            Property(p => p.AlmacenId).HasColumnName("Cod_Almacen");
            Property(p => p.OrdenPedidoId).HasColumnName("NumPedido");
            Property(p => p.VerificadorId).HasColumnName("CodVerificador");
            Property(p => p.Glosa).IsOptional().HasMaxLength(200);
            Property(p => p.FechaCreacion).HasColumnName("Fec_Usu_Regi");
            Property(p => p.FechaModificacion).HasColumnName("Fec_Usu_Modi");
            Property(p => p.UsuarioCreacion).HasColumnName("Cod_Usu_Regi");
            Property(p => p.UsuarioModificacion).HasColumnName("Cod_Usu_Modi");

            //HasRequired(p => p.GuiaRemision).WithMany().HasForeignKey(p => p.GuiaRemisionId);
            HasRequired(p => p.Almacen).WithMany().HasForeignKey(p => p.AlmacenId);
            HasRequired(p => p.OrdenPedido).WithMany().HasForeignKey(p => p.OrdenPedidoId);
        }
    }
}