namespace OnlineSpreadsheet.Web.Application.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using OnlineSpreadsheet.Data.Models;
    using OnlineSpreadsheet.Data.Services.Contracts;
    using OnlineSpreadsheet.Localization.Resources;
    using OnlineSpreadsheet.Web.Application.Infrastructure;
    using OnlineSpreadsheet.Web.Application.Utilities;
    using OnlineSpreadsheet.Web.ViewModels.UserRoles;

    [AuthorizeUser(AccessRequest = AccessRequest.UserRolesEdit)]
    public class UserRolesController : BaseController
    {
        private readonly IUserRoleService roles;

        public UserRolesController(IUserRoleService r)
        {
            this.roles = r;
        }

        [AuthorizeUser(AccessRequest = AccessRequest.UserRolesRead)]
        public ActionResult Index()
        {
            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView();
            }
            return this.RedirectToAction("Admin", "Home", new IndexPageVM(Section.UserRoles));
        }

        public ActionResult UserRoles_Read([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.roles.GetAll().ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UserRoles_Destroy([DataSourceRequest]DataSourceRequest request, UserRoleVM userRole)
        {
            if (this.roles.UsersInRole(userRole.ID))
            {
                this.ModelState.AddModelError(string.Empty, Resources.UsersInRole);
            }

            if (this.ModelState.IsValid)
            {
                this.roles.Delete(userRole.ID);
            }

            return this.Json(new[] { userRole }.ToDataSourceResult(request, this.ModelState));
        }

        public ActionResult Create()
        {
            return this.PartialView("_Create", new UserRoleVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserRoleVM vm)
        {
            if (this.ModelState.IsValid)
            {
                vm.ID = this.roles.Add(vm).ID;
                return null;
            }

            var errors = this.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            return this.ValidationError(errors);
        }

        public ActionResult Edit(int id)
        {
            return this.PartialView("_Edit", this.roles.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserRoleVM vm)
        {
            if (this.ModelState.IsValid)
            {
                this.roles.Update(vm);
                return null;
            }

            var errors = this.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            return this.ValidationError(errors);
        }
    }
}
