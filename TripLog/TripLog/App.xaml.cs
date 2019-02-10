using System;
using Ninject;
using Ninject.Modules;
using TripLog.Services;
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
        private readonly ViewFactory _viewFactory;
        private readonly CombinedFactory _combinedFactory;
        private readonly IKernel _kernel;

        public App(params INinjectModule[] platformModules)
        {
            InitializeComponent();

            _kernel = new StandardKernel();
            _kernel.Load(platformModules);

            var locationService = _kernel.Get<GeoLocationService>();

            _viewModelFactory = new ViewModelFactory(locationService);
            _viewFactory = new ViewFactory();
            _combinedFactory = new CombinedFactory(_viewFactory, _viewModelFactory);

            var viewModel = _viewModelFactory.Build(ViewType.Main);
            viewModel.Init();

            var mainPage = new MainPage(viewModel);
            mainPage.Init(_combinedFactory);

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
