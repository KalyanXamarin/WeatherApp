using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models
{
    public class CitiesModel
    {
        public string CityName { set; get; }
        public double Latitude { set; get; }
        public double Longitude { set; get; }
        public CitiesModel(string cityName,double latitude,double longitude)
        {
            CityName = cityName;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
