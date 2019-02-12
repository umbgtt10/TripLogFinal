﻿namespace TripLog.UWP
{
    using Modules;

    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new TripLog.App(new TripLogPlatformModule()));
        }
    }
}
