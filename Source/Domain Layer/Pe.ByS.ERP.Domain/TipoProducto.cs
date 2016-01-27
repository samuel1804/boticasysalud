using Pe.ByS.ERP.Domain.Core;

namespace Pe.ByS.ERP.Domain
{
    public class TipoProducto : EntityAuditable<int>
    {
        public string Descripcion { get; set; }
    }
}