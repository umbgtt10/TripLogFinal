using System.Collections.Generic;
using TripLog.Models;

namespace TripLog.Server
{
    public class DbreezeTripLogPersistency : TripLogPersistency
    {
        public void Add(TripLogEntry value)
        {
        }

        public IEnumerable<TripLogEntry> GetAll()
        {
            return new TripLogEntry[] { new TripLogEntry(), new TripLogEntry() };
        }

        public void Dispose()
        {
        }
    }
}