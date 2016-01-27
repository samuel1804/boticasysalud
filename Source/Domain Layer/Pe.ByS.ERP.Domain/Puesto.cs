using Pe.ByS.ERP.Domain.Core;

namespace Pe.ByS.ERP.Domain
{
    public class Puesto : EntityAuditable<int>
    {
        public string Nombre { get; set; }
        public int AreaId { get; set; }
        public int Estado { get; set; }

        public virtual Area Area { get; set; }
    }
}