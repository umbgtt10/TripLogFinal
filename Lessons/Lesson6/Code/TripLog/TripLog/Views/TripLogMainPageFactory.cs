using Ninject;
using Ninject.Modules;
using System;
using TripLog.Services;
using TripLog.ViewModels;
using Xamarin.Forms;

namespace TripLog.Views
{
    public class TripLogMainPageFactory
    {
        private readonly IKernel kernel;

        public TripLogMainPageFactory(INinjectModule[] platformModules)
        {
            kernel = new StandardKernel();
            kernel.Load(platformModules);
        }

        public NavigationPage BuildMainPage()
        {
            var locationService = kernel.Get<IGeoLocationService>();

            var mainPage = new MainPage();
            var tripLogNavigation = new TripLogNavigation(mainPage.Navigation);
            var viewFactory = new ViewFactory();
            var httpClient = new StandardAsyncHttpClient();
            var tripLogDataService = new RestTripLogDataService(httpClient, new Uri(AppSettingsManager.Settings["Service"]));
            var viewModelFactory = new ViewModelFactory(tripLogNavigation, locationService, tripLogDataService);
            var factory = new TripLogFactory(viewFactory, viewModelFactory, tripLogNavigation);
            var vm = new MainPageViewModel(factory, tripLogDataService);
            mainPage.SetViewModel(vm);

            return new NavigationPage(mainPage);
        }
    }
}
