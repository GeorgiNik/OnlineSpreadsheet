namespace LibertyGlobalBP.Data.Models
{
    using System;

    public class EmailSuccessLog
    {
        public int ID { get; set; }

        public string Receiver { get; set; }

        public string ReceiverCc { get; set; }

        public string Sender { get; set; }

        public string EmailContent { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string Signature { get; set; }

        public string AdditionalInformation { get; set; }

        public DateTime DateSent { get; set; }

        public bool IsExternal { get; set; }

        public bool IsSendingEnabled { get; set; }
    }
}
