using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Avalonia.Themes.Neumorphism.Converters
{
    public class CustomBoxShadowsConverter : IMultiValueConverter
    {
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            var b = new BoxShadows();

            if (values != null && values.Count == 3
            && values[0] != AvaloniaProperty.UnsetValue
            && values[1] != AvaloniaProperty.UnsetValue
            && values[2] != AvaloniaProperty.UnsetValue)
            {
                string boxShadowsTemplate = values[0].ToString();
                string colorLight = values[1].ToString();
                string colorDark = values[2].ToString();

                //-5 -5 20 {MaterialDesignShadowLightColor}, 5 5 20 {MaterialDesignShadowDarkColor}
                if (!string.IsNullOrEmpty(boxShadowsTemplate))
                {
                    boxShadowsTemplate = boxShadowsTemplate.Replace("{MaterialDesignShadowLightColor}", colorLight);
                    boxShadowsTemplate = boxShadowsTemplate.Replace("{MaterialDesignShadowDarkColor}", colorDark);

                    b = BoxShadows.Parse(boxShadowsTemplate);
                }
            }


            //BoxShadow main = new BoxShadow();
            //BoxShadow rest1 = new BoxShadow();

            //List<BoxShadow> rests = new List<BoxShadow>();

            //main.IsInset = true;
            //main.OffsetX = -3.3;
            //main.OffsetY = -3.3;
            //main.Blur = 10;
            //main.Color = Color.FromRgb(100, 0, 20);

            //b = new BoxShadows(main, rests.ToArray());

            return b;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}