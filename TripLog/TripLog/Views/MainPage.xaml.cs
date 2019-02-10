using System;

using TripLog.Models;
using TripLog.ViewModels;
using Xamarin.Forms;

namespace TripLog.Views
{
    public partial class MainPage : ContentPage
    {
        private CombinedFactory _combinedFactory;

        public MainPage(BaseViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        public void Init(CombinedFactory combinedFactory)
        {
            _combinedFactory = combinedFactory;
        }

        private void New_Clicked(object sender, EventArgs args)
        {
            var newEntryPage = _combinedFactory.Build(TripLogViewModelType.New);

            Navigation.PushAsync(newEntryPage);
        }

        private void Trips_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var entry = (TripLogEntry)e.Item;

            var detailView = _combinedFactory.Build(TripLogViewModelType.Detail, entry);

            Navigation.PushAsync(detailView);
        }
    }
}
