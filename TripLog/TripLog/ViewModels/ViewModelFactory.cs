using System;
using TripLog.Services;

namespace TripLog.ViewModels
{
    public class ViewModelFactory
    {
        private readonly GeoLocationService _locationService;

        public ViewModelFactory(GeoLocationService locationService)
        {
            _locationService = locationService;
        }

        public BaseViewModel Build(ViewType viewModelType)
        {
            switch (viewModelType)
            {
                case ViewType.Detail:
                    return new DetailViewModel();
                case ViewType.Main:
                    return new MainViewModel();
                case ViewType.New:
                    return new NewEntryViewModel(_locationService);
                default:
                    throw new Exception($"Unknown {viewModelType}");
            }
        }
    }
}