namespace LibertyGlobalBP.Web.Application.Controllers
{
    using Data.Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Utilities;

    [Authorize]
    public class HomeController : BaseController
    {
        private IDropdownService dropdowns;

        public HomeController(IDropdownService dd)
        {
            this.dropdowns = dd;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Admin(IndexPageVM vm)
        {
            if (vm.Page == null)
            {
                vm.Page = Section.UserRoles;
            }

            return this.View("Admin", vm);
        }
    }
}
