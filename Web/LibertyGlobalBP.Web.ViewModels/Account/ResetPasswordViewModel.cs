namespace LibertyGlobalBP.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using LibertyGlobalBP.Localization.Resources;

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "PasswordMinLength", ErrorMessageResourceType = typeof(Resources), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources))]
        [Compare("Password", ErrorMessageResourceName = "PasswordsDontMatch", ErrorMessageResourceType = typeof(Resources))]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
