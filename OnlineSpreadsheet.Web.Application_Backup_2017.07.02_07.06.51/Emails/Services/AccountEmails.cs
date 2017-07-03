namespace OnlineSpreadsheet.Web.Application.Emails.Services
{
    using System;
    using System.Configuration;
    using OnlineSpreadsheet.Data.Models;
    using OnlineSpreadsheet.Localization.Resources;
    using OnlineSpreadsheet.Web.Application.Emails.ViewModels;
    using OnlineSpreadsheet.Web.ViewModels.Users;

    public static class AccountEmails
    {
        private static string defaultEmail = ConfigurationManager.AppSettings["DefaultEmail"];
        private static string systemLink = ConfigurationManager.AppSettings["SystemLink"];

        private static string bcc = ConfigurationManager.AppSettings["BccMailbox"];

        private static bool emailSendingEnabled = bool.Parse(ConfigurationManager.AppSettings["EmailSendingEnabled"]);


        public static void SendPasswordReset(UserVM user, string link)
        {

            var system = $"<a href='{systemLink}'>{systemLink}</a>";
            var passwordlink = $"<a href='{link}'>{Resources.Here}</a>";

            var subject = "Password reset Liberty Global";
            var body = $"Hello {user.Name},<br/>You requested a password change for {system}.<br/>Please click {passwordlink} to change your password.";
            var signature = string.Empty;

            var mail = new ExternalNoCcEmail(defaultEmail, user.Email, bcc, subject, body, signature);
            mail.Send();

            using (var db = new ApplicationDbContext())
            {
                db.EmailSuccessLogs.Add(new EmailSuccessLog
                {
                    DateSent = DateTime.Now,
                    IsExternal = true,
                    Receiver = $"User: {user.Email}",
                    AdditionalInformation = $"Method: SendPasswordReset",
                    Subject = subject,
                    Body = body,
                    Sender = defaultEmail,
                    IsSendingEnabled = emailSendingEnabled
                });

                db.SaveChanges();
            }
        }

        public static void SendPasswordResetOnAccCreation(UserVM user, string link)
        {

            var system = $"<a href='{systemLink}'>{systemLink}</a>";
            var passwordlink = $"<a href='{link}'>{Resources.Here}</a>";

            var subject = "New account in Liberty Global";
            var body = $"Hello {user.Name},<br/>Your profile for {system} has been created.<br/>Please click {passwordlink} to log in.";
            var signature = string.Empty;

            var mail = new ExternalNoCcEmail(defaultEmail, user.Email, bcc, subject, body, signature);
            mail.Send();

            using (var db = new ApplicationDbContext())
            {
                db.EmailSuccessLogs.Add(new EmailSuccessLog
                {
                    DateSent = DateTime.Now,
                    IsExternal = true,
                    Receiver = $"User: {user.Email}",
                    AdditionalInformation = $"Method: SendPasswordResetOnAccCreation",
                    Subject = subject,
                    Body = body,
                    Sender = defaultEmail,
                    IsSendingEnabled = emailSendingEnabled
                });

                db.SaveChanges();
            }
        }
    }
}
