using System.Collections.Generic;
using System.IO;
using DBreeze;
using TripLog.Models;

namespace TripLog.Server
{
    public class DbreezeTripLogPersistency : TripLogPersistency
    {
        private DBreezeEngine _db;
        protected DirectoryInfo _dbDirectory;

        public DbreezeTripLogPersistency(DirectoryInfo directory)
        {
            _dbDirectory = directory;
            _db = new DBreezeEngine(directory.FullName);
        }

        public void Setup()
        {
            if (!_dbDirectory.Exists)
            {
                _dbDirectory.Create();
            }
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
            }
        }

        public void Add(TripLogEntry value)
        {
        }

        public IEnumerable<TripLogEntry> GetAll()
        {
            return new TripLogEntry[] { new TripLogEntry(), new TripLogEntry() };
        }
    }
}