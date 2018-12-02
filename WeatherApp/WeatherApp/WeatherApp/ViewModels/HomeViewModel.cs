using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Models;
using WeatherApp.Services.Home;
using WeatherApp.ViewModels.Shared;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class HomeViewModel :BaseViewModel
    {
        public ObservableCollection<CitiesModel> CitiesList;
        public HomeViewModel()
        {
            CitiesList = new ObservableCollection<CitiesModel>();
            CitiesList.Add(new CitiesModel("Hyderabad", 17.3850, 78.4867));
            CitiesList.Add(new CitiesModel("Delhi", 28.40, 77.14));
            CitiesList.Add(new CitiesModel("Kolkata", 22.30, 88.20));
            CitiesList.Add(new CitiesModel("Bangalore", 12.58, 77.35));
            CitiesList.Add(new CitiesModel("Mumbai", 18.56, 74.35));
            CitiesList.Add(new CitiesModel("Nagpur", 21.10, 79.12));
            CitiesList.Add(new CitiesModel("Hyderabad", 17.3850, 78.4867));
            CitiesList.Add(new CitiesModel("Hyderabad", 17.3850, 78.4867));
        }
    }
}
