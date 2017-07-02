namespace OnlineSpreadsheet.Data.Services.Contracts
{
    using Common;
    using Models;

    public interface INLogEntryService : IService
    {
        void Add(NLogEntry nLogEntry);
    }
}
