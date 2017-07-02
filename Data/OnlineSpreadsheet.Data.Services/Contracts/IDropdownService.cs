namespace OnlineSpreadsheet.Data.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using Utilities.Common;
    using Web.ViewModels.ProjectFiles;
    using Web.ViewModels.UserRoles;
    using Web.ViewModels.Users;

    public interface IDropdownService
    {
        IEnumerable<EnumerationItemVM> EntityStates();

        IQueryable<UserVM> Users();

        IQueryable<FolderVM> Folders();

        IQueryable<UserRoleVM> UserRoles();

        bool Exists(IEnumerable<EnumerationItemVM> items, int key);
    }
}
