using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Avalonia.Themes.Neumorphism.Converters
{
    public sealed class StringReplaceConverter : IMultiValueConverter
    {
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Count == 2
                && values[0] != AvaloniaProperty.UnsetValue && values[0] is string
                && values[1] != AvaloniaProperty.UnsetValue && values[1] is string)
            {
                string primaryString = (string)values[0];
                string secondaryString = (string)values[1];

                if (!string.IsNullOrEmpty(primaryString))
                {
                    return primaryString;
                }
                else if (!string.IsNullOrEmpty(secondaryString))
                {
                    return secondaryString;
                }
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}