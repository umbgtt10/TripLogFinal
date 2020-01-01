using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using TripLog.Models;

namespace TripLog.Persistency
{
    public class TripLogFlatFilePersistency : ITripLogPersistency
    {
        protected readonly FileInfo file;

        public TripLogFlatFilePersistency(FileInfo file)
        {
            this.file = file;
        }

        public IEnumerable<TripLogEntry> Retrieve()
        {
            return PullAll();
        }

        public void Store(TripLogEntry entry)
        {
            var serializedEntry = JsonSerializer.Serialize(entry);

            File.AppendAllText(file.FullName, serializedEntry + Environment.NewLine);
        }

        public bool Delete(TripLogEntry entry)
        {
            var entries = PullAll().ToList();

            if (entries.Contains(entry))
            {
                entries.Remove(entry);

                var elements = entries.Select(e => JsonSerializer.Serialize(e));

                File.WriteAllLines(file.FullName, elements);

                return true;
            }

            return false;
        }

        private IEnumerable<TripLogEntry> PullAll()
        {
            if (file.Exists)
            {
                var entries = File.ReadAllLines(file.FullName);

                return entries.Select(e => JsonSerializer.Deserialize<TripLogEntry>(e));
            }

            return Enumerable.Empty<TripLogEntry>();
        }
    }
}
