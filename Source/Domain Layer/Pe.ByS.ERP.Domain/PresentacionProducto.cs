using Pe.ByS.ERP.Domain.Core;

namespace Pe.ByS.ERP.Domain
{
    public class PresentacionProducto : EntityAuditable<int>
    {
        public string Descripcion { get; set; }
    }
}