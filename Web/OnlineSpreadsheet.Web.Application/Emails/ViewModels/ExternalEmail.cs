namespace OnlineSpreadsheet.Web.Application.Emails.ViewModels
{
    using System.Configuration;
    using System.Web.Mvc;
    using Postal;

    public class ExternalEmail : Email
    {
        public ExternalEmail(string from, string to, string subject, string body, string signature)
        {
            this.From = from;
            this.To = to;
            this.Bcc = ConfigurationManager.AppSettings["BccMailbox"];
            this.Subject = subject;
            this.Body = body;
            this.Signature = signature;
            this.SystemLink = ConfigurationManager.AppSettings["SystemLink"];
        }

        public string From { get; set; }

        public string To { get; set; }

        public string Cc { get; set; }

        public string Subject { get; set; }

        [AllowHtml]
        public string Body { get; set; }

        [AllowHtml]
        public string Signature { get; set; }

        public string SystemLink { get; set; }

        public string Bcc { get; set; }
    }
}