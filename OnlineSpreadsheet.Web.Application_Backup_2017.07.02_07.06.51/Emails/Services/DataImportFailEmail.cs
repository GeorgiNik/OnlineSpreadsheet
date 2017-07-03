namespace OnlineSpreadsheet.Web.Application.Emails.Services
{
    using Data.Models;
    using Localization.Resources;
    using System;
    using System.Configuration;
    using ViewModels;
    using Web.ViewModels.Users;

    public class DataImportFailEmail
    {
        private static string defaultEmail = ConfigurationManager.AppSettings["DefaultEmail"];
        private static string bcc = ConfigurationManager.AppSettings["BccMailbox"];
        private static bool emailSendingEnabled = bool.Parse(ConfigurationManager.AppSettings["EmailSendingEnabled"]);

        public static void SendDownloadLink(UserVM user, string link)
        {
            var passwordlink = $"<a href='{link}'>{Resources.Here}</a>";

            var subject = "Data import validation";
            var body = "The import has validation errors. You can download validated import from " + passwordlink + ".";
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
                    AdditionalInformation = $"Method: SendDownloadLink",
                    Subject = subject,
                    Body = body,
                    Signature = signature,
                    ReceiverCc = bcc,
                    Sender = defaultEmail,
                    IsSendingEnabled = emailSendingEnabled
                });

                db.SaveChanges();
            }
        }
    }
}