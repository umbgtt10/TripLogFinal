using System.Threading.Tasks;
using TripLog.Models;

namespace TripLog.Services
{
    public interface GeoLocationService
    {
        Task<GeoCoords> PullCoordinatesAsync();
    }
}