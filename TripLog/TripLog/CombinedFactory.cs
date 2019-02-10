using TripLog.Models;
using TripLog.ViewModels;
using TripLog.Views;
using Xamarin.Forms;

namespace TripLog
{
    public class CombinedFactory
    {
        private readonly ViewFactory _viewFactory;
        private readonly ViewModelFactory _viewModelFactory;

        public CombinedFactory(ViewFactory viewFactory, ViewModelFactory viewModelFactory)
        {
            _viewFactory = viewFactory;
            _viewModelFactory = viewModelFactory;
        }

        public ContentPage Build(ViewType modelType)
        {
            var viewModel = _viewModelFactory.Build(modelType);
            viewModel.Init();
            var view = _viewFactory.Build(modelType, viewModel);
            return view;
        }

        public ContentPage Build(ViewType modelType, TripLogEntry entry)
        {
            var viewModel = _viewModelFactory.Build(modelType);
            viewModel.Init(entry);
            var view = _viewFactory.Build(modelType, viewModel);
            return view;
        }
    }
}
