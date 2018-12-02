using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.ViewModels;
using WeatherApp.Views.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeView : BaseView
	{
        HomeViewModel _viewModel;
        public HomeView ()
		{
			InitializeComponent ();
            _viewModel = new HomeViewModel();
            BindingContext = _viewModel;
            SetBaseViewContext(_viewModel);
            _viewModel.LoadWeatherInfoCommand.Execute(null);
        }
	}
}