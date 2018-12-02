using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Models;
using WeatherApp.Services.Home;
using WeatherApp.ViewModels.Shared;
using Xamarin.Forms;

namespace WeatherApp.ViewModels.Weather
{
    public class WeatherViewModel : BaseViewModel
    {
        WeatherService weatherService;
        CitiesModel selectedCity;
        public WeatherViewModel(CitiesModel selectedCity)
        {
            this.selectedCity = selectedCity;
            weatherService = new WeatherService();
        }

        string _temprature;
        public string Temparature
        {
            get
            {
                return _temprature;
            }
            set
            {
                _temprature = value;
                RaisePropertyChanged(() => Temparature);
            }
        }

        string _humdity;
        public string Humidity
        {
            get
            {
                return _humdity;
            }
            set
            {
                _humdity = value;
                RaisePropertyChanged(() => Humidity);
            }
        }
        string _pressure;
        public string Pressure
        {
            get
            {
                return _pressure;
            }
            set
            {
                _pressure = value;
                RaisePropertyChanged(() => Pressure);
            }
        }

        public ICommand LoadWeatherInfoCommand => new Command(async () => await LoadWeatherInfo());

        async Task LoadWeatherInfo()
        {
            ShowLoader?.Invoke(Localization.Translations.Label_FetchingWeather);
            var data = await weatherService.GetWeatherInfo(selectedCity.Latitude,selectedCity.Longitude);
            if (data.IsSucess)
            {
                Temparature = $"{data.Result.Main.Temprature - 273} Celsius";
                Humidity = $"{data.Result.Main.Humidity} %";
                Pressure = $"{data.Result.Main.Pressure} mmHg";
            }
            HideLoader?.Invoke();
        }
    }
}
