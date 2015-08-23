using System.Web;
using System.Web.Optimization;

namespace RampedUp.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            const string appRoot = "~/Client/scripts/app/";
            const string vendorRoot = "~/Client/scripts/vendors/";
            const string cssRoot = "~/Client/css/";

            bundles.Add(new ScriptBundle("~/bundles/app")
               .Include(
                   appRoot + "app.js"
                )
                .IncludeDirectory(
                   appRoot + "config", "*.js", true
                )
                .IncludeDirectory(
                   appRoot + "directives", "*.js", true
                )
                .IncludeDirectory(
                   appRoot + "services", "*.js", true
                )
                .IncludeDirectory(
                   appRoot + "filters", "*.js", true
                )
                .IncludeDirectory(
                   appRoot + "resources", "*.js", true
                )
                .IncludeDirectory(
                   appRoot + "controllers/app", "*.js", true
                )
                .Include(
                    appRoot + "main.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include(vendorRoot + "jquery/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular")
               .Include(
                    vendorRoot + "angular/angular.js",
                    vendorRoot + "angular-animate/angular-animate.js",
                    vendorRoot + "angular-cookies/angular-cookies.js",
                    vendorRoot + "angular-resource/angular-resource.js",
                    vendorRoot + "angular-sanitize/angular-sanitize.js",
                    vendorRoot + "angular-touch/angular-touch.js",
                    vendorRoot + "angular-ui-router/release/angular-ui-router.js",
                    vendorRoot + "ngstorage/ngStorage.js",
                    vendorRoot + "angular-ui-utils/ui-utils.js",
                    vendorRoot + "angular-strap/dist/angular-strap.js",
                    vendorRoot + "angular-strap/dist/angular-strap.tpl.js",
                    vendorRoot + "oclazyload/ocLazyLoad.js",
                    vendorRoot + "angular-translate/angular-translate.js",
                    vendorRoot + "angular-translate-loader-static-files/angular-translate-loader-static-files.js",
                    vendorRoot + "angular-translate-storage-cookie/angular-translate-storage-cookie.js",
                    vendorRoot + "angular-translate-storage-local/angular-translate-storage-local.js",
                    vendorRoot + "angular-loading-bar/loading-bar.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/css")
                .Include(
                     cssRoot + "animate/animate.css",
                     cssRoot + "bootstrap/bootstrap.css",
                     cssRoot + "bootstrap-additions/bootstrap-additions.css",
                     cssRoot + "angular-motion/angular-motion.css",
                     cssRoot + "font-awesome/font-awesome.css",
                     cssRoot + "angular-loading-bar/loading-bar.css",
                     cssRoot + "themify-icons.css",
                     cssRoot + "font.css",
                     cssRoot + "app.css"
                 ));
        }
    }
}
