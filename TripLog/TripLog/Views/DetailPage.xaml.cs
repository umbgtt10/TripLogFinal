using TripLog.Models;
using TripLog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TripLog.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
        private DetailViewModel _vm { get { return BindingContext as DetailViewModel; } }

        public DetailPage(TripLogEntry entry)
        {
            InitializeComponent();

            BindingContext = new DetailViewModel(entry);

            var position = new Position(_vm.Entry.Latitude, _vm.Entry.Longitude);

            map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(.5)));

            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = _vm.Entry.Title,
                Position = position
            });
        }
    }
}