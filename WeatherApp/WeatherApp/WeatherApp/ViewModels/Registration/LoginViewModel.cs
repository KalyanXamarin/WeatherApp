using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.ViewModels.Shared;
using Xamarin.Forms;

namespace WeatherApp.ViewModels.Registration
{
    public class LoginViewModel : BaseViewModel
    {
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

        public ICommand LoginCommand => new Command(async () => await OnLoginClick());

        async Task OnLoginClick()
        {
            if(string.IsNullOrEmpty(UserName) && string.IsNullOrEmpty(Password))
            {
                IsToShowLoader = true;
                LoadingText = Localization.Translations.Label_LoggingIn;
            }
        }
    }
}
