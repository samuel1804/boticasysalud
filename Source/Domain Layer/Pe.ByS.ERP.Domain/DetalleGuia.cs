using Pe.ByS.ERP.Domain.Core;

namespace Pe.ByS.ERP.Domain
{
    public class DetalleGuia : EntityAuditable<int>
    {
        public int Cantidad { get; set; }
        public string ProductoId { get; set; }
        public int GuiaRemisionId { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual GuiaRemision GuiaRemision { get; set; }
    }
}