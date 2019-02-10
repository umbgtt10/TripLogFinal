using System;

namespace TripLog.ViewModels
{
    public class ViewModelFactory
    {
        public BaseViewModel Build(ViewType viewModelType)
        {
            switch (viewModelType)
            {
                case ViewType.Detail:
                    return new DetailViewModel();
                case ViewType.Main:
                    return new MainViewModel();
                case ViewType.New:
                    return new NewEntryViewModel();
                default:
                    throw new Exception($"Unknown {viewModelType}");
            }
        }
    }
}