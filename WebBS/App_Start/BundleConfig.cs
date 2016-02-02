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

            bundles.Add(new ScriptBundle("~/bundles/ListaConstancia").Include(
                        "~/Scripts/ALP/ListaConstancia.js"));

            bundles.Add(new ScriptBundle("~/bundles/ListaConstanciaMerma").Include(
                        "~/Scripts/ALP/ListaConstanciaMerma.js"));

            bundles.Add(new ScriptBundle("~/bundles/ModificarConstancia").Include(
                        "~/Scripts/ALP/ModificarConstancia.js"));

            bundles.Add(new ScriptBundle("~/bundles/NuevoControlMerma").Include(
                        "~/Scripts/ALP/NuevoControlMerma.js"));

            bundles.Add(new ScriptBundle("~/bundles/ListaSolicitud").Include(
                        "~/Scripts/ALP/ListaSolicitud.js"));

            bundles.Add(new ScriptBundle("~/bundles/ListaConstanciaSolicitud").Include(
                        "~/Scripts/ALP/ListaConstanciaSolicitud.js"));

            bundles.Add(new ScriptBundle("~/bundles/NuevaSolicitud").Include(
                        "~/Scripts/ALP/NuevaSolicitud.js"));

            bundles.Add(new ScriptBundle("~/bundles/ModificarSolicitud").Include(
                        "~/Scripts/ALP/ModificarSolicitud.js"));

            bundles.Add(new ScriptBundle("~/bundles/ListaConstanciaLibroReceta").Include(
                        "~/Scripts/ALP/ListaConstanciaLibroReceta.js"));

            bundles.Add(new ScriptBundle("~/bundles/NuevoLibroReceta").Include(
                        "~/Scripts/ALP/NuevoLibroReceta.js"));
        }
    }
}