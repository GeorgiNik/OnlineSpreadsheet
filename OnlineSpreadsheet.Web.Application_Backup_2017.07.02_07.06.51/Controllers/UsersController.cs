namespace OnlineSpreadsheet.Web.Application.Controllers
{
    using System.Configuration;
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using OnlineSpreadsheet.Data.Models;
    using OnlineSpreadsheet.Data.Services.Contracts;
    using OnlineSpreadsheet.Localization.Resources;
    using OnlineSpreadsheet.Web.Application.Emails.Services;
    using OnlineSpreadsheet.Web.Application.Infrastructure;
    using OnlineSpreadsheet.Web.ViewModels.Users;

    [AuthorizeUser(AccessRequest = AccessRequest.UsersEdit)]
    public class UsersController : BaseController
    {
        private readonly IUserService users;
        private readonly IDropdownService dropdowns;


        public UsersController(IDropdownService d, IUserService u)
        {
            this.dropdowns = d;
            this.users = u;
        }

        public ActionResult Index()
        {
            var vm = new IndexVM(this.dropdowns.UserRoles().FirstOrDefault()?.ID);
            return this.View(vm);
        }



        public ActionResult Users_Read([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.users.GetAll().ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Destroy([DataSourceRequest]DataSourceRequest request, UserVM user)
        {
            if (this.ModelState.IsValid)
            {
                this.users.Delete(user);
            }

            return this.Json(new[] { user }.ToDataSourceResult(request, this.ModelState));
        }

        public ActionResult Create()
        {
            return this.PartialView("_Create", new UserVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserVM vm)
        {
            if (!string.IsNullOrWhiteSpace(vm.Phone) && vm.Phone.Any(x => char.IsLetter(x)))
            {
                this.ModelState.AddModelError(string.Empty, Resources.InvalidPhoneNumber);
            }

            if (this.users.Exists(vm.Email))
            {
                this.ModelState.AddModelError(string.Empty, Resources.UserExists);
            }

            if (this.ModelState.IsValid)
            {
                var registered = this.users.Add(vm);

                vm.Id = registered.Id;


                string callbackUrl = ConfigurationManager.AppSettings["SystemLink"] + $"/Account/ResetPassword?userId={registered.Id}&code={registered.PasswordResetToken}";

                AccountEmails.SendPasswordResetOnAccCreation(vm, callbackUrl);
                return null;
            }

            var errors = this.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            return this.ValidationError(errors);
        }

        public ActionResult Edit(string email)
        {
            return this.PartialView("_Edit", this.users.Get(email));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserVM vm)
        {
            if (vm.Phone != null && vm.Phone.Any(x => char.IsLetter(x)))
            {
                this.ModelState.AddModelError(string.Empty, Resources.InvalidPhoneNumber);
            }

            if (this.users.Exists(vm.Id, vm.Email))
            {
                this.ModelState.AddModelError(string.Empty, Resources.UserExists);
            }

            if (this.ModelState.IsValid)
            {
                this.users.Update(vm);
                return null;
            }

            var errors = this.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            return this.ValidationError(errors);
        }

    }
}
