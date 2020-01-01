using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog
{
    [TestClass]
    public class DetailPageViewModelTests
    {
        private readonly Mock<ITripLogNavigation> tripLogNavigationMock;
        private readonly DetailPageViewModel testee;

        public DetailPageViewModelTests()
        {
            tripLogNavigationMock = new Mock<ITripLogNavigation>();
            testee = new DetailPageViewModel(tripLogNavigationMock.Object);
        }

        [TestMethod]
        public void Init()
        {
            // Arrange
            var expectedEntry = new TripLogEntry();

            // Act
            testee.Init(expectedEntry);

            // Assert
            Assert.AreEqual(expectedEntry, testee.Entry);
        }

        public void BackCommandFired_CallsNavigate()
        {
            // Arrange & Act
            testee.BackCommand.Execute(null);

            // Assert
            tripLogNavigationMock.Verify(m => m.PopAsync(), Times.Once);
        }
    }
}
