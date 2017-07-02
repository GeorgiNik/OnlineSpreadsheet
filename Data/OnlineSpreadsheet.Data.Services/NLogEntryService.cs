namespace OnlineSpreadsheet.Data.Services.Implementation
{
    using Common;
    using Contracts;
    using Models;

    public class NLogEntryService : INLogEntryService
    {
        private IRepository<NLogEntry> nLogEntries;

        public NLogEntryService(IRepository<NLogEntry> n)
        {
            this.nLogEntries = n;
        }

        public void Add(NLogEntry nLogEntry)
        {
            this.nLogEntries.Add(nLogEntry);
            this.nLogEntries.SaveChanges();
        }
    }
}
