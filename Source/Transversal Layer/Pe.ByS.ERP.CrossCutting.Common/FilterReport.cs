using System.Collections.Generic;
using Pe.ByS.ERP.CrossCutting.Common.JQGrid;

namespace Pe.ByS.ERP.CrossCutting.Common
{
    public class FilterReport
    {
        public string Formato { get; set; }
        public string Filters { get; set; }
        public List<Rule> Rules { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int ImpresoraId { get; set; }
        public string ImpresoraNombre { get; set; }
        public int TipoReporte { get; set; }
        public string Mes { get; set; }
    }
}
