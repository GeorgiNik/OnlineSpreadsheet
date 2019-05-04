namespace OnlineSpreadsheet.Web.Application
{
    using ModelBinders;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using OnlineSpreadsheet.Data.Models;
    using ViewModels.Infrastructure;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(string), new TrimModelBinder());

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var automapperConfig = new AutoMapperConfig();
            automapperConfig.Execute();
        }
    }
}
