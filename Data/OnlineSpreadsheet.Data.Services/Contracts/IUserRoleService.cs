namespace OnlineSpreadsheet.Data.Services.Contracts
{
    using System.Linq;
    using OnlineSpreadsheet.Data.Services.Contracts.Common;
    using OnlineSpreadsheet.Web.ViewModels.UserRoles;

    public interface IUserRoleService : IService
    {
        IQueryable<UserRoleVM> GetAll();

        UserRoleVM Add(UserRoleVM userRole);

        void Update(UserRoleVM userRole);

        void Delete(int id);

        bool UsersInRole(int id);

        UserRoleVM Get(int id);
    }
}
