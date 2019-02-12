namespace TripLog.Views
{    
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    using ViewModels;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewEntryPage : ContentPage
	{
		public NewEntryPage (BaseViewModel viewModel)
		{
			InitializeComponent ();

            BindingContext = viewModel;
        }
    }
}