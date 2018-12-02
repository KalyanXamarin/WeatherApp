using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Services.Resgistration;
using WeatherApp.ViewModels.Shared;
using Xamarin.Forms;

namespace WeatherApp.ViewModels.Registration
{
    public class SignUpViewModel : BaseViewModel
    {
        SignUpService signUpService;
        public SignUpViewModel()
        {
            signUpService = new SignUpService();
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
        string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                RaisePropertyChanged(() => Email);
            }
        }
        #endregion
        #region commands
        public ICommand SignupCommand => new Command(async () => await SignUpClick());


        async Task SignUpClick()
        {
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(Email))
            {
                IsToShowLoader = true;
                LoadingText = Localization.Translations.Label_LoggingIn;
                var result = signUpService.StoreUserInfo(new DataBase.Sqlite.UserInfo(UserName, Password, Email));
                if (result.IsSucess)
                {
                    await CurrentView.PopAsync();
                }
                else
                {
                    await ShowAlertMessageDialog(Localization.Translations.Label_Alert, result.ErrorMessage);
                }
            }
            else
            {
                await ShowAlertMessageDialog(Localization.Translations.Label_Alert, Localization.Translations.Label_SignupEmptyMessage);
            }
        }
        #endregion
    }
}
