using Pe.ByS.ERP.Domain.Core;

namespace Pe.ByS.ERP.Domain
{
    public class Tienda : EntityAuditable<int>
    {
        public string CodigoTienda { get; set; }
        public string Direccion { get; set; }
    }
}