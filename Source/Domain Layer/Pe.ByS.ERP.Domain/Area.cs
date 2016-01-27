using Pe.ByS.ERP.Domain.Core;

namespace Pe.ByS.ERP.Domain
{
    public class Area : EntityAuditable<int>
    {
        public string Nombre { get; set; }
        public int Estado { get; set; }
    }
}