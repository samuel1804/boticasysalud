namespace Pe.ByS.ERP.Presentacion.Core
{
    public class ViewerOptions
    {
        public ViewerOptions()
        {
            GetReportSnapshot = "GetReportSnapshot";
            ViewerEvent = "ViewerEvent";
            PrintReport = "PrintReport";
            ExportReport = "ExportReport";
            Interaction = "Interaction";
        }

        public string Controller { get; set; }
        public string GetReportSnapshot { get; set; }
        public string ViewerEvent { get; set; }
        public string PrintReport { get; set; }
        public string ExportReport { get; set; }
        public string Interaction { get; set; }
        public string Parameters { get; set; }
    }
}