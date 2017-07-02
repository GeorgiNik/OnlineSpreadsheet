namespace OnlineSpreadsheet.Data.Services.Implementation
{
    using AutoMapper.QueryableExtensions;
    using Common;
    using Contracts;
    using Localization.Resources;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Utilities.Common;
    using Web.ViewModels.ProjectFiles;
    using Web.ViewModels.UserRoles;
    using Web.ViewModels.Users;

    public class DropdownService : IDropdownService
    {
        private readonly IDeletableRepository<ApplicationUser> users;
        private readonly IDeletableRepository<UserRole> userRoles;
        private readonly IDeletableRepository<Folder> folders;

        public DropdownService(
            IDeletableRepository<ApplicationUser> u,
            IDeletableRepository<UserRole> ur,
            IDeletableRepository<Folder> f)
        {
            this.users = u;
            this.userRoles = ur;
            this.folders = f;
        }

        private ApplicationUser currentUser;
        private ApplicationUser CurrentUser
        {
            get
            {
                if (currentUser == null)
                {
                    currentUser = this.users.FirstOrDefault(i => i.UserName == HttpContext.Current.User.Identity.Name);
                }

                return currentUser;
            }
        }

        public IEnumerable<EnumerationItemVM> EntityStates()
        {
            return MoreEnumeration.EnumToList<EntityStatus>();
        }
        public IQueryable<UserVM> Users()
        {
            return this.users.GetAll().ProjectTo<UserVM>();
        }
        public IQueryable<FolderVM> Folders()
        {
            return this.folders.GetAll().ProjectTo<FolderVM>();
        }

        public IQueryable<UserRoleVM> UserRoles()
        {
            return this.userRoles.GetAll().ProjectTo<UserRoleVM>();
        }


        public bool Exists(IEnumerable<EnumerationItemVM> items, int key)
        {
            return items.Any(i => i.ID == key);
        }
    }
}
