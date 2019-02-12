namespace TripLog.Server
{
    using System;
    using System.Collections.Generic;

    using Models;

    public interface TripLogPersistency : IDisposable
    {
        void Setup();
        IEnumerable<TripLogEntry> GetAll();
        void Add(TripLogEntry value);
    }
}