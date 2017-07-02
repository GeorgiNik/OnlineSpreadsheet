namespace LibertyGlobalBP.Web.Application
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            JavascriptLibraries(bundles);

            Styles(bundles);

            BundleTable.EnableOptimizations = false;
        }

        private static void JavascriptLibraries(BundleCollection bundles)
        {
            JQuery(bundles);
            Bootstrap(bundles);
            Kendo(bundles);
            Moment(bundles);
            Custom(bundles);
        }

        private static void Custom(BundleCollection bundles)
        {
            KendoCustomFunctions(bundles);

            bundles.Add(new ScriptBundle("~/bundles/extensions").Include(
                "~/Scripts/Custom/Shared/extensions.js"));

            bundles.Add(new ScriptBundle("~/bundles/rolesIndex").Include(
                "~/Scripts/Custom/UserRoles/rolesIndex.js"));

            bundles.Add(new ScriptBundle("~/bundles/usersIndex").Include(
                "~/Scripts/Custom/Users/usersIndex.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendoGridFunctions").Include(
                "~/Scripts/Custom/Shared/kendoGridFunctions.js"));

            bundles.Add(new ScriptBundle("~/bundles/inlineValidation").Include(
                "~/Scripts/Custom/Shared/inlineValidation.js"));

            bundles.Add(new ScriptBundle("~/bundles/navigation").Include(
                "~/Scripts/Custom/Shared/navigation.js"));

            bundles.Add(new ScriptBundle("~/bundles/modalValidation").Include(
                "~/Scripts/Custom/Shared/modalValidation.js"));

            bundles.Add(new ScriptBundle("~/bundles/printList").Include(
                "~/Scripts/Custom/Shared/printList.js"));

            bundles.Add(new ScriptBundle("~/bundles/projectFilesIndex").Include(
               "~/Scripts/Custom/ProjectFiles/projectFilesIndex.js"));

        }

        private static void KendoCustomFunctions(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/popupGridFunctionBinding").Include(
                "~/Scripts/Custom/Shared/popupGridFunctionBinding.js"));

            bundles.Add(new ScriptBundle("~/bundles/inlineGridFunctionBinding").Include(
                "~/Scripts/Custom/Shared/inlineGridFunctionBinding.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendoGridSecondFunctions").Include(
                "~/Scripts/Custom/Shared/kendoGridSecondFunctions.js"));

            bundles.Add(new ScriptBundle("~/bundles/secondGridFunctionBinding").Include(
                "~/Scripts/Custom/Shared/secondGridFunctionBinding.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendoGridThirdFunctions").Include(
                "~/Scripts/Custom/Shared/kendoGridThirdFunctions.js"));

            bundles.Add(new ScriptBundle("~/bundles/thirdGridFunctionBinding").Include(
                "~/Scripts/Custom/Shared/thirdGridFunctionBinding.js"));

            bundles.Add(new ScriptBundle("~/bundles/deleteSecondGeneric").Include(
                "~/Scripts/Custom/Shared/deleteSecondGeneric.js"));

            bundles.Add(new ScriptBundle("~/bundles/deleteThirdGeneric").Include(
                "~/Scripts/Custom/Shared/deleteThirdGeneric.js"));

            bundles.Add(new ScriptBundle("~/bundles/multipleDelete").Include(
                "~/Scripts/Custom/Shared/multipleDelete.js"));

            bundles.Add(new ScriptBundle("~/bundles/multipleDeleteSecond").Include(
                "~/Scripts/Custom/Shared/multipleDeleteSecond.js"));
        }

        private static void JQuery(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/Libraries/JQuery/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/Libraries/JQuery/jquery.validate.js",
                "~/Scripts/Libraries/JQuery/jquery.validate.unobtrusive.js",
                "~/Scripts/Libraries/JQuery/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/Libraries/Kendo/jquery.min.js"));
        }

        private static void Bootstrap(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modals").Include(
                "~/Scripts/Custom/Shared/modals.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/Libraries/Bootstrap/bootstrap.js",
                "~/Scripts/Libraries/Bootstrap/respond.js"));
        }

        private static void Kendo(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/kendoGridTitle").Include(
                "~/Scripts/Custom/Shared/kendoGridTitle.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                "~/Scripts/Libraries/Kendo/kendo.web.min.js",
                "~/Scripts/Libraries/Kendo/kendo.aspnetmvc.min.js",
                "~/Scripts/Libraries/Kendo/kendo.angular.min.js",
                "~/Scripts/Libraries/Kendo/cultures/kendo.culture.en-GB.min.js",
                "~/Scripts/Libraries/Kendo/kendoCulture.js"));
        }

        private static void Moment(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
               "~/Scripts/Libraries/moment.js"));
        }

        private static void Styles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/emails").Include(
                "~/Content/emails.css"));

            bundles.Add(new StyleBundle("~/Content/outlookSpecific").Include(
                "~/Content/outlookSpecific.css"));

            bundles.Add(new StyleBundle("~/Content/jqueryui").Include(
                "~/Content/jquery-ui.css",
                "~/Content/jquery-ui.structure.css",
                "~/Content/jquery-ui.theme.css"));

            bundles.Add(new StyleBundle("~/Content/pagedList").Include(
                "~/Content/PagedList.css"));

            bundles.Add(new StyleBundle("~/Content/fontAwesome").Include(
                "~/Content/font-awesome.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/layout.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/Kendo/css").Include(
                "~/Content/Kendo/kendo.common.min.css",
                "~/Content/Kendo/kendo.bootstrap.min.css",
                "~/Content/kendo.custom.css",
                "~/Content/kendo.css"));
        }
    }
}
