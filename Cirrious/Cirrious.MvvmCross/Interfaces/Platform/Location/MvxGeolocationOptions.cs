﻿namespace Cirrious.MvvmCross.Interfaces.Platform.Location
{
    public class MvxGeoLocationOptions
    {
        public int Timeout { get; set; }
        public int MaximumAge { get; set; }
        public bool EnableHighAccuracy { get; set; }
    }
}
