using CoreLocation;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;
using UIKit;

namespace TripLog.iOS.Services
{
    public class IosLocationService : IGeoLocationService
    {
        private TaskCompletionSource<CLLocation> _locationTaskCompletion;

        public async Task<Coordinates> GetCoordinatesAsync()
        {
            var locationManager = new CLLocationManager();
            _locationTaskCompletion = new TaskCompletionSource<CLLocation>();

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                locationManager.RequestWhenInUseAuthorization();
            }

            locationManager.LocationsUpdated += OnLocationUpdated;

            locationManager.StartUpdatingLocation();

            var location = await _locationTaskCompletion.Task;

            var result = new Coordinates
            {
                Latitude = location.Coordinate.Latitude,
                Longitude = location.Coordinate.Longitude
            };

            return result;
        }

        private void OnLocationUpdated(object sender, CLLocationsUpdatedEventArgs e)
        {
            _locationTaskCompletion.TrySetResult(e.Locations[0]);
        }
    }
}