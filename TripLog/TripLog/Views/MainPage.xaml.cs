using System;

using TripLog.Models;
using TripLog.ViewModels;
using Xamarin.Forms;

namespace TripLog.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly ViewFactory _viewFactory;
        private readonly ViewModelFactory _viewModelFactory;

        public MainPage(ViewFactory viewFactory, 
                        ViewModelFactory viewModelFactory, 
                        BaseViewModel viewModel)
        {
            InitializeComponent();
            _viewModelFactory = viewModelFactory;
            _viewFactory = viewFactory;

            BindingContext = viewModel;
        }

        private void New_Clicked(object sender, EventArgs args)
        {
            var viewModel = _viewModelFactory.Build(TripLogViewModelType.New);
            viewModel.Init();

            var newEntryPage = _viewFactory.Build(TripLogViewModelType.New, viewModel);

            Navigation.PushAsync(newEntryPage);
        }

        private void Trips_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var entry = (TripLogEntry)e.Item;
            var viewModel = _viewModelFactory.Build(TripLogViewModelType.Detail);
            viewModel.Init(entry);

            var detailView = _viewFactory.Build(TripLogViewModelType.Detail, viewModel);

            Navigation.PushAsync(detailView);
        }
    }
}
