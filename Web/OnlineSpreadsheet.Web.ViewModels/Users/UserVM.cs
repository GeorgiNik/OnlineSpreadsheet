namespace OnlineSpreadsheet.Web.ViewModels.Users
{
    using Infrastructure;
    using OnlineSpreadsheet.Data.Models;
    using Localization.Resources;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Utilities.Common;

    public class UserVM : IMapFrom<ApplicationUser>
    {
        public UserVM()
        {

        }

        [Display(Name = "Assignment", ResourceType = typeof(Resources))]
        public string Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(Resources))]
        public string Name { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "EmailRequired", ErrorMessageResourceType = typeof(Resources))]
        [DataType(DataType.EmailAddress, ErrorMessageResourceName = "InvalidLoginEmail", ErrorMessageResourceType = typeof(Resources))]
        public string Email { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resources))]
        public string Title { get; set; }

        [Display(Name = "Phone", ResourceType = typeof(Resources))]
        public string Phone { get; set; }

        [Required(ErrorMessageResourceName = "UserRoleRequired", ErrorMessageResourceType = typeof(Resources))]
        public int? UserRoleID { get; set; }

        [Display(Name = "UserRole", ResourceType = typeof(Resources))]
        public string UserRoleName { get; set; }

        [Display(Name = "Status", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "StatusRequired", ErrorMessageResourceType = typeof(Resources))]
        public EntityStatus EntityStatus { get; set; }

        public string EntityStatusName => this.EntityStatus.GetTranslation();

        public string PasswordResetToken { get; set; }
    }
}
