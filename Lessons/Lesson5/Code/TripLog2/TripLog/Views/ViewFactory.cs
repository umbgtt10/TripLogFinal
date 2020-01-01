using TripLog.ViewModels;
using Xamarin.Forms;

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
