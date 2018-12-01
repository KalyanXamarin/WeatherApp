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
	public partial class SignUpView : BaseView
	{
        SignUpViewModel _viewModel;
        public SignUpView ()
		{
			InitializeComponent ();
            _viewModel = new SignUpViewModel();
            BindingContext = _viewModel;
            SetBaseViewContext(_viewModel);
        }
	}
}