using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;

namespace TripLog.Test
{
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