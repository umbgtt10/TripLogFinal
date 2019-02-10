using TripLog.ViewModels;
using TripLog.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TripLog
{
    public partial class App : Application
    {
        private ViewModelFactory _viewModelFactory;

        public App()
        {
            InitializeComponent();
            _viewModelFactory = new ViewModelFactory();

            var viewModel = _viewModelFactory.Build(TripLogViewModelType.Main);
            viewModel.Init();

            MainPage = new NavigationPage(new MainPage(_viewModelFactory, viewModel));
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
    }
}
