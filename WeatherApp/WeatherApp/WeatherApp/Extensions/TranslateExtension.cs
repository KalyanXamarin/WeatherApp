using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Extensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        const string ResourceId = "WeatherApp.Localization.Translations";
        public string Text { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
            {
                return null;
            }

            ResourceManager resourceManager = new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly);
            var currentCulture = CultureInfo.CurrentUICulture;

            var translation = resourceManager.GetString(Text, currentCulture);
            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text,
                                  ResourceId, currentCulture.Name),
                                 "Text");
#else
                translation = Text; // returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
    }
}
