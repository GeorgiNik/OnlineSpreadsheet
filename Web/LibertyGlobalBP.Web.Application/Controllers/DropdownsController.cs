namespace LibertyGlobalBP.Web.Application.Controllers
{
    using Data.Services.Contracts;
    using System.Web.Mvc;

    public class DropdownsController : BaseController
    {
        private IDropdownService dropdowns;

        public DropdownsController(IDropdownService d)
        {
            this.dropdowns = d;
        }

        public JsonResult EntityStates()
        {
            return this.Json(this.dropdowns.EntityStates(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Users()
        {
            return this.Json(this.dropdowns.Users(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Folders()
        {
            return this.Json(this.dropdowns.Folders(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UserRoles()
        {
            return this.Json(this.dropdowns.UserRoles(), JsonRequestBehavior.AllowGet);
        }
    }
}