using System.Web;
using System.Web.Optimization;

namespace WebBS.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                           "~/Content/themes/base/jquery.ui.core.css",
                           "~/Content/themes/base/jquery.ui.resizable.css",
                           "~/Content/themes/base/jquery.ui.selectable.css",
                           "~/Content/themes/base/jquery.ui.accordion.css",
                           "~/Content/themes/base/jquery.ui.autocomplete.css",
                           "~/Content/themes/base/jquery.ui.button.css",
                           "~/Content/themes/base/jquery.ui.dialog.css",
                           "~/Content/themes/base/jquery.ui.slider.css",
                           "~/Content/themes/base/jquery.ui.tabs.css",
                           "~/Content/themes/base/jquery.ui.datepicker.css",
                           "~/Content/themes/base/jquery.ui.progressbar.css",
                           "~/Content/themes/base/jquery.ui.theme.css"));
        
        
        }
    }
}