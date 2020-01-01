using TripLog.Services;

namespace TripLog.ViewModels
{
    public class ViewModelFactory
    {
        private readonly ITripLogNavigation tripLogNavigation;
        private readonly IGeoLocationService geoLocation;

        public ViewModelFactory(ITripLogNavigation tripLogNavigation, IGeoLocationService geoLocation)
        {
            this.tripLogNavigation = tripLogNavigation;
            this.geoLocation = geoLocation;
        }

        public NewEntryPageViewModel BuildNewEntryPageViewModel()
        {
            return new NewEntryPageViewModel(this.tripLogNavigation, this.geoLocation);
        }

        public DetailPageViewModel BuildDetailPageViewModel()
        {
            return new DetailPageViewModel(this.tripLogNavigation);
        }
    }
}
