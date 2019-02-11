using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripLog.Models;

namespace TripLog.Server.Test
{
    [TestClass]
    public class PersistencyTests
    {
        private string _dbSubFolder = "DbTemp";
        private ExtendedDbreezeTripLogPersistency _db;
        private DirectoryInfo _dbFolder;

        [TestInitialize]
        public void Setup()
        {
            _dbFolder = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), _dbSubFolder));
            _db = new ExtendedDbreezeTripLogPersistency(_dbFolder);
            _db.Setup();
            _db.RemoveAll();
        }

        [TestCleanup]
        public void ShutDown()
        {
            if (_db != null)
            {
                _db.RemoveAll();
                _db.Dispose();
            }
        }

        [TestMethod]
        public void AddElementsToPersistencyTest()
        {
            var title1 = "Number1";
            var title2 = "Number2";

            _db.Add(new TripLogEntry {Title = title1});
            _db.Add(new TripLogEntry { Title = title2 });

            var allEntries = _db.GetAll();

            Assert.AreEqual(2, allEntries.Count());
            Assert.AreEqual(1, allEntries.Count(elem => elem.Title.Equals(title1)));
            Assert.AreEqual(1, allEntries.Count(elem => elem.Title.Equals(title2)));
        }

        [TestMethod]
        public void AddSameElementTwiceToPersistencyTest()
        {
            var title1 = "Number1";
            var entry = new TripLogEntry { Title = title1 };

            _db.Add(entry);
            _db.Add(entry);

            var allEntries = _db.GetAll();

            Assert.AreEqual(1, allEntries.Count());
            Assert.AreEqual(1, allEntries.Count(elem => elem.Title.Equals(title1)));
        }

        [TestMethod]
        public void GetAllElementsFromPersistencyTest()
        {
            var allEntries = _db.GetAll();

            Assert.AreEqual(0, allEntries.Count());
        }
    }
}
