using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.ViewModels.Weather;
using WeatherApp.Views.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views.Weather
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WeatherView : BaseView
	{
        WeatherViewModel _viewModel;

        public WeatherView(CitiesModel citiesModel)
		{
			InitializeComponent ();
            _viewModel = new WeatherViewModel(citiesModel);
            BindingContext = _viewModel;
            Title = $"{citiesModel.CityName} {Localization.Translations.Label_Weather}";
            SetBaseViewContext(_viewModel);
            _viewModel.LoadWeatherInfoCommand.Execute(null);
        }
	}
}