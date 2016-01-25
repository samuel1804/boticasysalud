using Pe.ByS.ERP.Domain.Core;

namespace Pe.ByS.ERP.Domain
{
    public class Almacen : EntityAuditable<int>
    {
        public string Descripcion { get; set; }
        public int SucursalId { get; set; }
        public string Encargado { get; set; }

        public virtual Sucursal Sucursal { get; set; }
    }
}