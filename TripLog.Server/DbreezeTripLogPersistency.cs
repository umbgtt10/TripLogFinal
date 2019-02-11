using System.Collections.Generic;
using System.IO;
using System.Linq;
using DBreeze;
using Newtonsoft.Json;
using TripLog.Models;

namespace TripLog.Server
{
    public class DbreezeTripLogPersistency : TripLogPersistency
    {
        protected string TableName = "TripLogTable";
        protected DBreezeEngine Db;
        private readonly DirectoryInfo _dbDirectory;

        public DbreezeTripLogPersistency(DirectoryInfo directory)
        {
            _dbDirectory = directory;
            Db = new DBreezeEngine(directory.FullName);
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
            if (Db != null)
            {
                Db.Dispose();
            }
        }

        public void Add(TripLogEntry value)
        {
            using (var transaction = Db.GetTransaction())
            {
                transaction.Insert(TableName, value.Id, Serialize(value));
                transaction.Commit();
            }
        }

        public IEnumerable<TripLogEntry> GetAll()
        {
            IList<TripLogEntry> result;

            using (var transaction = Db.GetTransaction())
            {
                var selection = transaction.SelectForward<string, string>(TableName);
                result = selection.Select(elem => Deserialize(elem.Value)).ToList();
                transaction.Commit();
            }

            return result;
        }

        private string Serialize(TripLogEntry entry)
        {
            return JsonConvert.SerializeObject(entry);
        }

        private TripLogEntry Deserialize(string serializedTripLogEntry)
        {
            var entry = JsonConvert.DeserializeObject<TripLogEntry>(serializedTripLogEntry);

            TripLogEntry result = new TripLogEntry
            {
                Id = entry.Id,
                Title = entry.Title,
                Latitude = entry.Latitude,
                Longitude = entry.Longitude,
                Date = entry.Date,
                Rating = entry.Rating,
                Notes = entry.Notes
            };

            return result;
        }
    }
}