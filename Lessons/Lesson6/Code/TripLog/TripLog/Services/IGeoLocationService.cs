using System.Threading.Tasks;
using TripLog.Models;

namespace TripLog.Services
{
    public interface IGeoLocationService
    {
        Task<GeoCoordinates> GetCoordinatesAsync();
    }
}
