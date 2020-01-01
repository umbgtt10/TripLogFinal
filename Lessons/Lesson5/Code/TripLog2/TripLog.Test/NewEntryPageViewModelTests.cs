using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog
{
    [TestClass]
    public class NewEntryPageViewModelTests
    {
        private readonly Mock<ITripLogNavigation> tripLogNavigation;
        private readonly Mock<IGeoLocationService> geoLocation;
        private readonly NewEntryPageViewModel testee;

        public NewEntryPageViewModelTests()
        {
            tripLogNavigation = new Mock<ITripLogNavigation>();
            geoLocation = new Mock<IGeoLocationService>();
            testee = new NewEntryPageViewModel(tripLogNavigation.Object, geoLocation.Object);
        }

        [TestMethod]
        public void Init_SetsAttributes()
        {
            // Arrange 
            var expectedCoordinates = new Coordinates() { Latitude = 10, Longitude = 20 };
            geoLocation.Setup(m => m.GetCoordinatesAsync()).ReturnsAsync(expectedCoordinates);
            
            // Act
            testee.Init();

            // Assert
            Assert.AreEqual(1, testee.Rating);
            Assert.AreEqual(DateTime.Now.Date, testee.Date.Date);
            Assert.AreEqual(expectedCoordinates.Latitude, testee.Latitude);
            Assert.AreEqual(expectedCoordinates.Longitude, testee.Longitude);
            geoLocation.Verify(m => m.GetCoordinatesAsync(), Times.Once);
        }

        [TestMethod]
        public void SaveCommandFired_TitleSet_CallsNavigate()
        {
            // Arrange
            testee.Title = "Location";

            // Act
            testee.SaveCommand.Execute(null);

            // Assert
            tripLogNavigation.Verify(m => m.PopAsync(), Times.Once);
        }
    }
}
