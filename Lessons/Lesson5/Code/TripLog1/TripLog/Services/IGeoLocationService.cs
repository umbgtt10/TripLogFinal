using System.Threading.Tasks;
using TripLog.Models;

namespace TripLog.Services
{
    public interface IGeoLocationService
    {
        Task<Coordinates> GetCoordinatesAsync();
    }
}
