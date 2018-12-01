using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WeatherApp.DependencyServices;
using WeatherApp.Droid.DependencyServcies;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.Dependency(typeof(StatusBar))]
namespace WeatherApp.Droid.DependencyServcies
{
    public class StatusBar : IStatusBar
    {
        public void SetStatusBar(Color color)
        {
            var activity = (Activity)Forms.Context;
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                activity.Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                activity.Window.SetStatusBarColor(color.ToAndroid());
            }
        }
    }
}