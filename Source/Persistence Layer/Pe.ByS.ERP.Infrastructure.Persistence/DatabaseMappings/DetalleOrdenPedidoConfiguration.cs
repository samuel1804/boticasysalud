using System.Data.Entity.ModelConfiguration;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Infrastructure.Persistence.DatabaseMappings
{
    public class DetalleOrdenPedidoConfiguration : EntityTypeConfiguration<DetalleOrdenPedido>
    {
        public DetalleOrdenPedidoConfiguration()
        {
            ToTable("RYA_PEDIDO_DET");

            Property(p => p.ProductoId).HasColumnName("Cod_Producto");
            Property(p => p.OrdenPedidoId).HasColumnName("NumPedido");
            Property(p => p.Cantidad).HasColumnName("Cant");
            Property(p => p.UnidadMedida).HasMaxLength(3);
            Property(p => p.CantidadAprobada).HasColumnName("Cant_Aprob");
            Property(p => p.CantidadAtendida).HasColumnName("Cant_Atendida");
            Property(p => p.Observacion).HasMaxLength(120).HasColumnName("Obs");

            HasRequired(p => p.Producto).WithMany().HasForeignKey(p => p.ProductoId);
            HasRequired(p => p.OrdenPedido).WithMany(p => p.DetalleOrdenPedidoList).HasForeignKey(p => p.OrdenPedidoId);
        }
    }
}