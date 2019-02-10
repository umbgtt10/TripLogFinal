using TripLog.UWP.Modules;

namespace TripLog.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new TripLog.App(new TripLogPlatformModule()));
        }
    }
}
