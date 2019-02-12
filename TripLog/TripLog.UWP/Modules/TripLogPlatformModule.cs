namespace TripLog.UWP.Modules
{
    using Ninject.Modules;
    using TripLog.Services;

    using Services;

    public class TripLogPlatformModule : NinjectModule
    {
        public override void Load()
        {
            Bind<GeoLocationService>().
                To<UwpLocationService>().
                InSingletonScope();
        }
    }
}
