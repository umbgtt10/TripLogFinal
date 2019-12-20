using TripLog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TripLog
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewEntryPage : ContentPage
    {
        public NewEntryPage(NewEntryPageViewModel vm)
        {
            BindingContext = vm;

            InitializeComponent();
        }
    }
}