using System;
using System.IO;

namespace TripLog.Server
{
    public class TripLogPersistencyBuilder
    {
        private DirectoryInfo _directory;

        public TripLogPersistencyBuilder(DirectoryInfo directory)
        {
            _directory = directory;
        }

        public TripLogPersistency Build(Environment env)
        {
            switch (env)
            {
                case Environment.Test:
                    return new ExtendedDbreezeTripLogPersistency(new DirectoryInfo(@"C:\WebServer\Persistency"));

                case Environment.Prod:
                    return new DbreezeTripLogPersistency(new DirectoryInfo(@"C:\WebServer\Persistency"));

                default:
                    throw new Exception();
            }
        }
    }
}