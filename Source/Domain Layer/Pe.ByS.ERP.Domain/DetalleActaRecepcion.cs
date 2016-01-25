using Pe.ByS.ERP.Domain.Core;

namespace Pe.ByS.ERP.Domain
{
    public class DetalleActaRecepcion : EntityAuditable<int>
    {
        public int Cantidad { get; set; }
        public int Diferencia { get; set; }
        public string Observacion { get; set; }
        public string ProductoId { get; set; }
        public int ActaRecepcionId { get; set; }
        public string Lote { get; set; }
        public string UnidadMedida { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual ActaRecepcion ActaRecepcion { get; set; }
    }
}