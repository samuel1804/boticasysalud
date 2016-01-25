using System.Collections.Generic;
using Pe.ByS.ERP.Domain.Core;

namespace Pe.ByS.ERP.Domain
{
    public class Sucursal : EntityAuditable<int>
    {
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Distrito { get; set; }
        public string Telefono { get; set; }
        public string Encargado { get; set; }

        public virtual ICollection<Almacen> AlmacenList { get; set; }
    }
}