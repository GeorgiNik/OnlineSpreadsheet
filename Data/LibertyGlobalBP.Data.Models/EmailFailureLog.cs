namespace LibertyGlobalBP.Data.Models
{
    using System;

    public class EmailFailureLog
    {
        public int ID { get; set; }

        public string Receiver { get; set; }

        public string EmailContent { get; set; }

        public string AdditionalInformation { get; set; }
        
        public string Exception { get; set; }

        public string Stacktrace { get; set; }

        public DateTime DateSent { get; set; }

        public bool IsExternal { get; set; }
    }
}
