using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WeatherApp.DependencyServices
{
    public interface IStatusBar
    {
        void SetStatusBar(Color color);
    }
}
