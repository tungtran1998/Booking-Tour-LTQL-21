using System.Web;
using System.Web.Optimization;

namespace Booking_Tour
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/popper.min.js",
                      "~/Scripts/custom/jquery.min.js",
                      "~/Scripts/custom/jquery.easing.1.3.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/custom/jquery.waypoints.min.js",
                      "~/Scripts/custom/jquery.flexslider-min.js",
                      "~/Scripts/custom/owl.carousel.min.js",
                      "~/Scripts/custom/jquery.magnific-popup.min.js",
                      "~/Scripts/custom/magnific-popup-options.js",
                      "~/Scripts/custom/bootstrap-datepicker.js",
                      "~/Scripts/custom/jquery.stellar.min.js",
                      "~/Scripts/custom/main.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/home/animate.css",
                      "~/Content/css/home/icomoon.css",
                      "~/Content/css/bootstrap/bootstrap.min.css",
                      "~/Content/css/home/magnific-popup.css",
                      "~/Content/css/home/flexslider.css",
                      "~/Content/css/home/owl.carousel.min.css",
                      "~/Content/css/home/owl.theme.default.min.css",
                      "~/Content/css/home/bootstrap-datepicker.css",
                      "~/Content/css/fonts/flaticon/flaticon.css",
                      "~/Content/css/home/style.css",
                      "~/Content/fontawesome-all.min.css"));
        }
    }
}
