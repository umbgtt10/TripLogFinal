using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripLog.Models;

namespace TripLog.Server.Test
{
    [TestClass]
    public class PersistencyTests
    {
        private string _dbSubFolder = "DbTemp";
        private DbreezeTripLogPersistency _db;
        private DirectoryInfo _dbFolder;

        [TestInitialize]
        public void Setup()
        {
            _dbFolder = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), _dbSubFolder));
            _db = new DbreezeTripLogPersistency(_dbFolder);
            _db.Setup();
        }

        [TestCleanup]
        public void ShutDown()
        {
            if (_db != null)
            {
                _db.Dispose();
            }
        }

        [TestMethod]
        public void AddElementToPersistencyTest()
        {
            _db.Add(new TripLogEntry());
        }

        [TestMethod]
        public void GetAllElementsFromPersistencyTest()
        {
            var allEntries = _db.GetAll();
        }
    }
}
