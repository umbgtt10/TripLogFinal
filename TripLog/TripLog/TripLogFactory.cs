namespace TripLog
{
    using System;
    using Ninject;
    using Ninject.Modules;

    using Xamarin.Forms;

    using Services;
    using ViewModels;
    using Views;

    public class TripLogFactory
    {
        private ViewModelFactory _viewModelFactory;
        private ViewFactory _viewFactory;
        private CombinedFactory _combinedFactory;
        private readonly IKernel _kernel;

        public TripLogFactory(params INinjectModule[] platformModules)
        {
            _kernel = new StandardKernel();
            _kernel.Load(platformModules);
        }

        public ContentPage Build()
        {
            var locationService = _kernel.Get<GeoLocationService>();

            var httpClient = new StandardAsyncHttpClient();
            var backendUri = new Uri("http://192.168.56.102:30080/api/TripLogWebApi/");
            var restTripLogDataService = new RestTripLogDataService(httpClient, backendUri);
            _viewModelFactory = new ViewModelFactory(locationService, restTripLogDataService);
            _viewFactory = new ViewFactory();
            _combinedFactory = new CombinedFactory(_viewFactory, _viewModelFactory);

            var viewModel = _viewModelFactory.Build(ViewType.Main);
            viewModel.Init();

            var mainPage = new MainPage(viewModel);
            mainPage.Init(_combinedFactory);

            return mainPage;
        }
    }
}
