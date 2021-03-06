﻿namespace TripLog.Droid.Modules
{
    using Ninject.Modules;

    using Services;
    using TripLog.Services;

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