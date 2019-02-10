using System;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using TripLog.Models;
using TripLog.Services;

namespace TripLog.UWP.Services
{
    public class UwpLocationService : GeoLocationService
    {
        public async Task<GeoCoords> PullCoordinatesAsync()
        {
            var locator = new Geolocator();
            var coordinates = await locator.GetGeopositionAsync();

            GeoCoords result = new GeoCoords
            {
                Latitude = coordinates.Coordinate.Point.Position.Latitude,
                Longitude = coordinates.Coordinate.Point.Position.Longitude
            };

            return result;
        }
    }
}