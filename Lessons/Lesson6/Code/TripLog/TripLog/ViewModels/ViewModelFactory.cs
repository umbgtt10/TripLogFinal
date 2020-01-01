using TripLog.Services;

namespace TripLog.ViewModels
{
    public class ViewModelFactory
    {
        private readonly ITripLogNavigation tripLogNavigation;
        private readonly IGeoLocationService geoLocation;
        private readonly ITripLogDataService tripLogDataService;

        public ViewModelFactory(ITripLogNavigation tripLogNavigation, IGeoLocationService geoLocation, ITripLogDataService tripLogDataService)
        {
            this.tripLogNavigation = tripLogNavigation;
            this.geoLocation = geoLocation;
            this.tripLogDataService = tripLogDataService;
        }

        public NewEntryPageViewModel BuildNewEntryPageViewModel()
        {
            return new NewEntryPageViewModel(this.tripLogNavigation, this.geoLocation, this.tripLogDataService);
        }

        public DetailPageViewModel BuildDetailPageViewModel()
        {
            return new DetailPageViewModel(this.tripLogNavigation);
        }
    }
}
