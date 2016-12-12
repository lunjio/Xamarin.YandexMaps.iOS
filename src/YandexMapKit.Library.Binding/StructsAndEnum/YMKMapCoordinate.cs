using System;

namespace YandexMapKit
{
    public struct YMKMapCoordinate
    {
        public double Latitude;
        public double Longitude;

        public YMKMapCoordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}

