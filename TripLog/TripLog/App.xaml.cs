using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TripLog
{
    using Ninject.Modules;

    using Xamarin.Forms;

    public partial class App : Application
    {
        public App(params INinjectModule[] platformModules)
        {
            var factory = new TripLogFactory(platformModules);

            var mainPage = factory.Build();

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
