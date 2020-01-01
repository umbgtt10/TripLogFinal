using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog
{
    [TestClass]
    public class NewEntryPageViewModelTests
    {
        private readonly Mock<ITripLogNavigation> tripLogNavigationMock;
        private readonly Mock<IGeoLocationService> geoLocationMock;
        private readonly Mock<ITripLogDataService> dataServiceMock;
        private readonly NewEntryPageViewModel testee;

        public NewEntryPageViewModelTests()
        {
            tripLogNavigationMock = new Mock<ITripLogNavigation>();
            geoLocationMock = new Mock<IGeoLocationService>();
            dataServiceMock = new Mock<ITripLogDataService>();
            testee = new NewEntryPageViewModel(tripLogNavigationMock.Object, geoLocationMock.Object, dataServiceMock.Object);
        }

        [TestMethod]
        public async Task Init_SetsAttributes()
        {
            // Arrange 
            var expectedCoordinates = new GeoCoordinates() { Latitude = 10, Longitude = 20 };
            geoLocationMock.Setup(m => m.GetCoordinatesAsync()).ReturnsAsync(expectedCoordinates);
            
            // Act
            await testee.Init();

            // Assert
            Assert.AreEqual(1, testee.Rating);
            Assert.AreEqual(DateTime.Now.Date, testee.Date.Date);
            Assert.AreEqual(expectedCoordinates.Latitude, testee.Latitude);
            Assert.AreEqual(expectedCoordinates.Longitude, testee.Longitude);
            geoLocationMock.Verify(m => m.GetCoordinatesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task SaveCommandFired_TitleSet_CallsNavigate()
        {
            // Arrange
            var expectedCoordinates = new GeoCoordinates() { Latitude = 10, Longitude = 20 };
            geoLocationMock.Setup(m => m.GetCoordinatesAsync()).ReturnsAsync(expectedCoordinates);
            await testee.Init();

            // Act
            testee.SaveCommand.Execute(null);

            // Assert
            dataServiceMock.Verify(m => m.AddEntryAsync(It.IsAny<TripLogEntry>()), Times.Once);
            tripLogNavigationMock.Verify(m => m.PopAsync(), Times.Once);
        }
    }
}
