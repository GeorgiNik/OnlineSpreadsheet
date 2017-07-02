namespace LibertyGlobalBP.Web.Application.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using LibertyGlobalBP.Web.Application.Infrastructure;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System.Threading;
    using System.Globalization;
    [UserDataFilter]
    public class BaseController : Controller
    {
        public List<string> AllowedImageExtensions = new List<string> { ".jpg", ".png", ".jpeg", ".gif", ".bmp" };

        public ActionResult ValidationError(List<string> errors)
        {
            this.Response.TrySkipIisCustomErrors = true;
            this.Response.StatusCode = (int)HttpStatusCode.Conflict;
            return this.PartialView(Views.ValidationError, errors.Distinct());
        }

        public ActionResult ValidationError(string error)
        {
            var errors = new List<string> { error };
            this.Response.TrySkipIisCustomErrors = true;
            this.Response.StatusCode = (int)HttpStatusCode.Conflict;
            return this.PartialView(Views.ValidationError, errors);
        }

        public ActionResult CustomJson(object content)
        {
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), NullValueHandling = NullValueHandling.Ignore };
            var json = JsonConvert.SerializeObject(content, Formatting.Indented, jsonSerializerSettings);

            return this.Content(json, "application/json");
        }

        //protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        //{
        //    Thread.CurrentThread.CurrentCulture =
        //        Thread.CurrentThread.CurrentUICulture =
        //            new CultureInfo("en-GB");

        //    base.Initialize(requestContext);
        //}
    }
}