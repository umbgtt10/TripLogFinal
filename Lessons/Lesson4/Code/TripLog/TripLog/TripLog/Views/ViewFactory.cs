using TripLog.Services;
using TripLog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TripLog.Views
{
    public class ViewFactory
    {
        public ContentPage BuildNewPage(NewEntryPageViewModel vm)
        {
            return new NewEntryPage(vm);
        }

        public ContentPage BuildDetailPage(DetailPageViewModel vm)
        {
            var page = new DetailPage(vm);
            return page;
        }
    }
}
