using System.Web;
using System.Web.Optimization;

namespace InventarioTI.Presentacion
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.dataTables.min.js",
                        //"~/Scripts/bootbox.js",
                        "~/Scripts/jquery.form.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/assets/css").Include(
                      "~/Content/assets/css/bootstrap.min.css",
                      "~/Content/assets/css/pixeladmin.min.css",
                      "~/Content/assets/css/widgets.min.css",
                      "~/Content/assets/css/themes/frost.min.css"));

            bundles.Add(new ScriptBundle("~/Content/assets/js").Include("" +
                      "~/Content/assets/js/bootstrap.min.js",
                      "~/Content/assets/js/pixeladmin.min.js",
                      "~/Content/assets/pace/pace.min.js"));
        }
    }
}
