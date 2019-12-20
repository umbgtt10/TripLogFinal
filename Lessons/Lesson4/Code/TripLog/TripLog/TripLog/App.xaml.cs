using TripLog.Services;
using TripLog.ViewModels;
using TripLog.Views;
using Xamarin.Forms;

namespace TripLog
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            MainPage = BuildMainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private NavigationPage BuildMainPage()
        {
            var mainPage = new MainPage();
            var tripLogNavigation = new TripLogNavigation(mainPage.Navigation);
            var viewFactory = new ViewFactory();
            var viewModelFactory = new ViewModelFactory(tripLogNavigation);
            var factory = new TripLogFactory(viewFactory, viewModelFactory, tripLogNavigation);
            var vm = new MainPageViewModel(factory);
            mainPage.SetViewModel(vm);

            return new NavigationPage(mainPage);
        }
    }
}
