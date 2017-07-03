namespace OnlineSpreadsheet.Web.Application.Controllers
{
    using Data.Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using OnlineSpreadsheet.Web.ViewModels.Home;
    using Utilities;

    [Authorize]
    public class HomeController : BaseController
    {
        private IDropdownService dropdowns;
        private IUserService users;
        private IProjectFilesService files;

        public HomeController(IDropdownService dd, IProjectFilesService files, IUserService users)
        {
            this.dropdowns = dd;
            this.files = files;
            this.users = users;
        }

        public ActionResult Index()
        {
            int uploadedFilesCount = this.files.Count();
            int usersCount = this.users.GetAll().Count();

            var vm = new HomeVM()
            {
                UploadedFilesCount = uploadedFilesCount,
                UsersCount = usersCount
            };
            return this.View(vm);
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
