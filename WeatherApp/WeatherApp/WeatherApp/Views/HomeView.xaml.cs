using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.ViewModels;
using WeatherApp.Views.Shared;
using WeatherApp.Views.Weather;
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
            CitiesListView.ItemsSource = _viewModel.CitiesList;
            CitiesListView.ItemTapped += CitiesListView_ItemTapped;
        }

        private void CitiesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            CitiesListView.SelectedItem = null;
            var selectedItem = (CitiesModel)e.Item;
            Navigation.PushAsync(new WeatherView(selectedItem));
        }
    }
}