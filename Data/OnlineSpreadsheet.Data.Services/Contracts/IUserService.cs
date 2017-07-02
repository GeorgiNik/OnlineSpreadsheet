namespace OnlineSpreadsheet.Data.Services.Contracts
{
    using System.Linq;
    using OnlineSpreadsheet.Web.ViewModels.Users;

    public interface IUserService
    {
        IQueryable<UserVM> GetAll();

        UserVM Add(UserVM vm);

        void Update(UserVM vm);

        void Delete(UserVM vm);

        string GeneratePasswordResetToken(string email);

        UserVM Get(string email);

        bool Exists(string email);

        bool Exists(string id, string email);
    }
}
