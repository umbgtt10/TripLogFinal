namespace TripLog.ViewModels
{
    using System;

    using Services;

    public class ViewModelFactory
    {
        private readonly GeoLocationService _locationService;
        private readonly TripLogDataService _dataService;

        public ViewModelFactory(
            GeoLocationService locationService,
            TripLogDataService dataService)
        {
            _locationService = locationService;
            _dataService = dataService;
        }

        public BaseViewModel Build(ViewType viewModelType)
        {
            switch (viewModelType)
            {
                case ViewType.Detail:
                    return new DetailViewModel();
                case ViewType.Main:
                    return new MainViewModel(_dataService);
                case ViewType.New:
                    return new NewEntryViewModel(_locationService, _dataService);
                default:
                    throw new Exception($"Unknown {viewModelType}");
            }
        }
    }
}