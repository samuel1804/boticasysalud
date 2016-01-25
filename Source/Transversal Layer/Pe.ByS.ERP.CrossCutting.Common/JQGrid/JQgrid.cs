namespace Pe.ByS.ERP.CrossCutting.Common.JQGrid
{
    public class JQgrid
    {
        public int total { get; set; }

        public int page { get; set; }

        public int records { get; set; }

        public int start { get; set; }

        public Row[] rows { get; set; }
    }
}