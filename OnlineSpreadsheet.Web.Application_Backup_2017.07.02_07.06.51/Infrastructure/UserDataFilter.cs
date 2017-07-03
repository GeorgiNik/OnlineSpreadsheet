namespace OnlineSpreadsheet.Web.Application.Infrastructure
{
    using System.Web.Mvc;
    using OnlineSpreadsheet.Data.Common;
    using OnlineSpreadsheet.Data.Models;

    public class UserDataFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var user = filterContext.HttpContext.User;

            if (user.Identity.IsAuthenticated == true)
            {
                var users = new DeletableRepository<ApplicationUser>(new ApplicationDbContext());

                var usr = users.FirstOrDefault(u => u.Email == user.Identity.Name.ToLower());
                if (usr != null)
                {
                    var viewBag = filterContext.Controller.ViewBag;

                    viewBag.User = usr;
                }
            }
        }
    }
}