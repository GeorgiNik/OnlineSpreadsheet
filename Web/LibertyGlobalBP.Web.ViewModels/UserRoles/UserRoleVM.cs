namespace LibertyGlobalBP.Web.ViewModels.UserRoles
{
    using System.ComponentModel.DataAnnotations;
    using LibertyGlobalBP.Data.Models;
    using LibertyGlobalBP.Localization.Resources;
    using LibertyGlobalBP.Web.ViewModels.Infrastructure;

    public class UserRoleVM : IMapFrom<UserRole>
    {
        public int ID { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(Resources))]
        public string Name { get; set; }

        public bool ConfigurationRead { get; set; }

        public bool ConfigurationEdit { get; set; }

        public bool ProjectFilesRead { get; set; }

        public bool ProjectFilesEdit { get; set; }

        public bool ExportDataAndCharts { get; set; }

        public bool UserRolesRead { get; set; }

        public bool UserRolesEdit { get; set; }

        public bool UsersRead { get; set; }

        public bool UsersEdit { get; set; }
    }
}
