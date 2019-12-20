using System.ComponentModel;
using TripLog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TripLog
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class DetailPage : ContentPage
    {
        public DetailPageViewModel Vm 
        {
            get
            {
                return (DetailPageViewModel)BindingContext;
            }
        }

        public DetailPage(DetailPageViewModel vm)
        {
            InitializeComponent();

            BindingContext = vm;

            var position = new Position(vm.Entry.Latitude, vm.Entry.Longitude);

            map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(.5)));

            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = vm.Entry.Title,
                Position = position
            });
        }
    }
}