using System.Collections.Generic;
using System.Threading.Tasks;
using TripLog.Models;

namespace TripLog.Services
{
    public class RestTripLogDataService : TripLogDataService
    {
        public Task AddEntryAsync(TripLogEntry entry)
        {
            var task = new Task(GetAdd);
            task.Start();
            return task;
        }

        private void GetAdd()
        {
        }

        public Task<IList<TripLogEntry>> ReadAllEntriesAsync()
        {
            var task = new Task<IList<TripLogEntry>>(GetRead);
            task.Start();
            return task;
        }

        private IList<TripLogEntry> GetRead()
        {
            return new List<TripLogEntry>();
        }
    }
}