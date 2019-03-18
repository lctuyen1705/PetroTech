using System.Web.Optimization;

namespace PetroTech.Main
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Assets/admin/js").Include(
                        "~/Assets/admin/js/jquery-1.11.1.min.js",
                        "~/Assets/admin/js/bootstrap.min.js",
                        "~/Assets/admin/js/chart.min.js",
                        "~/Assets/admin/js/chart-data.js",
                        "~/Assets/admin/js/easypiechart.js",
                        "~/Assets/admin/js/easypiechart-data.js",
                        "~/Assets/admin/js/bootstrap-datepicker.js",
                        "~/Assets/admin/js/custom.js"));

            bundles.Add(new ScriptBundle("~/Assets/admin/libs").Include(
                        "~/Assets/admin/libs/angular/angular.js",
                        "~/Assets/admin/libs/angular-translate/angular-translate.js",
                        "~/Assets/admin/libs/angular-translate-loader-static-files/angular-translate-loader-static-files.js",
                        "~/Assets/admin/libs/toastr/toastr.js",
                        "~/Assets/admin/libs/angular-ui-bootstrap/src/modal.js",
                        "~/Assets/admin/libs/angularjs-datetime-picker/angularjs-datetime-picker.js",
                        "~/Assets/admin/libs/angular-animate/angular-animate.js",
                        "~/Assets/admin/libs/angular-route/angular-route.js",
                        "~/Assets/admin/libs/angular-ui-router/release/angular-ui-router.js"));

            //modules
            bundles.Add(new ScriptBundle("~/app/components/modules").Include(
                    "~/app/components/modules/role.module.js",
                    "~/app/components/modules/dashboard.module.js",
                    "~/app/components/modules/user.module.js"));

            //filter
            bundles.Add(new ScriptBundle("~/app/shared/filter").Include(
                    "~/app/shared/filter/statusFilter.js"));

            //service
            bundles.Add(new ScriptBundle("~/app/shared/services").Include(
                    "~/app/shared/services/notificationService.js",
                    "~/app/shared/services/apiservice.js"));

            //user
            bundles.Add(new ScriptBundle("~/app/components/users").Include(
                        "~/app/components/users/userAddController.js",
                        "~/app/components/users/_userController.js",
                        "~/app/components/users/userEditController.js"));

            //role
            bundles.Add(new ScriptBundle("~/app/components/roles").Include(
                        "~/app/components/roles/roleAddController.js",
                        "~/app/components/roles/roleEditController.js",
                        "~/app/components/roles/_roleController.js"));
            //home
            bundles.Add(new ScriptBundle("~/app/components/home").Include(
               "~/app/components/home/homeController.js"));

            //dashboard
            //bundles.Add(new ScriptBundle("~/app/components/dashboard").Include(
            //   "~/app/components/dashboard/dashboardController.js"));

            //directive
            bundles.Add(new ScriptBundle("~/app/shared/directives").Include(
              "~/app/shared/directives/pagerDirective.js"));

            //modal
            bundles.Add(new ScriptBundle("~/app/shared/modal").Include(
              "~/app/shared/modal/modalController.js"));

            bundles.Add(new ScriptBundle("~/app/shared/modules").Include(
                       "~/app/shared/modules/petrotech.common.js"));

            bundles.Add(new ScriptBundle("~/app").Include(
                       "~/app/app.js"));

            bundles.Add(new StyleBundle("~/Assets/admin/css").Include(
                      "~/Assets/admin/css/bootstrap.min.css",
                      "~/Assets/admin/css/font-awesome.min.css",
                      "~/Assets/admin/css/datepicker3.css",
                      "~/Assets/admin/libs/toastr/toastr.css",
                      "~/Assets/admin/libs/angularjs-datetime-picker/angularjs-datetime-picker.css",
                      "~/Assets/admin/css/styles.css"));
        }
    }
}