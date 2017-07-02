namespace OnlineSpreadsheet.Web.Application.Controllers
{
    using System.Configuration;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using OnlineSpreadsheet.Data.Models;
    using OnlineSpreadsheet.Data.Services.Contracts;
    using OnlineSpreadsheet.Web.Application.Emails.Services;
    using OnlineSpreadsheet.Web.ViewModels.Account;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using Localization.Resources;
    [Authorize]
    public class AccountController : BaseController
    {
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";
        private ApplicationSignInManager signInManager;
        private ApplicationUserManager userManager;
        private IUserService users;

        public AccountController(IUserService u)
        {
            this.users = u;
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, IUserService u)
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
            this.users = u;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return this.signInManager ?? this.HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }

            private set
            {
                this.signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return this.userManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }

            private set
            {
                this.userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return this.HttpContext.GetOwinContext().Authentication;
            }
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl, string message)
        {
            this.ViewBag.ReturnUrl = returnUrl;
            var vm = new LoginViewModel
            {
                Message = message
            };

            return this.View(vm);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = this.users.Get(model.Email);

            if (user == null)
            {
                this.ModelState.AddModelError(string.Empty, Resources.InvalidLoginAttempt);
                return this.View(model);
            }

            if (user.EntityStatus != EntityStatus.Active)
            {
                this.ModelState.AddModelError(string.Empty, Resources.AccountInactive);
                return this.View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await this.SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return this.RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return this.View("Lockout");
                case SignInStatus.RequiresVerification:
                    return this.RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    this.ModelState.AddModelError(string.Empty, Resources.InvalidLoginAttempt);
                    return this.View(model);
            }
        }

        //[AllowAnonymous]
        //public ActionResult Register()
        //{
        //    return this.View();
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Register(RegisterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Name = model.Email, CreatedOn = DateTime.Now, EntityStatus = EntityStatus.Active };
        //        var result = await this.UserManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            await this.SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

        //            return this.RedirectToAction("Index", "Home");
        //        }

        //        this.AddErrors(result);
        //    }

        //    return this.View(model);
        //}

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            var vm = new ForgotPasswordViewModel();
            return this.View(vm);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = this.users.Get(model.Email);
                if (user == null)
                {
                    model.Message = Resources.UserDoesntExist;
                    return this.View(model);
                }

                string code = this.users.GeneratePasswordResetToken(model.Email);

                string callbackUrl = ConfigurationManager.AppSettings["SystemLink"] + $"/Account/ResetPassword?userId={user.Id}&code={code}";

                AccountEmails.SendPasswordReset(user,callbackUrl);

                return this.RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            return this.View(model);
        }


        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return this.View();
        }

        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            var vm = new ResetPasswordViewModel();
            vm.Code = code;
            return code == null ? this.View("Error") : this.View(vm);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = this.users.Get(model.Email);
            if (user == null)
            {
                return this.RedirectToAction("ResetPasswordConfirmation", "Account");
            }

            if (user.PasswordResetToken == model.Code)
            {
                this.UserManager.RemovePassword(user.Id);
                this.UserManager.AddPassword(user.Id, model.Password);

                return this.RedirectToAction("Login", "Account", new { message = Resources.PasswordSetSuccessfully });
            }

            this.ModelState.AddModelError(string.Empty, Resources.InvalidToken);
            return this.View();
        }

        public ActionResult ResetPasswordConfirmation()
        {
            return this.View();
        }

        public ActionResult LogOff()
        {
            this.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return this.RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.userManager != null)
                {
                    this.userManager.Dispose();
                    this.userManager = null;
                }

                if (this.signInManager != null)
                {
                    this.signInManager.Dispose();
                    this.signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (this.Url.IsLocalUrl(returnUrl))
            {
                return this.Redirect(returnUrl);
            }

            return this.RedirectToAction("Index", "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, error);
            }
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                this.LoginProvider = provider;
                this.RedirectUri = redirectUri;
                this.UserId = userId;
            }

            public string LoginProvider { get; set; }

            public string RedirectUri { get; set; }

            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = this.RedirectUri };
                if (this.UserId != null)
                {
                    properties.Dictionary[XsrfKey] = this.UserId;
                }

                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, this.LoginProvider);
            }
        }
    }
}