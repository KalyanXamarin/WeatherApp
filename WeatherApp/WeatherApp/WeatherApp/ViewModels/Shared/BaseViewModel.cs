using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WeatherApp.ViewModels.Shared
{
    public class BaseViewModel : ExtendedBindableObject
    {
        public bool _isToShowLoader;
        /// <summary>
        /// For showing infinite progress(loader) make it is true and vice-versa
        /// </summary>
        public bool IsToShowLoader
        {
            get
            {
                return _isToShowLoader;
            }
            set
            {
                _isToShowLoader = value;
                RaisePropertyChanged(() => IsToShowLoader);
            }
        }

        string _loadingText;
        /// <summary>
        /// Displayed along with the progressbar 
        /// </summary>
        public string LoadingText
        {
            get
            {
                return _loadingText;
            }
            set
            {
                _loadingText = value;
                RaisePropertyChanged(() => LoadingText);
            }
        }

        public NavigationPage CurrentView
        {
            get
            {
                return Application.Current.MainPage as NavigationPage;
            }
        }
    }
}
