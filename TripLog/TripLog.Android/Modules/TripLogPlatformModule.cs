using Ninject.Modules;
using TripLog.Droid.Services;
using TripLog.Services;

namespace TripLog.Droid.Modules
{
    public class TripLogPlatformModule : NinjectModule
    {
        public override void Load()
        {
            Bind<GeoLocationService>().
                To<AndroidLocationService>().
                InSingletonScope();
        }
    }
}