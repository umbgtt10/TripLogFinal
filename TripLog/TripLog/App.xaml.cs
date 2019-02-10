using TripLog.ViewModels;
using TripLog.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TripLog
{
    public partial class App : Application
    {
        private readonly ViewModelFactory _viewModelFactory;
        private ViewFactory _viewFactory;

        public App()
        {
            InitializeComponent();
            _viewModelFactory = new ViewModelFactory();
            _viewFactory = new ViewFactory(_viewModelFactory);

            var viewModel = _viewModelFactory.Build(TripLogViewModelType.Main);
            viewModel.Init();

            var mainPage = _viewFactory.Build(TripLogViewModelType.Main, viewModel);

            MainPage = new NavigationPage(mainPage);
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
