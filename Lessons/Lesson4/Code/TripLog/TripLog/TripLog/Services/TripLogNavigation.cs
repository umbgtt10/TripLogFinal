using System.Threading.Tasks;
using Xamarin.Forms;

namespace TripLog.Services
{
    public class TripLogNavigation : ITripLogNavigation
    {
        private readonly INavigation navigation;

        public TripLogNavigation(INavigation navigation)
        {
            this.navigation = navigation;
        }

        public Task<Page> PopAsync()
        {
            return this.navigation.PopAsync();
        }

        public Task PushAsync(Page page)
        {
            return this.navigation.PushAsync(page);
        }
    }
}
