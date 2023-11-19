using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Avalonia.Themes.Neumorphism.Converters
{
    public sealed class BooleanValueToHalfDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool inverse = parameter != null && parameter.ToString() == "1";

            if (value != null)
            {
                bool b = (bool)value;
                if (b)
                {
                    return inverse ? 0.0 : 0.5;
                }
                else
                {
                    return inverse ? 0.5 : 0.0;
                }
            }

            return 0.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}