using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected void SetBaseViewContext(BaseViewModel _viewModel)
        {
            BindingContext = _viewModel;
            _viewModel.ShowAlertMessage += ShowAlert;
            _viewModel.ShowConfirmMessage += ShowConfirm;
        }

        #region controlTemplateBindingCode
        public ICommand ButtonBackCommand => new Command(async () => await OnBackButtonPressed());
        async Task OnBackButtonPressed()
        {
            await Navigation.PopAsync();
        }

        #endregion


        async Task<bool> ShowAlert(string title,string message,string labelOk)
        {
            await DisplayAlert(title, message, labelOk);
            return true;
        }

        async Task<bool> ShowConfirm(string title, string message, string labelOk,string labelCancel)
        {
            return await DisplayAlert(title, message, labelOk,labelCancel);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DependencyService.Get<IStatusBar>()?.SetStatusBar((Color)Application.Current.Resources["StatusBarColor"]);
        }
    }
}