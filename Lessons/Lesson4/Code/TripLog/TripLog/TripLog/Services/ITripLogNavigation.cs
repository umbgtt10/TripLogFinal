using System.Threading.Tasks;
using Xamarin.Forms;

namespace TripLog.Services
{
    public interface ITripLogNavigation
    {
        Task PushAsync(Page page);

        Task<Page> PopAsync();
    }
}
