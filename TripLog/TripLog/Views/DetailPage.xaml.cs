namespace TripLog.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Maps;
    using Xamarin.Forms.Xaml;

    using ViewModels;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
        private DetailViewModel _vm { get { return BindingContext as DetailViewModel; } }

        public DetailPage(BaseViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;

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