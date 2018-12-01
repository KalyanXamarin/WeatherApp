using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.ViewModels.Registration;
using WeatherApp.Views.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views.Registration
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginView : BaseView
    {
        LoginViewModel _viewModel;
		public LoginView()
		{
			InitializeComponent ();
            _viewModel = new LoginViewModel();
            BindingContext = _viewModel;
        }
	}
}