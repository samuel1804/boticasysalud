using Pe.ByS.ERP.Domain.Core;

namespace Pe.ByS.ERP.Domain
{
    public class Producto : EntityAuditable<int>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int TipoProductoId { get; set; }
        public int PresentacionId { get; set; }
        public decimal? Peso { get; set; }
        public string UnidadMedida { get; set; }
        public int Estado { get; set; }

        public virtual PresentacionProducto Presentacion { get; set; }
        public virtual TipoProducto TipoProducto { get; set; }
    }
}