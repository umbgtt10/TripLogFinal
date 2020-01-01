using System.IO;

namespace TripLog.Persistency.Test
{
    public class TripLogExtendedFlatFilePersistency : TripLogFlatFilePersistency
    {
        public TripLogExtendedFlatFilePersistency(FileInfo file) : base(file)
        {
        }

        public void Delete()
        {
            if (file.Exists)
            {
                file.Delete();
            }
        }
    }
}
