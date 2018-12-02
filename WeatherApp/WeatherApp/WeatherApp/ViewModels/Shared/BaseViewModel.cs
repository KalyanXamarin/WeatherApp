using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace WeatherApp.ViewModels.Shared
{
    public class BaseViewModel : ExtendedBindableObject
    {
        /// <summary>
        /// Returns current view and navigation view
        /// </summary>
        public NavigationPage CurrentView
        {
            get
            {
                return Application.Current.MainPage as NavigationPage;
            }
        }
        #region View intraction delegates
        public Func<string,string,string,Task<bool>> ShowAlertMessage { set; get; }
        public Func<string,string,string,string,Task<bool>> ShowConfirmMessage { set; get; }
        public Action<string> ShowLoader { set; get; }
        public Action HideLoader { set; get; }
        #endregion
        public async Task ShowAlertMessageDialog(string title,string message)
        {
            await ShowAlertMessage?.Invoke(title, message, Localization.Translations.Label_Ok);
        }

        public async Task ShowConfirmMessageDialog(string title, string message)
        {
            await ShowConfirmMessage?.Invoke(title, message, Localization.Translations.Label_Ok,Localization.Translations.Label_Cancel);
        }
    }
}
