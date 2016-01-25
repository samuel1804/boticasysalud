using System.Collections.Generic;

namespace Pe.ByS.ERP.CrossCutting.Common.JQGrid
{
    public class Filter
    {
        public string groupOp { get; set; }

        public List<Rule> rules { get; set; }

        public List<Filter> groups { get; set; }
    }
}