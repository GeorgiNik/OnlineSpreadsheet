namespace LibertyGlobalBP.Web.ViewModels.Users
{
    public class IndexVM
    {
        public IndexVM(int? userRoleID)
        {
            this.UserRoleID = userRoleID;
        }

        public int? UserRoleID { get; set; }
    }
}
