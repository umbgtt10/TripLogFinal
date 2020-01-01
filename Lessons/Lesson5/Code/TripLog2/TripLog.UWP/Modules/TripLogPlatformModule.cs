﻿using Ninject.Modules;

using TripLog.Services;
using TripLog.UWP.Services;

namespace TripLog.UWP.Modules
{
    public class TripLogPlatformModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGeoLocationService>().
                To<UwpLocationService>().
                InSingletonScope();
        }
    }
}