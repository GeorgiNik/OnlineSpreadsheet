namespace LibertyGlobalBP.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using LibertyGlobalBP.Localization.Resources;

    public class LoginViewModel
    {
        [Required(ErrorMessageResourceName = "InvalidLoginEmail", ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = "Email", ResourceType = typeof(Resources))]
        [EmailAddress]
        public string Email { get; set; }
        public string Message { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources))]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
