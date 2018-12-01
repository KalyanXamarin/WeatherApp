using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.DependencyServices;
using WeatherApp.ViewModels.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views.Shared
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BaseView : ContentPage
	{
		public BaseView ()
		{
			InitializeComponent ();
		}
        protected void SetBaseViewContext(BaseViewModel _viewModel)
        {
            BindingContext = _viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            DependencyService.Get<IStatusBar>()?.SetStatusBar((Color)Application.Current.Resources["StatusBarColor"]);
        }
    }
}