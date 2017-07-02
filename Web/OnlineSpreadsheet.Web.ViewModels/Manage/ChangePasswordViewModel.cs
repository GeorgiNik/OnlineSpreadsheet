namespace OnlineSpreadsheet.Web.ViewModels.Manage
{
    using System.ComponentModel.DataAnnotations;
    using OnlineSpreadsheet.Localization.Resources;

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "CurrentPassword", ResourceType = typeof(Resources))]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword", ResourceType = typeof(Resources))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources))]
        [Compare("NewPassword", ErrorMessageResourceName  = "PasswordsDontMatch", ErrorMessageResourceType = typeof(Resources))]
        public string ConfirmPassword { get; set; }
    }
}
