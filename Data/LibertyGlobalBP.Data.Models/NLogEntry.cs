namespace LibertyGlobalBP.Data.Models
{
    public class NLogEntry
    {
        public int ID { get; set; }

        public string Url { get; set; }

        public string Username { get; set; }

        public string Message { get; set; }

        public string Exception { get; set; }

        public string StackTrace { get; set; }

        public string Date { get; set; }
    }
}
