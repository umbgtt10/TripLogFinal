using System;

namespace TripLog.ViewModels
{
    public class ViewModelFactory
    {
        public ViewModelFactory()
        {

        }

        public BaseViewModel Build(TripLogViewModelType viewModelType)
        {
            switch (viewModelType)
            {
                case TripLogViewModelType.Detail:
                    return new DetailViewModel();
                case TripLogViewModelType.Main:
                    return new MainViewModel();
                case TripLogViewModelType.New:
                    return new NewEntryViewModel();
                default:
                    throw new Exception($"Unknown {viewModelType}");
            }
        }
    }
}