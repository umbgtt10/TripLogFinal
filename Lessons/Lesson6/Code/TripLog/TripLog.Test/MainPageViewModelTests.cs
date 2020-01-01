using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;
using TripLog.Views;

namespace TripLog
{
    [TestClass]
    public class MainPageViewModelTests
    {
        private readonly MainPageViewModel testee;
        private readonly Mock<ITripLogFactory> tripLogFactoryMock;
        private readonly Mock<ITripLogDataService> tripLogDataServiceMock;

        public MainPageViewModelTests()
        {
            tripLogFactoryMock = new Mock<ITripLogFactory>();
            tripLogDataServiceMock = new Mock<ITripLogDataService>();
            testee = new MainPageViewModel(tripLogFactoryMock.Object, tripLogDataServiceMock.Object);
        }

        [TestMethod]
        public async Task Init_CallsRetrieveEntries()
        {
            // Arrange 
            tripLogDataServiceMock.Setup(m => m.ReadAllEntriesAsync()).ReturnsAsync(Enumerable.Empty<TripLogEntry>());

            //Act
            await testee.Init();

            // Assert
            tripLogDataServiceMock.Verify(m => m.ReadAllEntriesAsync());
        }

        [TestMethod]
        public void NewCommandFired_CallsNavigate()
        {
            // Arrange & Act
            testee.NewCommand.Execute(null);

            // Assert
            tripLogFactoryMock.Verify(m => m.NavigateToNewPage(), Times.Once);
            tripLogFactoryMock.Verify(m => m.NavigateToDetailPage(It.IsAny<TripLogEntry>()), Times.Never);
        }

        [TestMethod]
        public async Task DeleteCommandFired_CallsDelete()
        {
            // Arrange
            var expectedEntry = new TripLogEntry()
            {
                Title = "Title",
            };
            tripLogDataServiceMock.Setup(m => m.ReadAllEntriesAsync()).ReturnsAsync(new List<TripLogEntry> { expectedEntry });
            await testee.Init();

            // Act
            testee.DeleteCommand.Execute(expectedEntry);

            // Assert
            tripLogDataServiceMock.Verify(m => m.DeleteEntryAsync(expectedEntry));
            Assert.AreEqual(0, testee.Entries.Count);
        }

        [TestMethod]
        public void DetailSelectedFired_CallsNavigate()
        {
            // Arrange 
            var expectedEntry = new TripLogEntry();

            // Act
            testee.DetailSelectedItem = expectedEntry;

            // Assert
            tripLogFactoryMock.Verify(m => m.NavigateToDetailPage(expectedEntry), Times.Once);
            tripLogFactoryMock.Verify(m => m.NavigateToNewPage(), Times.Never);
        }
    }
}
