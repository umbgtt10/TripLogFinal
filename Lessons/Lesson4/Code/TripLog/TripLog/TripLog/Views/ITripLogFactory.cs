using System.Threading.Tasks;
using TripLog.Models;

namespace TripLog.Views
{
    public interface ITripLogFactory
    {
        Task NavigateToDetailPage(TripLogEntry entry);
        Task NavigateToNewPage();
    }
}