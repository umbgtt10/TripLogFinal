using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TripLog.Models;
using TripLog.ViewModels;
using TripLog.Views;

namespace TripLog
{
    [TestClass]
    public class MainPageViewModelTests
    {
        private readonly MainPageViewModel testee;
        private readonly Mock<ITripLogFactory> tripLogFactoryMock;

        public MainPageViewModelTests()
        {
            tripLogFactoryMock = new Mock<ITripLogFactory>();
            testee = new MainPageViewModel(tripLogFactoryMock.Object);
        }

        [TestMethod]
        public void Init_FetchesHardCodedEntries()
        {
            // Arrange && Act
            testee.Init();

            // Assert
            Assert.AreEqual(3, testee.Entries.Count);
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
