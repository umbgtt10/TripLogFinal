using Ninject.Modules;
using TripLog.Views;
using Xamarin.Forms;

namespace TripLog
{
    public partial class App : Application
    {
        private readonly TripLogMainPageFactory factory;

        public App(params INinjectModule[] platformModules)
        {
            InitializeComponent();

            factory = new TripLogMainPageFactory(platformModules);

            MainPage = factory.BuildMainPage();
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
