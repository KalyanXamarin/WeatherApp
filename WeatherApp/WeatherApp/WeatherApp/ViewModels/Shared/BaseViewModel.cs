using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.ViewModels.Shared
{
    public class BaseViewModel : ExtendedBindableObject
    {
        public bool _isToShowLoader;
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
    }
}
