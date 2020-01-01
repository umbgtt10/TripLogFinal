using System;
using System.Threading.Tasks;

using Windows.Devices.Geolocation;

using TripLog.Services;
using TripLog.Models;

namespace TripLog.UWP.Services
{
    public class UwpLocationService : IGeoLocationService
    {
        public async Task<GeoCoordinates> GetCoordinatesAsync()
        {
            var locator = new Geolocator();
            var coordinates = await locator.GetGeopositionAsync();

            var result = new GeoCoordinates
            {
                Latitude = coordinates.Coordinate.Point.Position.Latitude,
                Longitude = coordinates.Coordinate.Point.Position.Longitude
            };

            return result;
        }
    }
}