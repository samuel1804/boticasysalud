using System.Data.Entity.ModelConfiguration;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Infrastructure.Persistence.DatabaseMappings
{
    public class OrdenPedidoConfiguration : EntityTypeConfiguration<OrdenPedido>
    {
        public OrdenPedidoConfiguration()
        {
            ToTable("RYA_PEDIDO_CAB");

            Property(p => p.Estado).HasMaxLength(1).IsRequired();
            Property(p => p.SucursalId).HasColumnName("Cod_Sucursal");
            Property(p => p.NumeroPedido).IsRequired().HasColumnName("NumPedido");
            Property(p => p.SolicitanteId).HasColumnName("CodSolicitante");
            Property(p => p.Glosa).IsOptional().HasMaxLength(200);
            Property(p => p.FechaPedido).HasColumnName("FchPedido");
            Property(p => p.FechaEntrega).HasColumnName("FchEntrega");

            HasRequired(p => p.Solicitante).WithMany().HasForeignKey(p => p.SolicitanteId).WillCascadeOnDelete(false);
            HasRequired(p => p.Sucursal).WithMany().HasForeignKey(p => p.SucursalId).WillCascadeOnDelete(false);
        }
    }
}