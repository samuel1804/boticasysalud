namespace Pe.ByS.ERP.CrossCutting.Common.JQGrid
{
    public class JQgridGeneric<T>
    {
        public int total { get; set; }

        public int page { get; set; }

        public int records { get; set; }

        public int start { get; set; }

        public RowGeneric<T>[] rows { get; set; }
    }
}
