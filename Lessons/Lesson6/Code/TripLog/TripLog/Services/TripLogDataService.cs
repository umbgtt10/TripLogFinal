namespace TripLog.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models;

    public interface ITripLogDataService
    {
        Task<IEnumerable<TripLogEntry>> ReadAllEntriesAsync();

        Task AddEntryAsync(TripLogEntry entry);

        Task DeleteEntryAsync(TripLogEntry entry);
    }
}