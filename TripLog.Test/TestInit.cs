using Moq;
using TripLog.Models;
using TripLog.Services;

namespace TripLog.Test
{
    public class TestInit
    {
        public static Mock<GeoLocationService> MockedGeoLocationService = new Mock<GeoLocationService>();
        public static GeoCoords FakeCoordinates;

        static TestInit()
        {
            FakeCoordinates = new GeoCoords {Latitude = 123, Longitude = 321};

            MockedGeoLocationService.Setup(query => query.PullCoordinatesAsync()).
                ReturnsAsync(FakeCoordinates);
        }
    }
}
