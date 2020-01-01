using System.Collections.Generic;
using TripLog.Models;

namespace TripLog.Persistency
{
    public interface ITripLogPersistency
    {
        IEnumerable<TripLogEntry> Retrieve();

        void Store(TripLogEntry entry);
    }
}
