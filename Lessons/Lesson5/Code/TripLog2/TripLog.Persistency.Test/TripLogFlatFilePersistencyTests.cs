using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using TripLog.Models;

namespace TripLog.Persistency.Test
{
    [TestClass]
    public class TripLogFlatFilePersistencyTests
    {
        private readonly TripLogExtendedFlatFilePersistency testee;

        public TripLogFlatFilePersistencyTests()
        {
            var file = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), Path.GetRandomFileName()));

            testee = new TripLogExtendedFlatFilePersistency(file);
        }

        [TestCleanup]
        public void ShutDown()
        {
            testee?.Delete();
        }

        [TestMethod]
        public void Retrieve_RetrievesNothing()
        {
            // Arrange & Act
            var expectedEntries = testee.Retrieve();

            // Assert
            Assert.AreEqual(expectedEntries.Count(), 0);
        }

        [TestMethod]
        public void Store_Then_Retrieve_RetrievesEntry()
        {
            // Arrange
            var entry = new TripLogEntry() { Title = "Title" };
            testee.Store(entry);

            // Act
            var expectedEntries = testee.Retrieve();

            // Assert
            Assert.AreEqual(expectedEntries.Count(), 1);
            Assert.AreEqual(expectedEntries.Single(), entry);
        }
    }
}
