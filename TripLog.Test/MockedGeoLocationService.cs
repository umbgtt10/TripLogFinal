namespace TripLog.Test
{
    using System.Threading.Tasks;

    using Models;
    using Services;

    public class MockedGeoLocationService : GeoLocationService
    {
        public Task<GeoCoords> PullCoordinatesAsync()
        {
            return new Task<GeoCoords>(Get);
        }

        public GeoCoords Get()
        {
            return TestInit.FakeCoordinates;
        }
    }
}