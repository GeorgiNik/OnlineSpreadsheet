namespace OnlineSpreadsheet.Data.Services.Implementation
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using OnlineSpreadsheet.Data.Common;
    using OnlineSpreadsheet.Data.Models;
    using OnlineSpreadsheet.Data.Services.Contracts;
    using OnlineSpreadsheet.Web.ViewModels.UserRoles;

    public class UserRoleService : IUserRoleService
    {
        private IDeletableRepository<UserRole> roles;
        private IDeletableRepository<ApplicationUser> users;

        public UserRoleService(
            IDeletableRepository<UserRole> r,
            IDeletableRepository<ApplicationUser> u)
        {
            this.roles = r;
            this.users = u;
        }

        public UserRoleVM Add(UserRoleVM userRole)
        {
            var model = Mapper.Map<UserRole>(userRole);

            this.roles.Add(model);
            this.roles.SaveChanges();

            return Mapper.Map<UserRoleVM>(model);
        }

        public void Delete(int id)
        {
            this.roles.Delete(id);
            this.roles.SaveChanges();
        }

        public IQueryable<UserRoleVM> GetAll()
        {
            return this.roles.GetAll().ProjectTo<UserRoleVM>();
        }

        public void Update(UserRoleVM userRole)
        {
            var model = this.roles.Get(userRole.ID);

            this.roles.Update(Mapper.Map(userRole, model));
            this.roles.SaveChanges();
        }

        public bool UsersInRole(int id)
        {
            return this.users.Any(u => u.UserRoleID == id);
        }

        public UserRoleVM Get(int id)
        {
            return Mapper.Map<UserRoleVM>(this.roles.Get(id));
        }
    }
}
