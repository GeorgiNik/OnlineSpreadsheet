namespace LibertyGlobalBP.Web.Application.Emails.Services
{
    using System.IO;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class ViewToString
    {
        public static string Render(string controllerName, string viewName, object viewData)
        {
            using (var writer = new StringWriter())
            {
                var routeData = new RouteData();
                routeData.Values.Add("controller", controllerName);
                var fakeControllerContext = new ControllerContext(new HttpContextWrapper(new HttpContext(new HttpRequest(null, "http://google.com", null), new HttpResponse(null))), routeData, new FakeController());
                var razorViewEngine = new RazorViewEngine();
                var razorViewResult = razorViewEngine.FindView(fakeControllerContext, viewName, string.Empty, false);

                var viewContext = new ViewContext(fakeControllerContext, razorViewResult.View, new ViewDataDictionary(viewData), new TempDataDictionary(), writer);
                razorViewResult.View.Render(viewContext, writer);
                return writer.ToString();
            }
        }
    }

    // Used for the method above, approach by http://stackoverflow.com/questions/23494741/mvc-5-render-view-to-string
    public class FakeController : ControllerBase
    {
        protected override void ExecuteCore()
        {
        }
    }
}