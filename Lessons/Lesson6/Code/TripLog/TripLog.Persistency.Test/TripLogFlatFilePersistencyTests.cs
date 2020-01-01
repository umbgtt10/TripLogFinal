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

        [TestMethod]
        public void Delete_NonExistingEntry_ReturnsFalse()
        {
            // Arrange
            var entry1 = new TripLogEntry() { Title = "Title1" };

            // Act
            var result = testee.Delete(entry1);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Delete_StoresMany_Then_DeletesExisting_RetrievesRemainingEntries()
        {
            // Arrange
            var entry1 = new TripLogEntry() { Title = "Title1" };
            var entry2 = new TripLogEntry() { Title = "Title2" };
            var entry3 = new TripLogEntry() { Title = "Title3" };
            testee.Store(entry1);
            testee.Store(entry2);
            testee.Store(entry3);

            // Act
            var result = testee.Delete(entry2);

            // Assert
            Assert.IsTrue(result);
            var reminingEntries = testee.Retrieve().ToList();
            Assert.AreEqual(reminingEntries.Count(), 2);
            Assert.IsFalse(reminingEntries.Contains(entry2));
        }
    }
}
