using System.Web;
using System.Web.Optimization;

namespace WebBS.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/bootbox.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/nuevaConstancia").Include(
                        "~/Scripts/ALP/NuevaConstancia.js"));

            bundles.Add(new ScriptBundle("~/bundles/IndexConstancia").Include(
                        "~/Scripts/ALP/IndexConstancia.js"));
        }
    }
}