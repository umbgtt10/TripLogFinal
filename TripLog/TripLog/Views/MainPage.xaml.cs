using System;

using TripLog.Models;
using TripLog.ViewModels;
using Xamarin.Forms;

namespace TripLog.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }

        private void New_Clicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new NewEntryPage());
        }

        private void Trips_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new DetailPage((TripLogEntry)e.Item));
        }
    }
}
