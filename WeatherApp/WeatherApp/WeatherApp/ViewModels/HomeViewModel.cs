using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Services.Home;
using WeatherApp.ViewModels.Shared;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class HomeViewModel :BaseViewModel
    {
        WeatherService weatherService;
        public HomeViewModel()
        {
            weatherService = new WeatherService();
        }

        public ICommand LoadWeatherInfoCommand => new Command(async () => await LoadWeatherInfo());

        async Task LoadWeatherInfo()
        {
           await weatherService.GetWeatherInfo(17.3850, 78.4867);
        }
    }
}
