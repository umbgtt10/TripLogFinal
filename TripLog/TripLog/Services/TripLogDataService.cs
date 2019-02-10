using System.Collections.Generic;
using System.Threading.Tasks;
using TripLog.Models;

namespace TripLog.Services
{
    public interface TripLogDataService
    {
        Task<IList<TripLogEntry>> ReadAllEntriesAsync();
        Task AddEntryAsync(TripLogEntry entry);
    }
}