using System.ComponentModel;
using TripLog.ViewModels;
using Xamarin.Forms;

namespace TripLog
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel Vm
        {
            get
            {
                return (MainPageViewModel)BindingContext;
            }
        }

        public MainPage()
        {
            InitializeComponent();
        }

        public void SetViewModel(MainPageViewModel vm)
        {
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            Vm.Init();
        }
    }
}
