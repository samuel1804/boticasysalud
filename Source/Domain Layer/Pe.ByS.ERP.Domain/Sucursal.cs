using System.Collections.Generic;
using Pe.ByS.ERP.Domain.Core;

namespace Pe.ByS.ERP.Domain
{
    public class Sucursal : EntityAuditable<int>
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Almacen> AlmacenList { get; set; }
    }
}