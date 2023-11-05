using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Avalonia.Themes.Neumorphism.Converters
{
    public sealed class CustomBoxShadowsConverter : IMultiValueConverter
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

                //-5 -5 20 {MaterialDesignShadowLight}, 5 5 20 {MaterialDesignShadowDark}
                if (!string.IsNullOrEmpty(boxShadowsTemplate))
                {
                    boxShadowsTemplate = boxShadowsTemplate.Replace("{MaterialDesignShadowLight}", colorLight);
                    boxShadowsTemplate = boxShadowsTemplate.Replace("{MaterialDesignShadowDark}", colorDark);

                    b = BoxShadows.Parse(boxShadowsTemplate);
                }
            }

            return b;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}