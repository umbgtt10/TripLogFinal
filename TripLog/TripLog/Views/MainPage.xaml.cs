using System;

using TripLog.Models;
using TripLog.ViewModels;
using Xamarin.Forms;

namespace TripLog.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly ViewModelFactory _viewModelFactory;

        public MainPage(ViewModelFactory viewModelFactory, BaseViewModel viewModel)
        {
            InitializeComponent();
            _viewModelFactory = viewModelFactory;

            BindingContext = viewModel;
        }

        private void New_Clicked(object sender, EventArgs args)
        {
            var viewModel = _viewModelFactory.Build(TripLogViewModelType.New);
            viewModel.Init();

            Navigation.PushAsync(new NewEntryPage(viewModel));
        }

        private void Trips_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var entry = (TripLogEntry)e.Item;
            var viewModel = _viewModelFactory.Build(TripLogViewModelType.Detail);
            viewModel.Init(entry);

            Navigation.PushAsync(new DetailPage(viewModel));
        }
    }
}
