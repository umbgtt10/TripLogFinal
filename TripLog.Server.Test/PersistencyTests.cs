
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripLog.Models;

namespace TripLog.Server.Test
{
    [TestClass]
    public class PersistencyTests
    {
        [TestMethod]
        public void AddElementToPersistencyTest()
        {
            var persistency = new DbreezeTripLogPersistency();

            persistency.Add(new TripLogEntry());
        }

        [TestMethod]
        public void GetAllElementsFromPersistencyTest()
        {
            var persistency = new DbreezeTripLogPersistency();

            var allEntries = persistency.GetAll();
        }
    }
}
