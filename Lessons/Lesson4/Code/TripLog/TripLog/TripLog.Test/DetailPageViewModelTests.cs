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
        private readonly Mock<ITripLogNavigation> tripLogNavigation;
        private readonly DetailPageViewModel testee;

        public DetailPageViewModelTests()
        {
            tripLogNavigation = new Mock<ITripLogNavigation>();
            testee = new DetailPageViewModel(tripLogNavigation.Object);
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

        public void BackComandFired_CallsNavigate()
        {
            // Arrange & Act
            testee.BackCommand.Execute(null);

            // Assert
            tripLogNavigation.Verify(m => m.PopAsync(), Times.Once);
        }
    }
}
