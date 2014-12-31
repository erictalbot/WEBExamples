using System.Web;
using System.Web.Optimization;

namespace ui_base
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Button.css",
                      "~/Content/Sections.css",
                      "~/Content/List_basic.css")); // Doit-être dans index et non pas dans layout. TODO

            bundles.Add(new StyleBundle("~/Content/css/ListJQXWithDetailPane").Include(
                    "~/Content/ListJQXWithDetailPaneResponsive.css"));

            bundles.Add(new StyleBundle("~/Content/css/jqwidgets").Include(
                    "~/Scripts/jqwidgets/styles/jqx.base.css",
                    "~/Scripts/jqwidgets/styles/jqx.metro.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqwidgets").Include(
                "~/Scripts/jqwidgets/jqx-all.js"));
        }
    }
}
