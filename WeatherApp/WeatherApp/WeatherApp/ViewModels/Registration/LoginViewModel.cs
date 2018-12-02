using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Services.Resgistration;
using WeatherApp.ViewModels.Shared;
using WeatherApp.Views;
using WeatherApp.Views.Registration;
using Xamarin.Forms;

namespace WeatherApp.ViewModels.Registration
{
    public class LoginViewModel : BaseViewModel
    {
        LoginService loginService;
        public LoginViewModel()
        {
            loginService = new LoginService();
        }
        #region Properties
        string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                RaisePropertyChanged(() => UserName);
            }
        }
        string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }
        #endregion
        #region commands
        public ICommand LoginCommand => new Command(async () => await OnLoginClick());
        public ICommand SignupCommand => new Command(async () => await SignUpClick());


        async Task OnLoginClick()
        {
            if(!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {
                ShowLoader?.Invoke(Localization.Translations.Label_LoggingIn);
                var result = loginService.Login(UserName, Password);
                HideLoader?.Invoke();
                if (result.IsSucess)
                {
                    Application.Current.MainPage = new NavigationPage(new HomeView());
                }
                else
                {
                   await ShowAlertMessageDialog(Localization.Translations.Label_Alert, result.ErrorMessage);
                }
            }
            else
            {
                await ShowAlertMessageDialog(Localization.Translations.Label_Alert, Localization.Translations.Label_LoginEmptyMessage);
            }
        }

        async Task SignUpClick()
        {
            await CurrentView.PushAsync(new SignUpView());
        }

        #endregion
    }
}
