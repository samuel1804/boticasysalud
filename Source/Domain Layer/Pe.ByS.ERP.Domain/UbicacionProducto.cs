using Pe.ByS.ERP.Domain.Core;

namespace Pe.ByS.ERP.Domain
{
    public class UbicacionProducto : EntityAuditable<int>
    {
        public int AlmacenId { get; set; }
        public int ProductoId { get; set; }
        public string Lote { get; set; }
        public int Cantidad { get; set; }
        public string Modulo { get; set; }
        public int Columna { get; set; }
        public int Fila { get; set; }

        public virtual Almacen Almacen { get; set; }
        public virtual Producto Producto { get; set; }
    }
}