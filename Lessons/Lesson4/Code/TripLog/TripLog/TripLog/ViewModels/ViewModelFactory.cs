using TripLog.Services;

namespace TripLog.ViewModels
{
    public class ViewModelFactory
    {
        private readonly ITripLogNavigation tripLogNavigation;

        public ViewModelFactory(ITripLogNavigation tripLogNavigation)
        {
            this.tripLogNavigation = tripLogNavigation;
        }

        public NewEntryPageViewModel BuildNewEntryPageViewModel()
        {
            return new NewEntryPageViewModel(this.tripLogNavigation);
        }

        public DetailPageViewModel BuildDetailPageViewModel()
        {
            return new DetailPageViewModel(this.tripLogNavigation);
        }
    }
}
