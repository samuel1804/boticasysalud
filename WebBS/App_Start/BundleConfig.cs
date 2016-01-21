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

            bundles.Add(new StyleBundle("~/Content/cssControls").Include(
          "~/Scripts/Dialog/Dialog.css",
          "~/Scripts/Message/Message.css",
          "~/Scripts/ProgressBar/ProgressBar.css",
          "~/Scripts/jquery-ui-1.10.4.custom.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/Controls").Include(
                     "~/Scripts/Codemaleon/ns.js",
                     "~/Scripts/Dialog/Dialog.js",
                     "~/Scripts/Calendar/Calendar.js",
                     "~/Scripts/Message/Message.js",
                     "~/Scripts/Codemaleon/ns.js",
                     "~/Scripts/ProgressBar/ProgressBar.js",
                     "~/Scripts/Ajax/Ajax.js",
                      "~/Scripts/jquery.mask.min.js",
                      "~/Scripts/Util.js"));
        }
    }
}