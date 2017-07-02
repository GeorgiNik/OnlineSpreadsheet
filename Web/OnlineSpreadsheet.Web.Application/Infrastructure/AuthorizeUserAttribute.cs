namespace OnlineSpreadsheet.Web.Application.Infrastructure
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using OnlineSpreadsheet.Data.Common;
    using OnlineSpreadsheet.Data.Models;

    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        public AccessRequest AccessRequest { get; set; }

        public AccessRequest SecondAccessRequest { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }

            var users = new DeletableRepository<ApplicationUser>(new ApplicationDbContext());

            var usr = users.FirstOrDefault(u => u.Email.ToLower() == httpContext.User.Identity.Name.ToLower());

            var first = usr.HasAccess(this.AccessRequest);
            var second = usr.HasAccess(this.SecondAccessRequest);
            return first || second;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var isAuthorized = base.AuthorizeCore(filterContext.HttpContext);

            if (!isAuthorized)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                new
                {
                    controller = "Account",
                    action = "Login",
                }));
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                new
                {
                    controller = "Home",
                    action = "Index",
                }));
            }
        }
    }
}