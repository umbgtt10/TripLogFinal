namespace TripLog.Services
{
    using System.Threading.Tasks;

    using Models;

    public interface GeoLocationService
    {
        Task<GeoCoords> PullCoordinatesAsync();
    }
}