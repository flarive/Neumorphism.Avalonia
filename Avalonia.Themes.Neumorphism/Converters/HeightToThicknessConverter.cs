using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Avalonia.Themes.Neumorphism.Converters
{
    public sealed class HeightToThicknessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double height = 0;

            if (value is double)
            {
                height = (double)value;
            }

            int factor = 10;
            if (parameter != null)
            {
                if (!string.IsNullOrEmpty(parameter.ToString()))
                {
                    int.TryParse(parameter.ToString(), out factor);
                }
            }

            double ooo = height / factor;

            return (int)ooo;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}